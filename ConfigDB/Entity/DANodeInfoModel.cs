using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDB.Entity
{
    public class DANodeInfoModel
    {
        /// <summary>
        /// OPCItem变量名称
        /// </summary>
        
        public int Id { get; set; }
        public string MachineName { get; set; }


        /// <summary>
        /// OPCItem地址
        /// </summary>
        /// 
        public string Tag_Name { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 读取回来的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// OPCItem时间戳
        /// </summary>
        public string Time { get; set; }
    }
}
