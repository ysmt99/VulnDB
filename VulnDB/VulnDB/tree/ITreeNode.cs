using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDfmContext.tree
{
    /// <summary>
    /// ツリー構造のインターフェース
    /// </summary>
    public interface ITreeNode<T>
    {
        T Parent { get; set; }
        IList<T> Children { get; set; }

        T AddChild(T child);
        T RemoveChild(T child);
        bool TryRemoveChild(T child);
        T ClearChildren();
        bool TryRemoveOwn();
        T RemoveOwn();
    }
}
