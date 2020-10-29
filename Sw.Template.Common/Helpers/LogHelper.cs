using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sw.Template.Common.EnumHelper;

//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息  
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）  
//如果是WebForm，则从web.config中读取相关信息  
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Sw.Template.Common
{
    public static class LogHelper
    {
        /// <summary>
        /// 调用Log4net写日志，日志等级为 ：错误（Error）
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public static void WriteError(Object logContent)
        {
            WriteLog(null, logContent, Log4NetLevel.Error);
        }

        /// <summary>
        /// 调用Log4net写日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="log4Level">记录日志等级，枚举</param>
        public static void WriteLog(Object logContent, Log4NetLevel log4Level)
        {
            WriteLog(null, logContent, log4Level);
        }

        /// <summary>
        /// 调用Log4net写日志
        /// </summary>
        /// <param name="type">类的类型，指定日志中错误的具体类。例如：typeof(Index)，Index是类名，如果为空表示不指定类</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="log4Level">记录日志等级，枚举</param>
        public static void WriteLog(Type type, Object logContent, Log4NetLevel log4Level)
        {
            ILog log = type == null ? LogManager.GetLogger("") : LogManager.GetLogger(type);

            switch (log4Level)
            {
                case Log4NetLevel.Warn:
                    log.Warn(logContent);
                    break;
                case Log4NetLevel.Debug:
                    log.Debug(logContent);
                    break;
                case Log4NetLevel.Info:
                    log.Info(logContent);
                    break;
                case Log4NetLevel.Fatal:
                    log.Fatal(logContent);
                    break;
                case Log4NetLevel.Error:
                    log.Error(logContent);
                    break;
            }
        }

    }



}
