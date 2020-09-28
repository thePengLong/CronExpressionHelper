using System;

namespace CronScheduleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = CronExpressionHelper.Set(i=>i.SetSpecificWeek(3,6),i=>i.SetSpecificHour(10),i=>i.SetSpecificMinute(15));

            Console.WriteLine(a);

            Console.ReadKey();
        }
    }
}
