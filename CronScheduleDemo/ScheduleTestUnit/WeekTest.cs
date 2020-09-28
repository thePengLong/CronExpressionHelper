using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class WeekTest
    {
        public string[] GetInstant => new string[] { "0", "0", "0", "?", "*", "*", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_WeekCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetWeekCycle(startTime, endTime);

            var instant = GetInstant;

            instant[5] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 8)]
        public void Set_WeekCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetWeekCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_WeekCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetWeekCycle(startTime, endTime);

            var instant = GetInstant;

            instant[5] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 8)]
        public void Set_WeekCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetWeekCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 5)]
        public void Set_WeekGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetWeekGap(gapTime, startTime);

            var instant = GetInstant;

            instant[5] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 8)]
        public void Set_WrongWeekGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetWeekGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 5)]
        public void Set_WeekGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetWeekGap(gapTime, startTime));

            var instant = GetInstant;

            instant[5] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 8)]
        public void Set_WrongWeekGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetWeekGap(gapTime, startTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificWeek_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificWeek(input);

            var instant = GetInstant;

            instant[5] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 8, 5)]
        public void Set_WrongSpecificWeek_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificWeek(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificWeekFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificWeek(input));

            var instant = GetInstant;

            instant[5] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificWeekAndHour_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificWeek(input),i=>i.SetSpecificHour(1));

            var instant = GetInstant;

            instant[5] = string.Join(",", input);

            instant[2] = "1";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 8, 5)]
        public void Set_WrongSpecificWeekFunc_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificWeek(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}
