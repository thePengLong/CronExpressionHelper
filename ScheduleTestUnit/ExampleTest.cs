using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class ExampleTest
    {
        /// <summary>
        /// 0/2 * * * * ? *   表示每2秒 执行任务
        /// </summary>
        [Fact]
        public void Set_Example1_ReturnTrue()
        {
            var result = CronExpressionHelper.SetSecondGap(2);

            Assert.Equal("0/2 * * * * ? *", result);
        }

        /// <summary>
        /// 0 0/2 * * * ? *    表示每2分钟 执行任务
        /// </summary>
        [Fact]
        public void Set_Example2_ReturnTrue()
        {
            var result = CronExpressionHelper.SetMinuteGap(2);

            Assert.Equal("0 0/2 * * * ? *", result);
        }

        /// <summary>
        /// 0 0 2 1 * ? *  表示在每月的1日的凌晨2点调整任务
        /// </summary>
        [Fact]
        public void Set_Example3_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetSpecificDay(1), i => i.SetSpecificHour(2));

            Assert.Equal("0 0 2 1 * ? *", result);

            var cron = CronExpressionHelper.GetInstant;

            var result1 = cron.SetSpecificDay(1)
                 .SetSpecificHour(2).Result;

            Assert.Equal("0 0 2 1 * ? *", result1);
        }

        /// <summary>
        /// 0 15 10 ? * 2-5 *  表示周一到周五每天上午10:15执行作业
        /// </summary>
        [Fact]
        public void Set_Example4_ReturnTrue()
        {
            var cron = CronExpressionHelper.GetInstant;

            var result = cron.SetWeekCycle(2, 5)
                 .SetSpecificHour(10)
                 .SetSpecificMinute(15)
                 .Result;

            Assert.Equal("0 15 10 ? * 2-5 *", result);
        }

        /// <summary>
        /// 0 0 10,14,16 * * ? *   每天上午10点，下午2点，4点 
        /// </summary>
        [Fact]
        public void Set_Example5_ReturnTrue()
        {
            var result = CronExpressionHelper.SetSpecificHour(10, 14, 16);

            Assert.Equal("0 0 10,14,16 * * ? *", result);
        }

        /// <summary>
        /// 0 0/30 9-17 * * ? *  朝九晚五工作时间内每半小时
        /// </summary>
        [Fact]
        public void Set_Example6_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetHourCycle(9, 17), i => i.SetMinuteGap(30));

            Assert.Equal("0 0/30 9-17 * * ? *", result);
        }

        /// <summary>
        /// 0 0 12 ? * 4 *    表示每个星期三中午12点
        /// </summary>
        [Fact]
        public void Set_Example7_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetSpecificWeek(ScheduleDayOfWeek.Wednesday), i => i.SetSpecificHour(12));

            Assert.Equal("0 0 12 ? * 4 *", result);
        }

        /// <summary>
        /// 0 0/5 14 * * ? *   在每天下午2点到下午2:55期间的每5分钟触发 
        /// </summary>
        [Fact]
        public void Set_Example8_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetSpecificHour(14), i => i.SetMinuteGap(5));

            Assert.Equal("0 0/5 14 * * ? *", result);
        }

        /// <summary>
        /// 0 15 10 ? * 2-6 *   周一至周五的上午10:15触发 
        /// </summary>
        [Fact]
        public void Set_Example9_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetWeekCycle(2,6), i => i.SetSpecificHour(10),i=>i.SetSpecificMinute(15));

            Assert.Equal("0 15 10 ? * 2-6 *", result);
        }

        /// <summary>
        /// 0 15 10 L * ? *   每月最后一日的上午10:15触发
        /// </summary>
        [Fact]
        public void Set_Example10_ReturnTrue()
        {
            var result = CronExpressionHelper.Set(i => i.SetLastDayOfMonth(), i => i.SetSpecificHour(10), i => i.SetSpecificMinute(15));

            Assert.Equal("0 15 10 L * ? *", result);
        }

        /// <summary>
        /// 0 15 10 ? * 6L *    每月的最后一个星期五上午10:15触发
        /// </summary>
        [Fact]
        public void Set_Example11_ReturnTrue()
        {
            var result=CronExpressionHelper.Set(i=>i.SetLastDayOfWeek(ScheduleDayOfWeek.Friday), i => i.SetSpecificHour(10), i => i.SetSpecificMinute(15));

            Assert.Equal("0 15 10 ? * 6L *", result);
        }
    }
}
