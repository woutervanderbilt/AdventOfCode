using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Models;

public class BinaryTreeNode<T>
    where T : IComparable<T>
{
    public T Value { get; set; }
    public BinaryTreeNode<T> LeftChild { get; set; }
    public BinaryTreeNode<T> RightChild { get; set; }
    public BinaryTreeNode<T> Parent { get; set; }
    public bool IsLeftChild { get; set; }

    public BinaryTreeNode<T> AddNode(T newValue)
    {
        var currentNode = this;
        BinaryTreeNode<T> previousNode = null;
        bool isSmaller = false;
        while (currentNode!= null)
        {
            isSmaller = currentNode.Value.CompareTo(newValue) >= 0;
            previousNode = currentNode;
            currentNode = isSmaller ? currentNode.LeftChild : currentNode.RightChild;
        }
        var newNode = new BinaryTreeNode<T>
        {
            Value = newValue,
            IsLeftChild = isSmaller,
            Parent = previousNode
        };
        if (isSmaller)
        {
            previousNode.LeftChild = newNode;
        }
        else
        {
            previousNode.RightChild = newNode;
        }

        return newNode;
    }

    public IEnumerable<BinaryTreeNode<T>> Traverse()
    {
        yield return this;
        if (LeftChild != null)
        {
            foreach (var binaryTreeNode in LeftChild.Traverse())
            {
                yield return binaryTreeNode;
            }
        }

        if (RightChild != null)
        {
            foreach (var binaryTreeNode in RightChild.Traverse())
            {
                yield return binaryTreeNode;
            }
        }
    }
}