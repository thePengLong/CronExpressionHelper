using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class HourTest
    {
        public string[] GetInstant => new string[] { "0", "0", "*", "*", "*", "?", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetHourCycle(startTime, endTime);

            var instant = GetInstant;

            instant[2] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetHourCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetHourCycle(startTime, endTime));

            var instant = GetInstant;

            instant[2] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetHourCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourAndMinuteCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetHourCycle(startTime, endTime), i => i.SetMinuteCycle(1, 2));

            var instant = GetInstant;

            instant[1] = $"1-2";

            instant[2] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourAndMinuteCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetHourCycle(startTime, endTime), i => i.SetMinuteCycle(1, 2));

            Assert.Throws<Exception>(action);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetHourGap(gapTime, startTime);

            var instant = GetInstant;

            instant[2] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetHourGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetHourGap(gapTime, startTime));

            var instant = GetInstant;

            instant[2] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetHourGap(gapTime, startTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_HourAndMinuteGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetHourGap(gapTime, startTime), i => i.SetMinuteGap(30));

            var instant = GetInstant;

            instant[1] = $"0/30";

            instant[2] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(4, 24)]
        public void Set_WrongHourAndMinuteGap_ReturnTrue(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetHourGap(gapTime, startTime), i => i.SetMinuteGap(30));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificHour_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificHour(input);

            var instant = GetInstant;

            instant[2] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(1, 3, 24)]
        public void Set_WrongSpecificHour_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificHour(input);

            Assert.Throws<IndexOutOfRangeException>(action);

        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificHourFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificHour(input));

            var instant = GetInstant;

            instant[2] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(1, 3, 24)]
        public void Set_WrongSpecificHourFunc_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSpecificHour(input));

            Assert.Throws<IndexOutOfRangeException>(action);

        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificHourAndMinute_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificHour(input), i => i.SetSpecificMinute(10));

            var instant = GetInstant;

            instant[2] = string.Join(",", input);

            instant[1] = "10";

            Assert.Equal(string.Join(" ", instant), result);
        }


        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(1, 3, 24)]
        public void Set_WrongSpecificHourAndMinute_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSpecificHour(input), i => i.SetSpecificMinute(10));

            Assert.Throws<IndexOutOfRangeException>(action);

        }
    }
}
