using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class DayTest
    {
        public string[] GetInstant => new string[] { "0", "0", "0", "*", "*", "?", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetDayCycle(startTime, endTime);

            var instant = GetInstant;

            instant[3] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_WrongDayCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetDayCycle(startTime, endTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetDayCycle(startTime, endTime));

            var instant = GetInstant;

            instant[3] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_WrongDayCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetDayCycle(startTime, endTime));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayAndHourCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetDayCycle(startTime, endTime), i => i.SetHourCycle(1, 2));

            var instant = GetInstant;

            instant[2] = $"1-2";

            instant[3] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_WrongDayAndHourCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetDayCycle(startTime, endTime), i => i.SetHourCycle(1, 2));

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetDayGap(gapTime, startTime);

            var instant = GetInstant;

            instant[3] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }


        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_WrongDayGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetDayGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetDayGap(gapTime, startTime));

            var instant = GetInstant;

            instant[3] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_WrongDayGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetDayGap(gapTime, startTime);

            Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(4, 6)]
        public void Set_DayAndHourGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetDayGap(gapTime, startTime), i => i.SetHourGap(12));

            var instant = GetInstant;

            instant[2] = $"0/12";

            instant[3] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4, 32)]
        public void Set_DayAndHourGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetDayGap(gapTime, startTime), i => i.SetHourGap(12));

            Assert.Throws<Exception>(action);
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificDay_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificDay(input);

            var instant = GetInstant;

            instant[3] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 3, 35)]
        public void Set_WrongSpecificDay_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificDay(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificDayFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificDay(input));

            var instant = GetInstant;

            instant[3] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 3, 35)]
        public void Set_WrongSpecificDayFunc_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificDay(input);

            Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1, 3, 5)]
        public void Set_SpecificDayAndHour_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificDay(input), i => i.SetSpecificHour(10));

            var instant = GetInstant;

            instant[3] = string.Join(",", input);

            instant[2] = "10";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-1, 2, 3)]
        [InlineData(1, 3, 35)]
        public void Set_WrongSpecificDayAndHour_ReturnFalse(params int[] input)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSpecificDay(input), i => i.SetSpecificHour(10));

            Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}
