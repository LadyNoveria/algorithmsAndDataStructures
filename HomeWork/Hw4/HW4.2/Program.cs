using System;
using System.Collections.Generic;
namespace Hw4._2
{
    public enum Side
    {
        Left, Right
    }
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            if (node == null)
                return false;
            return node.Value == Value;
        }
    }                        
    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
    public class BinaryTree : ITree
    {
        public TreeNode Head { get; set; }
        public TreeNode GetRoot()
        {
            return Head;
        }
        public void AddItem(int value)
        {
            if (Head == null)
            {
                Head = new TreeNode() { Value = value };
                return;
            }
            TreeNode treeNode = Head;
            while (treeNode != null)
            {
                if (value > treeNode.Value)
                {
                    if (treeNode.RightChild != null)
                    {
                        treeNode = treeNode.RightChild;
                        continue;
                    }
                    else
                    {
                        treeNode.RightChild = new TreeNode() { Value = value, Parent = treeNode };
                        break;
                    }
                }
                else if (value < treeNode.Value)
                {
                    if (treeNode.LeftChild != null)
                    {
                        treeNode = treeNode.LeftChild;
                        continue;
                    }
                    else
                    {
                        treeNode.LeftChild = new TreeNode() { Value = value, Parent = treeNode };
                        break;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");
                }
            }
        }
        public void RemoveItem(int value)
        {
            TreeNode treeNode = Head;
            if (treeNode.Value == value)
            {
                TreeNode currentNode = treeNode.RightChild;
                while (currentNode.LeftChild != null)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }
                //изменяем ссылки в узлах до и после минимального
                if (currentNode.RightChild != null)
                {
                    currentNode.RightChild.Parent = currentNode.Parent;
                    currentNode.Parent.LeftChild = currentNode.RightChild;
                }
                else
                {
                    currentNode.Parent.LeftChild = null;
                }
                //изменяем родителя минимального узла
                currentNode.Parent = treeNode.Parent;

                //меняем ссылку на ролителя у потомков удаляемого узла
                treeNode.RightChild.Parent = currentNode;
                treeNode.LeftChild.Parent = currentNode;
                //указываем ссылки на потомков treeNode новому узлу
                currentNode.RightChild = treeNode.RightChild;
                currentNode.LeftChild = treeNode.LeftChild;
                Head = currentNode;
                return;
            }
            while (true)
            {
                if (value > treeNode.Value)
                {
                    treeNode = treeNode.RightChild;
                    continue;
                }
                else if (value < treeNode.Value)
                {
                    treeNode = treeNode.LeftChild;
                    continue;
                }
                else if (value == treeNode.Value && treeNode.LeftChild == null)
                {
                    treeNode.RightChild.Parent = treeNode.Parent;
                    treeNode.Parent.LeftChild = treeNode.RightChild;
                    break;
                }
                else if (value == treeNode.Value && treeNode.RightChild == null)
                {
                    treeNode.LeftChild.Parent = treeNode.Parent;
                    treeNode.Parent.RightChild = treeNode.LeftChild;
                    break;
                }
                else if (value == treeNode.Value && treeNode.LeftChild == null && treeNode.RightChild == null)
                {
                    if (treeNode.Parent.LeftChild == treeNode)
                    {
                        treeNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        treeNode.Parent.RightChild = null;
                    }
                    treeNode.Parent = null;
                    break;
                }
                else if (value == treeNode.Value && treeNode.LeftChild != null && treeNode.RightChild != null)
                {
                    TreeNode currentNode = treeNode.RightChild;
                    while (currentNode.LeftChild != null)
                    {
                        if (currentNode.LeftChild != null)
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    //изменяем ссылки в узлах до и после минимального
                    if (currentNode.RightChild != null)
                    {
                        currentNode.RightChild.Parent = currentNode.Parent;
                        currentNode.Parent.LeftChild = currentNode.RightChild;
                    }
                    else
                    {
                        currentNode.Parent.LeftChild = null;
                    }
                    //изменяем родителя минимального узла
                    currentNode.Parent = treeNode.Parent;
                    //новая ссылка у родителя treeNode
                    if (treeNode.Parent.LeftChild == treeNode)
                    {
                        treeNode.Parent.LeftChild = currentNode;
                    }
                    else
                    {
                        treeNode.Parent.RightChild = currentNode;
                    }
                    //меняем ссылку на ролителя у потомков удаляемого узла
                    treeNode.RightChild.Parent = currentNode;
                    treeNode.LeftChild.Parent = currentNode;
                    //указываем ссылки на потомков treeNode новому узлу
                    currentNode.RightChild = treeNode.RightChild;
                    currentNode.LeftChild = treeNode.LeftChild;
                    break;
                }
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            TreeNode treeNode = Head;
            if (treeNode.Value == value)
            {
                return treeNode;
            }
            while (treeNode != null)
            {
                if (value > treeNode.Value)
                {
                    treeNode = treeNode.RightChild;
                    continue;
                }
                else if (value < treeNode.Value)
                {
                    treeNode = treeNode.LeftChild;
                    continue;
                }
                else if (value == treeNode.Value)
                {
                    return treeNode;
                }
            }
            return null;
        }
        public void PrintTree()
        {
            NodeInfo[] output = TreeHelper.GetTreeInLine(this);
            
            for (int i = 0; i < output.Length; i++)
            {
                string depthString = " ";
                for (int j = 0; j < output[i].Depth; j++)
                {
                    depthString += "   ";
                }
                Console.WriteLine($"{depthString}{output[i].Node.Value}");
            }
        }
    }
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);
            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);
                var depth = element.Depth + 1;
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }
            return returnArray.ToArray();
        }
    }
    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Реализуйте класс двоичного дерева поиска с операциями вставки, удаления, поиска.
            * Дерево должно быть сбалансированным (это требование не обязательно). Также напишите метод вывода в консоль дерева,
            * чтобы увидеть, насколько корректно работает ваша реализация. */
            int[] arrayValues = { 40, 30, 32, 15, 72, 51, 84, 76, 90, 89, 93, 77, 78, 10, 24, 38, 64, 49, 18, 3, 21};
            BinaryTree tree = new BinaryTree();
            for (int i = 0; i < arrayValues.Length; i++)
            {
                tree.AddItem(arrayValues[i]);
            }
            tree.RemoveItem(72); //удаление узла, в котором есть оба потомка
            tree.RemoveItem(40); //удаление корневого узла
            int[] arrayVerifications = { 49, 30, 76, 15, 32, 51, 84, 10, 24, 38, 64, 77, 90, 3, 18, 78, 89, 93, 21};
            Console.WriteLine("The resulting tree after deleting nodes 72 and 40");
            tree.PrintTree();
            Console.WriteLine("Expected result");
            for (int i = 0; i < arrayVerifications.Length; i++)
            {
                Console.Write($"{arrayVerifications[i]}  ");
            }
            Console.WriteLine();
            TreeNode headRight = tree.GetNodeByValue(49); //получение корневого узла
            Console.WriteLine($"Right child of Node {headRight.Value}: {headRight.RightChild.Value}. Expected value: 76");
            Console.WriteLine($"Left child of Node {headRight.Value}: {headRight.LeftChild.Value}. Expected value: 30");
        }
    }
}