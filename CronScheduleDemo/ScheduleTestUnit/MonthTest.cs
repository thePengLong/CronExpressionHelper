using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class MonthTest
    {
        public string[] GetInstant => new string[] { "0", "0", "0", "1", "*", "?", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_MonthCycle_ReturnTrue(int startTime, int endTime)
        {
            var result = CronExpressionHelper.SetMonthCycle(startTime, endTime);

            var instant = GetInstant;

            instant[4] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 13)]
        public void Set_WrongMonthCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetMonthCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_MonthCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            var result = CronExpressionHelper.Set(i => i.SetMonthCycle(startTime, endTime));

            var instant = GetInstant;

            instant[4] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 13)]
        public void Set_WrongMonthCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetMonthCycle(startTime, endTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_MonthGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetMonthGap(gapTime, startTime);

            var instant = GetInstant;

            instant[4] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 13)]
        public void Set_WrongMonthGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetMonthGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_MonthGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetMonthGap(gapTime, startTime));

            var instant = GetInstant;

            instant[4] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 13)]
        public void Set_WrongMonthGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetMonthGap(gapTime, startTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificMonth_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificMonth(input);

            var instant = GetInstant;

            instant[4] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 13, 5)]
        public void Set_WrongSpecificMonth_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificMonth(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificMonthFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificMonth(input));

            var instant = GetInstant;

            instant[4] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 13, 5)]
        public void Set_WrongSpecificMonthFunc_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificMonth(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}
