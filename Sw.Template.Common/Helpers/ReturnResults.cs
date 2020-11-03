using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Common
{
    public class ReturnResults
    {
        /// <summary>
        /// 后台消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// //返回状态
        /// </summary>
        public int StatusCode { get; set; }

        public object Result { get; set; }
    }
}
