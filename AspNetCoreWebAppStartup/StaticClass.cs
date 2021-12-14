using System;

namespace AspNetCoreWebAppStartup
{
    public static class StaticClass
    {
        static StaticClass()
        {
            Console.WriteLine("StaticClass.ctor");
        }

        public static void MethodOne()
        {
            Console.WriteLine("StaticClass.MethodOne");
        }

        public static void MethodTwo()
        {
            Console.WriteLine("StaticClass.MethodTwo");
        }
    }
}

