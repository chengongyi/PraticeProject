using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            ObsoleteMethods(Assembly.GetAssembly(typeof(MyClass)));
        }

        private static void ObsoleteMethods(Assembly assembly)
        {
            var query = from type in assembly.GetExportedTypes().AsParallel()

                from method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)

                let obsoleteAttrType = typeof(ObsoleteAttribute)

                where Attribute.IsDefined(method, obsoleteAttrType)

                orderby type.FullName

                let obsoleteAttrObj = (ObsoleteAttribute) Attribute.GetCustomAttribute(method, obsoleteAttrType)

                select String.Format(
                    $"Type={type.FullName}  Method={method.ToString()},Message={obsoleteAttrObj.Message}");

            foreach (var result in query)
            {
                Console.WriteLine(result);
            }
        }
    }

    public class MyClass
    {
        [Obsolete("这个方法已经被废弃了")]
        public void Do()
        {
            Console.WriteLine();
        }

        [Obsolete("这个方法已经被废弃了Tow")]
        public void DO1()
        {
            SynchronizationContext
        }
    }


}
