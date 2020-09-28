using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class MinuteTest
    {
        public string[] GetInstant => new string[] { "0", "*", "*", "*", "*", "?", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_MinuteCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetMinuteCycle(startTime, endTime);

            var instant = GetInstant;

            instant[1] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_MinuteCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetMinuteCycle(startTime, endTime));

            var instant = GetInstant;

            instant[1] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(12, 60)]
        public void Set_WrongMinuteCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetMinuteCycle(startTime, endTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_MinuteAndSecondFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetMinuteCycle(startTime, endTime), i => i.SetSecondCycle(1, 2));

            var instant = GetInstant;

            instant[0] = $"1-2";

            instant[1] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(12, 60)]
        public void Set_WrongMinuteAndSecondFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetMinuteCycle(startTime, endTime));

            Assert.Throws<Exception>(action);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_MinuteGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetMinuteGap(gapTime, startTime);

            var instant = GetInstant;

            instant[1] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(12, 60)]
        public void Set_WrongMinuteGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetMinuteGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_MinuteGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetMinuteGap(gapTime, startTime));

            var instant = GetInstant;

            instant[1] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(12, 60)]
        public void Set_WrongMinuteGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetMinuteGap(gapTime, startTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(12, 24, 48)]
        public void Set_SpecificMinute_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificMinute(input);

            var instant = GetInstant;

            instant[1] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(12, 24, 60)]
        public void Set_WrongSpecificMinute_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificMinute(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(12, 24, 48)]
        public void Set_SpecificMinuteFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificMinute(input));

            var instant = GetInstant;

            instant[1] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(12, 24, 60)]
        public void Set_WrongSpecificMinuteFunc_ReturnTrue(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificMinute(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}
