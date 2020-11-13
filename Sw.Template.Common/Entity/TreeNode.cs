using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Common.Entity
{
    /// <summary>
    /// 树
    /// </summary>
    public class TreeNode
    {
        public int NodeID { get; set; }
        public int ParentID { get; set; }
        public string NodeName { get; set; }
        public List<TreeNode> Children { get; set; }
        public TreeNode()
        {
            Children = new List<TreeNode>();
        }
    }
}
