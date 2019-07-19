using System;
using System.Collections.Generic;
using System.Text;

namespace WebComponentStore.Models
{
    public class Dic_Detail
    {
        /// <summary>
        /// [主键][DicID]字典编号
        /// </summary>
        public int DicID { get; set; }

        /// <summary>
        /// [DicClassID]字典类别编号
        /// </summary>
        public int DicClassID { get; set; }

        /// <summary>
        /// [DictUseId]本身使用的ID
        /// </summary>
        public int DictUseId { get; set; }

        /// <summary>
        /// [DicName]字典名称 
        /// </summary>
        public string DicName { get; set; }

        /// <summary>
        /// [DicMemo]字典描述
        /// </summary>
        public string DicMemo { get; set; }


        /// <summary>
        /// [disorder]优先等级
        /// </summary>
        public int disorder { get; set; }

        /// <summary>
        /// [isdel]是否删除
        /// </summary>
        public int isdel { get; set; }
    }
}
