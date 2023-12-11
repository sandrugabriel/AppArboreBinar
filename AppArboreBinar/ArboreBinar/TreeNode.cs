using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArboreBinar.ArboreBinar
{
    public class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
    {

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public T Data { get; set; }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Data.CompareTo(other.Data);
        }
    }
}
