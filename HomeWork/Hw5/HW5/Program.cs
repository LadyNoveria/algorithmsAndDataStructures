using System;
using System.Collections.Generic;
namespace HW5
{
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
                if (value >= treeNode.Value)
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
                else if (value <= treeNode.Value)
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
        public void FillingRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    this.AddItem(rnd.Next(0, 50));
                }
                else
                    this.AddItem(rnd.Next(50, 100));
            }
        }
        //Поиск в глубину
        public TreeNode DFS(int value)
        {
            TreeNode currentNode = Head;
            var stack = new Stack<TreeNode>();
            stack.Push(currentNode);
            Console.WriteLine($"Добавляем в стек первый элемент дерева (Head): {currentNode.Value}");
            while (true)
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("Стек пустой.");
                    break;
                }
                var sValue = stack.Pop();
                Console.WriteLine($"Достаем из стека элемент: {sValue.Value}");
                if (sValue.Value == value)
                {
                    Console.WriteLine($"Элемент {sValue.Value} равен тому, что мы ищем. Завершаем выполнение метода и возвращаем ноду.");
                    return sValue;
                }
                if (sValue.LeftChild != null && sValue.RightChild != null)
                {
                    stack.Push(sValue.LeftChild);
                    stack.Push(sValue.RightChild);
                    Console.WriteLine($"Текущий элемент {sValue.Value} имеет обоих потомков: {sValue.LeftChild.Value} и {sValue.RightChild.Value}. Добавляем их в очередь.");
                }
                else if (sValue.LeftChild == null && sValue.RightChild != null)
                {
                    Console.WriteLine($"Текущий элемент {sValue.Value} имеет только правого потомка: {sValue.RightChild.Value}. Добавляем его в очередь.");
                    stack.Push(sValue.RightChild);
                }
                else if (sValue.LeftChild != null && sValue.RightChild == null)
                {
                    Console.WriteLine($"Текущий элемент {sValue.Value} имеет только левого потомка: {sValue.LeftChild.Value}. Добавляем его в очередь.");
                    stack.Push(sValue.LeftChild);
                }
                else
                    Console.WriteLine("Текущий элемент не имеет потомков");
                Console.WriteLine($"Текущий элемент {sValue.Value} не равен тому, что мы ищем.");

            }
            Console.WriteLine($"Элемент {value} в дереве не найден. Завершаем метод поиска и возвращаем NULL");
            return null;
        }
        //Поиск в ширину
        public TreeNode BFS(int value)
        {
            TreeNode currentNode = Head;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(currentNode);
            Console.WriteLine($"Добавляем в очередь первый элемент дерева (Head): {currentNode.Value}");
            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Очередь пустая.");
                    break;
                }
                var qValue = queue.Dequeue();
                Console.WriteLine($"Достаем из очереди элемент: {qValue.Value}");
                if (qValue.Value == value)
                {
                    Console.WriteLine($"Элемент {qValue.Value} равен тому, что мы ищем. Завершаем выполнение метода и возвращаем ноду.");
                    return qValue;
                }
                if (qValue.LeftChild != null && qValue.RightChild != null)
                {
                    queue.Enqueue(qValue.LeftChild);
                    queue.Enqueue(qValue.RightChild);
                    Console.WriteLine($"Текущий элемент {qValue.Value} имеет обоих потомков: {qValue.LeftChild.Value} и {qValue.RightChild.Value}. Добавляем их в очередь.");
                }
                else if (qValue.LeftChild == null && qValue.RightChild != null)
                {
                    Console.WriteLine($"Текущий элемент {qValue.Value} имеет только правого потомка: {qValue.RightChild.Value}. Добавляем его в очередь.");
                    queue.Enqueue(qValue.RightChild);
                }
                else if (qValue.LeftChild != null && qValue.RightChild == null)
                {
                    Console.WriteLine($"Текущий элемент {qValue.Value} имеет только левого потомка: {qValue.LeftChild.Value}. Добавляем его в очередь.");
                    queue.Enqueue(qValue.LeftChild);
                }
                else
                    Console.WriteLine("Текущий элемент не имеет потомков");
                Console.WriteLine($"Текущий элемент {qValue.Value} не равен тому, что мы ищем.");
            }
            Console.WriteLine($"Элемент {value} в дереве не найден. Завершаем метод поиска и возвращаем NULL");
            return null;
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
            /*Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль.*/

            var tree = new BinaryTree();
            //Заполнение дерева рандомными значениями
            tree.FillingRandom();
            Console.WriteLine("Полученное дерево");
            tree.PrintTree();
            int searchValue = 98;
            Console.WriteLine($"Ищем ноду с Value = {searchValue} методом BFS:");
            TreeNode nodeBFS = tree.BFS(searchValue);
            if (nodeBFS != null)
            {
                Console.WriteLine($"Найдент элемент:{nodeBFS.Value}");
                if (nodeBFS.RightChild != null && nodeBFS.LeftChild == null)
                    Console.WriteLine($"Найденный элемент имеет правого потомка: {nodeBFS.RightChild.Value}");
                else if (nodeBFS.LeftChild != null && nodeBFS.RightChild == null)
                    Console.WriteLine($"Найденный элемент имеет левого потомка: {nodeBFS.LeftChild.Value}");
                else if (nodeBFS.LeftChild != null && nodeBFS.RightChild != null)
                    Console.WriteLine($"Найденный элемент имеет обоих потомков: {nodeBFS.LeftChild.Value} и {nodeBFS.RightChild.Value}");
                else if (nodeBFS.RightChild == null && nodeBFS.LeftChild == null)
                    Console.WriteLine($"Найденный элемент не имеет потомков");
            }
            else
                Console.WriteLine("Элемент в дереве не найден.");

            searchValue = 7;
            Console.WriteLine();
            Console.WriteLine($"Ищем ноду с Value = {searchValue} методом DFS:");
            TreeNode nodeDFS = tree.DFS(searchValue);
            if (nodeDFS != null)
            {
                Console.WriteLine($"Найдент элемент:{nodeDFS.Value}");
                if (nodeDFS.RightChild != null && nodeDFS.LeftChild == null)
                    Console.WriteLine($"Найденный элемент имеет правого потомка: {nodeDFS.RightChild.Value}");
                else if (nodeDFS.LeftChild != null && nodeDFS.RightChild == null)
                    Console.WriteLine($"Найденный элемент имеет левого потомка: {nodeDFS.LeftChild.Value}");
                else if (nodeDFS.LeftChild != null && nodeDFS.RightChild != null)
                    Console.WriteLine($"Найденный элемент имеет обоих потомков: {nodeDFS.LeftChild.Value} и {nodeDFS.RightChild.Value}");
                else if (nodeDFS.RightChild == null && nodeDFS.LeftChild == null)
                    Console.WriteLine($"Найденный элемент не имеет потомков");
            }
            else
                Console.WriteLine("Элемент в дереве не найден.");
        }
    }
}
