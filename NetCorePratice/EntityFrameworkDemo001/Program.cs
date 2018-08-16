using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkDemo001
{
    public class MyConfigurationValue
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    //创建自己的配置上下文
    public class MyConfigurationContext : DbContext
    {
        public MyConfigurationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyConfigurationValue> Values { get; set; }
    }

    //创建EF配置源类，接受
    public class MyEFConfigSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public MyEFConfigSource(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new EFConfigProvider(_optionsAction);
        }
    }


    //配置类提供者
    public class EFConfigProvider : ConfigurationProvider
    {
        Action<DbContextOptionsBuilder> OptionsAction { get; }

        public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            //创建一个配置上下文
            var builder = new DbContextOptionsBuilder<MyConfigurationContext>();

            //执行
            OptionsAction(builder);

            using (var dbContext = new MyConfigurationContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
                Data = !dbContext.Values.Any()
                    ? CreateAndSaveDefaultValues(dbContext)
                    : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
            }
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(
           MyConfigurationContext dbContext)
        {
            var configValues = new Dictionary<string, string>
                {
                    { "key1", "value_from_ef_1" },
                    { "key2", "value_from_ef_2" }
                };
            dbContext.Values.AddRange(configValues
                .Select(kvp => new MyConfigurationValue { Id = kvp.Key, Value = kvp.Value })
                .ToArray());
            dbContext.SaveChanges();
            return configValues;
        }
    }

    public static class EntityFrameworkExtensions
    {
        public static IConfigurationBuilder AddEntityFrameworkConfig(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
        {
            return builder.Add(new MyEFConfigSource(setup));
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            var connectionStringConfig = builder.Build();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // Add "appsettings.json" to bootstrap EF config.
                .AddJsonFile("appsettings.json")
                // Add the EF configuration provider, which will override any
                // config made with the JSON provider.
                .AddEntityFrameworkConfig(options =>
                    options.UseSqlServer(connectionStringConfig.GetConnectionString("DefaultConnection"))
                )
                .Build();

            Console.WriteLine("key1={0}", config["key1"]);
            Console.WriteLine("key2={0}", config["key2"]);
            Console.WriteLine("key3={0}", config["key3"]);
            Console.WriteLine();

            Console.WriteLine("Press a key...");
            Console.ReadKey();
        }
    }
}
