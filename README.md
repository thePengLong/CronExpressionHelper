# CronExpressionHelper

​    Quartz 的Cron表达式生成帮助类，根据条件生成所需要的的Cron表达式，支持对秒，分，时，天，周和月的时间生成。

## 1.使用方法

仅一个帮助类的cs，复制到项目内使用。

## 2.生成表达式

### 2.1 间隔执行，以Gap结尾

```c#
//每10秒执行一次
string cronSecond= CronExpressionHelper.SetSecondGap(10);
//从每个小时的第5分钟起，每10分钟执行一次
string cronMinute=CronExpressionHelper.SetMinuteGap(10,5);
//每2小时执行一次
string cronHour=CronExpressionHelper.SetHourGap(2);
//每个月3天执行一次
string cronDay=CronExpressionHelper.SetDayGap(3);
//每个月的每1周执行一次
string cronWeek=CronExpressionHelper.SetWeekGap(1);
//每1个月执行执行一次
string cronMonth=CronExpressionHelper.SetMonthGap(1);
```

### 2.2 周期执行,以Cycle结尾

```c#
//每分钟第5秒到第10秒，每秒执行一次
string cronSecond=CronExpressionHelper.SetSecondCycle(5,10);
//每小时第6分钟到第8分钟，每分钟执行一次
string cronMinute=CronExpressionHelper.SetMinuteCycle(6,8);
//每天的12点到14点，每小时执行一次
string cronHour=CronExpressionHelper.SetHourCycle(12,14);
//每月的1号到3号，每天执行一次
string cronDay=CronExpressionHelper.SetDayCycle(1,3);
//每周的周一到周三，每天执行一次
string cronWeek=CronExpressionHelper.SetWeekCycle( ScheduleDayOfWeek.Monday,ScheduleDayOfWeek.Wednesday);
//每年的四月到五月，每月执行一次
string cronMonth=CronExpressionHelper.SetMonthCycle(4,5);
```

### 2.3 特定时间执行，多数带Specific

```c#
//在每分钟的第10秒执行一次
string cronSecond=CronExpressionHelper.SetSpecificSecond(10);
//在每小时的第3分钟和第5分钟，各执行一次
string cronMinute=CronExpressionHelper.SetSpecificMinute(3,5);
//在凌晨2点执行一次
string cronHour=CronExpressionHelper.SetSpecificHour(2);
//在每月15号执行一次
string cronDay=CronExpressionHelper.SetSpecificDay(15);
//在每周的周天执行一次
string cronWeek=CronExpressionHelper.SetSpecificWeek(ScheduleDayOfWeek.Sunday);
//6月份执行一次
string cronMonth=CronExpressionHelper.SetSpecificMonth(6);
//每月的最后一天执行一次
string cronLastDay=CronExpressionHelper.SetLastDayOfMonth();
//每个月最后一个星期的星期三执行
string cronLastWeek=CronExpressionHelper.SetLastDayOfWeek(ScheduleDayOfWeek.Wednesday);
```

### 2.4 自定义设定

#### 2.4.1 使用Set进行配置

```c#
//在每月的1日的凌晨2点调整任务
string cronResult = CronExpressionHelper.Set(i => i.SetSpecificDay(1), i => i.SetSpecificHour(2));
```

#### 2.4.2 使用扩展方式进行配置

```c#
//表示周一到周五每天上午10:15执行作业
CronScheduleTime cron = CronExpressionHelper.GetInstant;

string result = cron.SetWeekCycle(2, 5)
             .SetSpecificHour(10)
             .SetSpecificMinute(15)
             .Result;
```

### 2.5 例子

```c#
//每月的1日的凌晨2点调整任务
string coreResult= CronExpressionHelper.Set(i => i.SetSpecificDay(1), i => i.SetSpecificHour(2));

//每个星期三中午12点
string coreResult2 = CronExpressionHelper.Set(i => i.SetSpecificWeek(ScheduleDayOfWeek.Wednesday), i => i.SetSpecificHour(12));

//周一至周五的上午10:15触发 
string coreResult3= CronExpressionHelper.Set(i => i.SetWeekCycle(2,6), i => i.SetSpecificHour(10),i=>i.SetSpecificMinute(15));
```

