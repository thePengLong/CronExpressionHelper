using CronScheduleDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ScheduleTestUnit
{
    public class SecondTest
    {
        public string[] GetInstant => new string[] { "*", "*", "*", "*", "*", "?", "*" };

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_SecondCycle_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.SetSecondCycle(startTime, endTime);

            var instant = GetInstant;

            instant[0] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(20, 10)]
        [InlineData(-2, 10)]
        [InlineData(0, 60)]
        public void Set_WrongSecondCycle_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.SetSecondCycle(startTime, endTime);

            Exception exception = Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_SecondCycleFunc_ReturnTrue(int startTime, int endTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetSecondCycle(startTime, endTime));

            var instant = GetInstant;

            instant[0] = $"{startTime}-{endTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(20, 10)]
        [InlineData(-2, 10)]
        [InlineData(0, 60)]
        public void Set_WrongSecondCycleFunc_ReturnFalse(int startTime, int endTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSecondCycle(startTime, endTime));

            Exception exception = Assert.Throws<Exception>(action);
        }


        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_SecondGap_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.SetSecondGap(gapTime, startTime);

            var instant = GetInstant;

            instant[0] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-2, 10)]
        [InlineData(0, 60)]
        public void Set_WrongSecondGap_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.SetSecondGap(gapTime, startTime);

            Exception exception = Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(12, 30)]
        public void Set_SecondGapFunc_ReturnTrue(int gapTime, int startTime)
        {
            string result = CronExpressionHelper.Set(i => i.SetSecondGap(gapTime, startTime));

            var instant = GetInstant;

            instant[0] = $"{startTime}/{gapTime}";

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-2, 10)]
        [InlineData(0, 60)]
        public void Set_WrongSecondGapFunc_ReturnFalse(int gapTime, int startTime)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSecondGap(gapTime, startTime));

            Exception exception = Assert.Throws<Exception>(action);
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 12, 24, 48)]
        public void Set_SpecificSecond_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.SetSpecificSecond(input);

            var instant = GetInstant;

            instant[0] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-2, 0, 2, 3)]
        [InlineData(0, 12, 24, 60)]
        public void Set_WrongSpecificSecond_ReturnTrue(params int[] input)
        {
            Action action = () => CronExpressionHelper.SetSpecificSecond(input);

            Exception exception = Assert.Throws<IndexOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(0, 1, 2, 3)]
        [InlineData(0, 12, 24, 48)]
        public void Set_SpecificSecondFunc_ReturnTrue(params int[] input)
        {
            string result = CronExpressionHelper.Set(i => i.SetSpecificSecond(input));

            var instant = GetInstant;

            instant[0] = string.Join(",", input);

            Assert.Equal(string.Join(" ", instant), result);
        }

        [Theory]
        [InlineData(-2, 0, 2, 3)]
        [InlineData(0, 12, 24, 60)]
        public void Set_WrongSpecificSecondFunc_ReturnTrue(params int[] input)
        {
            Action action = () => CronExpressionHelper.Set(i => i.SetSpecificSecond(input));

            Exception exception = Assert.Throws<IndexOutOfRangeException>(action);
        }
    }
}
