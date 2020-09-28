using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronScheduleDemo
{
    /// <summary>
    /// Cron表达式生成
    /// </summary>
    public static class CronExpressionHelper
    {
        public static CronScheduleTime GetInstant => new CronScheduleTime();

        #region 秒
        /// <summary>
        /// 指定分钟内的具体秒周期，从startTime开始，endTime结束,默认每秒执行一次
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetSecondCycle(int startTime, int endTime)
        {
            return SetSecondCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定分钟内的执行间隔时间gapTime，延后开始时间startTime，默认为0
        /// </summary>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string SetSecondGap(int gapTime, int startTime = 0)
        {
            return SetSecondGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一分钟里的具体秒，每经过该秒执行一次
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string SetSpecificSecond(params int[] seconds)
        {
            return SetSpecificSecond(GetInstant, seconds).Result;
        }

        #endregion

        #region 分
        /// <summary>
        /// 指定小时内的具体分钟周期，从startTime开始，endTime结束,默认每秒执行一次
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetMinuteCycle(int startTime, int endTime)
        {
            return SetMinuteCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定小时内的具体分钟周期，从startTime开始，endTime结束,默认每分钟执行一次
        /// </summary>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string SetMinuteGap(int gapTime, int startTime = 0)
        {
            return SetMinuteGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一小时里的具体分钟，每经过该分钟执行一次,秒默认为0
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static string SetSpecificMinute(params int[] minutes)
        {
            return SetSpecificMinute(GetInstant, minutes).Result;
        }

        #endregion

        #region 小时
        /// <summary>
        /// 指定一天内的具体小时周期，从startTime开始，endTime结束,默认每小时0分0秒执行一次
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetHourCycle(int startTime, int endTime)
        {
            return SetHourCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定一天内的执行间隔时间gapTime，延后开始时间startTime，默认为0分0秒
        /// </summary>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string SetHourGap(int gapTime, int startTime = 0)
        {
            return SetHourGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一天里的具体小时，每经过该小时执行一次,默认0分0秒
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static string SetSpecificHour(params int[] hours)
        {
            return SetSpecificHour(GetInstant, hours).Result;
        }

        #endregion

        #region 天
        /// <summary>
        /// 指定一个月内的具体日期，从startTime开始，endTime结束,默认每天0时0分0秒执行一次
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetDayCycle(int startTime, int endTime)
        {
            return SetDayCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定一个月内的执行间隔时间gapTime，延后开始时间startTime，默认为0时0分0秒
        /// </summary>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string SetDayGap(int gapTime, int startTime = 0)
        {
            return SetDayGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一个月里的具体日期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public static string SetSpecificDay(params int[] days)
        {
            return SetSpecificDay(GetInstant, days).Result;
        }

        /// <summary>
        /// 指定一个月里的最后一天，默认该日期的0时0分0秒
        /// </summary>
        /// <returns></returns>
        public static string SetLastDayOfMonth()
        {
            return SetLastDayOfMonth(GetInstant).Result;
        }
        #endregion

        #region 月份
        /// <summary>
        /// 指定一年内的具体月份，从startTime开始，endTime结束,默认每个月1号0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetMonthCycle(int startTime, int endTime)
        {
            return SetMonthCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定一年内的执行间隔时间gapTime，延后开始时间startTime，默认为每个月1号0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="gapTime">间隔时间[1-12]</param>
        /// <param name="startTime">延后开始时间[1-12]</param>
        public static string SetMonthGap(int gapTime, int startTime = 1)
        {
            return SetMonthGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一年内里的具体月份，每经过该月份执行一次,默认该月份的1号0时0分0秒
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public static string SetSpecificMonth(params int[] months)
        {
            return SetSpecificMonth(GetInstant, months).Result;
        }
        #endregion

        #region 星期
        /// <summary>
        /// 指定一个礼拜的具体星期，从startTime开始，endTime结束,默认每日0时0分0秒执行一次
        /// </summary>
        /// <param name="startTime">有效值1-7</param>
        /// <param name="endTime">有效值1-7</param>
        /// <returns></returns>
        public static string SetWeekCycle(int startTime, int endTime)
        {
            return SetWeekCycle(GetInstant, startTime, endTime).Result;
        }

        /// <summary>
        /// 指定一个礼拜的具体星期，从startTime开始，endTime结束,默认每日0时0分0秒执行一次
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static string SetWeekCycle(ScheduleDayOfWeek startTime, ScheduleDayOfWeek endTime)
        {
            return SetWeekCycle(GetInstant, (int)startTime, (int)endTime).Result;
        }

        /// <summary>
        /// 指定一个月内的执行间隔时间gapTime，延后开始时间startTime，默认为每周星期天0时0分0秒
        /// </summary>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static string SetWeekGap(int gapTime, int startTime = 1)
        {
            return SetWeekGap(GetInstant, gapTime, startTime).Result;
        }

        /// <summary>
        /// 指定一个礼拜里的具体星期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="weekDays"></param>
        /// <returns></returns>
        public static string SetSpecificWeek(params int[] weekDays)
        {
            return SetSpecificWeek(GetInstant, weekDays).Result;
        }

        /// <summary>
        /// 指定一个礼拜里的具体星期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="weekDays"></param>
        /// <returns></returns>
        public static string SetSpecificWeek(params ScheduleDayOfWeek[] weekDays)
        {
            return SetSpecificWeek(GetInstant, weekDays).Result;
        }

        /// <summary>
        /// 指定一个月里的第几个星期的星期几，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="week">指定的具体星期，1-5</param>
        /// <param name="weekDay">具体星期几，1-7，星期天为1</param>
        /// <returns></returns>
        public static string SetSpecificWeek(int week, int weekDay)
        {
            return SetSpecificWeek(GetInstant, week, weekDay).Result;
        }

        /// <summary>
        /// 指定一个月里的第几个星期的星期几，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="week">指定的具体星期</param>
        /// <param name="weekDay">具体星期几</param>
        /// <returns></returns>
        public static string SetSpecificWeek(ScheduleWeek week, ScheduleDayOfWeek weekDay)
        {
            return SetSpecificWeek(GetInstant, week, weekDay).Result;
        }

        /// <summary>
        /// 指定一个月里最后一个星期的具体日期,默认该日期的0时0分0秒执行
        /// </summary>
        public static string SetLastDayOfWeek(ScheduleDayOfWeek weekDay)
        {
            return SetLastDayOfWeek(GetInstant, (int)weekDay).Result;
        }

        /// <summary>
        /// 指定一个月里最后一个星期的具体日期,默认该日期的0时0分0秒执行
        /// </summary>
        /// <param name="weekDay">有效值[1,7],周日为1</param>
        public static string SetLastDayOfWeek(int weekDay)
        {
            return SetLastDayOfWeek(GetInstant, weekDay).Result;
        }

        #endregion

        #region 

        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static string Set(params Func<CronScheduleTime, CronScheduleTime>[] actions)
        {
            CronScheduleTime result = GetInstant;

            Array.ForEach(actions, action => result = action(result));

            return result.Result;
        }

        /// <summary>
        /// 对单个时间单位进行配置
        /// 例：指定每分钟的第10秒执行 Set(i=>i.SetSpecificSecond(10))
        /// </summary>
        /// <param name="secondAction">对单个时间单位的配置</param>
        /// <returns></returns>
        public static string Set(Func<CronScheduleTime, CronScheduleTime> secondAction)
        {
            CronScheduleTime result = GetInstant;

            result = secondAction(result);

            return result.Result;
        }

        /// <summary>
        /// 对两个时间单位进行配置进行配置
        /// 例：指定每小时的10分30秒执行 Set(i=>i.SetSpecificMinute(10),i=>i.SetSpecificSecond(30))
        /// </summary>
        /// <param name="minuteConfig">对时间单位的配置</param>
        /// <param name="secondConfig">对时间单位的配置</param>
        /// <returns></returns>
        public static string Set(Func<CronScheduleTime, CronScheduleTime> minuteAction, Func<CronScheduleTime, CronScheduleTime> secondAction)
        {
            CronScheduleTime result = GetInstant;

            result = minuteAction(result);

            result = secondAction(result);

            return result.Result;
        }

        /// <summary>
        /// 对三个时间单位如小时，分钟和秒进行配置
        /// 例：指定每天1点10分30秒执行 Set(i=>i.SetSpecificHour(10),i=>i.SetSpecificMinute(10),i=>i.SetSpecificSecond(30))
        /// </summary>
        /// <param name="hourAction">对时间单位的配置</param>
        /// <param name="minuteAction">对时间单位的配置</param>
        /// <param name="secondAction">对时间单位的配置</param>
        /// <returns></returns>
        public static string Set(Func<CronScheduleTime, CronScheduleTime> hourAction, Func<CronScheduleTime, CronScheduleTime> minuteAction, Func<CronScheduleTime, CronScheduleTime> secondAction)
        {
            CronScheduleTime result = GetInstant;

            result = hourAction(result);

            result = minuteAction(result);

            result = secondAction(result);

            return result.Result;
        }

        /// <summary>
        /// 对四个时间单位如日期/星期，小时，分钟和秒进行配置
        /// 例：指定每个月的15号1点10分30秒执行 Set(i=>i.SetSpecificDay(15),i=>i.SetSpecificHour(10),i=>i.SetSpecificMinute(10),i=>i.SetSpecificSecond(30))
        /// </summary>
        /// <param name="dayAction">时间单位配置</param>
        /// <param name="hourAction">时间单位配置</param>
        /// <param name="minuteAction">时间单位配置</param>
        /// <param name="secondAction">时间单位配置</param>
        /// <returns></returns>
        public static string Set(Func<CronScheduleTime, CronScheduleTime> dayAction, Func<CronScheduleTime, CronScheduleTime> hourAction, Func<CronScheduleTime, CronScheduleTime> minuteAction, Func<CronScheduleTime, CronScheduleTime> secondAction)
        {
            CronScheduleTime result = GetInstant;

            result = dayAction(result);

            result = hourAction(result);

            result = minuteAction(result);

            result = secondAction(result);

            return result.Result;
        }

        /// <summary>
        /// 对五个时间单位如月份，日期/星期，小时，分钟和秒进行配置
        /// </summary>
        /// <param name="monthAction">月份配置</param>
        /// <param name="dayAction">日期/星期配置</param>
        /// <param name="hourAction">小时配置</param>
        /// <param name="minuteAction">分钟配置</param>
        /// <param name="secondAction">秒配置</param>
        /// <returns></returns>
        public static string Set(Func<CronScheduleTime, CronScheduleTime> monthAction, Func<CronScheduleTime, CronScheduleTime> dayAction, Func<CronScheduleTime, CronScheduleTime> hourAction, Func<CronScheduleTime, CronScheduleTime> minuteAction, Func<CronScheduleTime, CronScheduleTime> secondAction)
        {
            CronScheduleTime result = GetInstant;

            result = monthAction(result);

            result = dayAction(result);

            result = hourAction(result);

            result = minuteAction(result);

            result = secondAction(result);

            return result.Result;
        }

        #endregion

        #region 通用方法

        /// <summary>
        /// 指定分钟内的具体秒周期，从startTime开始，endTime结束,默认每秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSecondCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange() || endTime.IsOverDefaultRange() || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定分钟内的执行间隔时间gapTime，延后开始时间startTime，默认为0
        /// </summary>
        /// <returns></returns>
        public static CronScheduleTime SetSecondGap(this CronScheduleTime time, int gapTime, int startTime = 0)
        {
            if (gapTime.IsOverDefaultRange()) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange()) throw new Exception("设置的延后开始时间异常");

            time.Second = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一分钟里的具体秒，每经过该秒执行一次
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificSecond(this CronScheduleTime time, params int[] seconds)
        {
            Array.ForEach(seconds, i =>
            {
                if (i.IsOverDefaultRange()) throw new IndexOutOfRangeException($"设置的秒参数{i}异常");
            });

            time.Second = string.Join(",", seconds);

            return time;
        }

        /// <summary>
        /// 指定小时内的具体分钟周期，从startTime开始，endTime结束,默认每分钟0秒执行一次
        /// </summary>
        /// <returns></returns>
        public static CronScheduleTime SetMinuteCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange() || endTime.IsOverDefaultRange() || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定小时内的执行间隔时间gapTime，延后开始时间startTime，默认为0
        /// </summary>
        /// <returns></returns>
        public static CronScheduleTime SetMinuteGap(this CronScheduleTime time, int gapTime, int startTime = 0)
        {
            if (gapTime.IsOverDefaultRange()) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange()) throw new Exception("设置的延后开始时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一小时里的具体分钟，每经过该分钟执行一次,秒默认为0
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificMinute(this CronScheduleTime time, params int[] minutes)
        {
            Array.ForEach(minutes, i =>
            {
                if (i.IsOverDefaultRange()) throw new IndexOutOfRangeException($"设置的分钟参数{i}异常");
            });

            time.Second = time.Second.SetDefaultValue();

            time.Minute = string.Join(",", minutes);

            return time;
        }

        /// <summary>
        /// 指定一天内的具体小时周期，从startTime开始，endTime结束,默认每小时0分0秒执行一次
        /// </summary>
        /// <returns></returns>
        public static CronScheduleTime SetHourCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange(0, 23) || endTime.IsOverDefaultRange(0, 23) || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定一天内的执行间隔时间gapTime，延后开始时间startTime，默认为0分0秒
        /// </summary>
        /// <returns></returns>
        public static CronScheduleTime SetHourGap(this CronScheduleTime time, int gapTime, int startTime = 0)
        {
            if (gapTime.IsOverDefaultRange(0, 23)) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange(0, 23)) throw new Exception("设置的延后开始时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一天里的具体小时，每经过该小时执行一次,默认0分0秒
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificHour(this CronScheduleTime time, params int[] hours)
        {
            Array.ForEach(hours, i =>
            {
                if (i.IsOverDefaultRange(0, 23)) throw new IndexOutOfRangeException($"设置的小时参数{i}异常");
            });

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = string.Join(",", hours);

            return time;
        }

        /// <summary>
        /// 指定一个月内的具体日期，从startTime开始，endTime结束,默认每天0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetDayCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange(1, 31) || endTime.IsOverDefaultRange(1, 31) || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Week = "?";

            time.Day = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定一个月内的执行间隔时间gapTime，延后开始时间startTime，默认为0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetDayGap(this CronScheduleTime time, int gapTime, int startTime = 0)
        {
            if (gapTime.IsOverDefaultRange(1, 31)) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange(1, 31)) throw new Exception("设置的延后开始时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Week = "?";

            time.Day = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一个月里的具体日期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificDay(this CronScheduleTime time, params int[] days)
        {
            Array.ForEach(days, i =>
            {
                if (i.IsOverDefaultRange(1, 31)) throw new IndexOutOfRangeException($"设置的日期参数{i}异常");
            });

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Week = "?";

            time.Day = string.Join(",", days);

            return time;
        }

        /// <summary>
        /// 指定一个月里的最后一天
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static CronScheduleTime SetLastDayOfMonth(this CronScheduleTime time)
        {
            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Week = "?";

            time.Day = "L";

            return time;
        }

        /// <summary>
        /// 指定一年内的具体月份，从startTime开始，endTime结束,默认每个月1号0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetMonthCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange(1, 12) || endTime.IsOverDefaultRange(1, 12) || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.SetDayDefaultValue();

            time.Month = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定一年内的执行间隔时间gapTime，延后开始时间startTime，默认为每个月1号0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="gapTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetMonthGap(this CronScheduleTime time, int gapTime, int startTime = 1)
        {
            if (gapTime.IsOverDefaultRange(1, 12)) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange(1, 12)) throw new Exception("设置的延后开始时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.SetDayDefaultValue();

            time.Month = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一年内里的具体月份，每经过该月份执行一次,默认该月份的1号0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="months"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificMonth(this CronScheduleTime time, params int[] months)
        {
            Array.ForEach(months, i =>
            {
                if (i.IsOverDefaultRange(1, 12)) throw new IndexOutOfRangeException($"设置的日期参数{i}异常");
            });

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.SetDayDefaultValue();

            time.Month = string.Join(",", months);

            return time;
        }

        /// <summary>
        /// 指定一个礼拜的具体星期，从startTime开始，endTime结束,默认每日0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetWeekCycle(this CronScheduleTime time, ScheduleWeek startTime, ScheduleWeek endTime)
        {
            return time.SetWeekCycle((int)startTime, (int)endTime);
        }

        /// <summary>
        /// 指定一个礼拜的具体星期，从startTime开始，endTime结束,默认每日0时0分0秒执行一次
        /// </summary>
        /// <param name="time"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static CronScheduleTime SetWeekCycle(this CronScheduleTime time, int startTime, int endTime)
        {
            if (startTime.IsOverDefaultRange(1, 7) || endTime.IsOverDefaultRange(1, 7) || startTime > endTime)
                throw new Exception("设置的周期时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = $"{startTime}-{endTime}";

            return time;
        }

        /// <summary>
        /// 指定一个月内的执行间隔时间gapTime，延后开始时间startTime，默认为每周星期天0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="gapTime"></param>
        /// <param name="startTime">1-7 周日为1</param>
        /// <returns></returns>
        public static CronScheduleTime SetWeekGap(this CronScheduleTime time, int gapTime, int startTime = 1)
        {
            if (gapTime.IsOverDefaultRange(1, 5)) throw new Exception("设置的间隔时间异常");

            if (startTime.IsOverDefaultRange(1, 5)) throw new Exception("设置的延后开始时间异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = $"{startTime}/{gapTime}";

            return time;
        }

        /// <summary>
        /// 指定一个礼拜里的具体星期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="weekDay">1-7,星期日为1</param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificWeek(this CronScheduleTime time, params int[] weekDays)
        {
            Array.ForEach(weekDays, i =>
            {
                if (i.IsOverDefaultRange(1, 7)) throw new IndexOutOfRangeException($"设置的日期参数{i}异常");
            });

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = string.Join(",", weekDays);

            return time;
        }

        /// <summary>
        /// 指定一个礼拜里的具体星期，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="weekDay"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificWeek(this CronScheduleTime time, params ScheduleDayOfWeek[] weekDays)
        {
            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = string.Join(",", weekDays.Select(i => (int)i));

            return time;
        }

        /// <summary>
        /// 指定一个月里的第几个星期的星期几，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="week">指定的具体星期，1-5</param>
        /// <param name="weekDay">具体星期几，1-7，星期天为1</param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificWeek(this CronScheduleTime time, int week, int weekDay)
        {
            if (week.IsOverDefaultRange(1, 5)) throw new IndexOutOfRangeException($"设置的星期参数{week}异常");

            if (weekDay.IsOverDefaultRange(1, 7)) throw new IndexOutOfRangeException($"设置的具体星期参数{weekDay}异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = $"{week}#{weekDay}";

            return time;
        }

        /// <summary>
        /// 指定一个月里的第几个星期的星期几，每经过该日期执行一次,默认该日期的0时0分0秒
        /// </summary>
        /// <param name="time"></param>
        /// <param name="week"></param>
        /// <param name="weekDay"></param>
        /// <returns></returns>
        public static CronScheduleTime SetSpecificWeek(this CronScheduleTime time, ScheduleWeek week, ScheduleDayOfWeek weekDay)
        {
            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = $"{(int)week}#{(int)weekDay}";

            return time;
        }

        /// <summary>
        /// 指定一个月里最后一个星期的具体日期,默认该日期的0时0分0秒执行
        /// </summary>
        /// <param name="time"></param>
        /// <param name="weekDay"></param>
        /// <returns></returns>
        public static CronScheduleTime SetLastDayOfWeek(this CronScheduleTime time, ScheduleDayOfWeek weekDay)
        {
            return time.SetLastDayOfWeek((int)weekDay);
        }

        /// <summary>
        /// 指定一个月里最后一个星期的具体日期,默认该日期的0时0分0秒执行
        /// </summary>
        /// <param name="time"></param>
        /// <param name="weekDay">有效值[1,7],周日为1</param>
        /// <returns></returns>
        public static CronScheduleTime SetLastDayOfWeek(this CronScheduleTime time, int weekDay)
        {
            if (weekDay.IsOverDefaultRange(1, 7)) throw new IndexOutOfRangeException($"设置的具体星期参数{weekDay}异常");

            time.Second = time.Second.SetDefaultValue();

            time.Minute = time.Minute.SetDefaultValue();

            time.Hour = time.Hour.SetDefaultValue();

            time.Day = "?";

            time.Week = $"{weekDay}L";

            return time;
        }

        /// <summary>
        /// 设置默认方法
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private static string SetDefaultValue(this string time)
        {
            return time == "*" ? "0" : time;
        }

        /// <summary>
        /// 设置day的默认值
        /// </summary>
        /// <param name="time"></param>
        private static void SetDayDefaultValue(this CronScheduleTime time)
        {
            if (time.Week == "?")
            {
                time.Day = time.Day == "*" ? "1" : time.Day;
            }
            else
            {
                time.Day = "?";
            }
        }

        /// <summary>
        /// 设定的时间值是否越界
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        private static bool IsOverDefaultRange(this int time, int minValue = 0, int maxValue = 59)
        {
            return time < minValue || time > maxValue;
        }

        #endregion
    }

    /// <summary>
    /// 星期
    /// </summary>
    public enum ScheduleDayOfWeek
    {
        /// <summary>
        /// 星期天
        /// </summary>
        Sunday = 1,
        /// <summary>
        /// 星期一
        /// </summary>
        Monday = 2,
        /// <summary>
        /// 星期二
        /// </summary>
        Tuesday = 3,
        /// <summary>
        /// 星期三
        /// </summary>
        Wednesday = 4,
        /// <summary>
        /// 星期四
        /// </summary>
        Thursday = 5,
        /// <summary>
        /// 星期五
        /// </summary>
        Friday = 6,
        /// <summary>
        /// 星期六
        /// </summary>
        Saturday = 7
    }

    /// <summary>
    /// 周
    /// </summary>
    public enum ScheduleWeek
    {
        /// <summary>
        /// 第一周
        /// </summary>
        FirstWeek = 1,
        /// <summary>
        /// 第二周
        /// </summary>
        SecondWeek = 2,
        /// <summary>
        /// 第三周
        /// </summary>
        ThirdWeek = 3,
        /// <summary>
        /// 第四周
        /// </summary>
        FourthWeek = 4,
        /// <summary>
        /// 第五周
        /// </summary>
        FifthWeek = 5
    }

    public class CronScheduleTime
    {
        /// <summary>
        /// 秒
        /// </summary>
        public string Second { get; set; } = "*";
        /// <summary>
        /// 分钟
        /// </summary>
        public string Minute { get; set; } = "*";
        /// <summary>
        /// 小时
        /// </summary>
        public string Hour { get; set; } = "*";
        /// <summary>
        /// 天
        /// </summary>
        public string Day { get; set; } = "*";
        /// <summary>
        /// 月
        /// </summary>
        public string Month { get; set; } = "*";
        /// <summary>
        /// 星期
        /// </summary>
        public string Week { get; set; } = "?";
        /// <summary>
        /// 年
        /// </summary>
        public string Year { get; set; } = "*";

        public string Result
        {
            get
            {
                return string.Join(" ", Second, Minute, Hour, Day, Month, Week, Year);
            }
        }
    }
}
