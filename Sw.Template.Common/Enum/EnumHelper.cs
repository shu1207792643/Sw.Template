using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Common
{
    public static class EnumHelper
    {
        /// <summary>
        /// log4net 日志等级类型枚举
        /// </summary>
        public enum Log4NetLevel
        {
            [Description("警告信息")]
            Warn = 1,
            [Description("调试信息")]
            Debug = 2,
            [Description("一般信息")]
            Info = 3,
            [Description("严重错误")]
            Fatal = 4,
            [Description("错误日志")]
            Error = 5
        }
        /// <summary>
        /// 弹窗枚举
        /// </summary>
        public enum OpenType
        {
            [Description("正常弹窗")]
            Show = 1,
            [Description("子窗口弹窗")]
            ShowDialog = 2
        }
    }
}
