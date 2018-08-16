using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject1
{
    #region Models
    public class AppSettings
    {
        public Window Window { get; set; }
        public Connection Connection { get; set; }
        public Profile Profile { get; set; }
    }

    public class Window
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Connection
    {
        public string Value { get; set; }
    }

    public class Profile
    {
        public string Machine { get; set; }
    }

    #endregion

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dict = new Dictionary<string, string>
        {
            {"App:Profile:Machine", "Rick"},
            {"App:Connection:Value", "connectionstring"},
            {"App:Window:Height", "11"},
            {"App:Window:Width", "11"}
        };
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(dict);
            var config = builder.Build();

            var settings = new AppSettings();
            config.GetSection("App").Bind(settings);

            Assert.Equal("Rick", settings.Profile.Machine);
            Assert.Equal(11, settings.Window.Height);
            Assert.Equal(11, settings.Window.Width);
            Assert.Equal("connectionstring", settings.Connection.Value);
        }
    }
}
