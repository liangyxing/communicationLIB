using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDA.Entity
{
    public class DANodeInfo
    {
        /// <summary>
        /// OPCItem变量名称
        /// </summary>
        public string Tag_Name { get; set; }

        /// <summary>
        /// OPCItem地址
        /// </summary>
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

    /// <summary>
    /// CSV实体映射
    /// </summary>
    public class DANodeInfoMap : ClassMap<DANodeInfo>
    {
        public DANodeInfoMap()
        {
            Map(m => m.Tag_Name).Index(0).Name("Tag Name");
            Map(m => m.Address).Index(0).Name("Address");
        }
    }
}
