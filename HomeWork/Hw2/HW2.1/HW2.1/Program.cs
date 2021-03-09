using System;

namespace hw2._1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
   
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }
    public class NodeLinkedList : ILinkedList
    {
        public Node startNode { get; set; }
        public Node endNode { get; set; }
        public int GetCount()
        {
            int count = 0;
            Node currentNode = startNode;
            while (true)
            {
                if (currentNode == null) {
                    break;
                }
                else if (currentNode.NextNode == null)
                {
                    count++;
                    break;
                }
                else
                {
                    count++;
                    currentNode = currentNode.NextNode;
                }
            }
            return count;
        }
        public void AddNode(int value)
        {
            Node node = new Node { Value = value };
            if (this.GetCount() == 0)
            {
                startNode = node;
            }
            else if (this.GetCount() == 1)
            {
                endNode = node;
                startNode.NextNode = endNode;
                endNode.PrevNode = startNode;
            }
            else
            {
                Node currentNode = startNode;
                while (true)
                {
                    if (currentNode.NextNode == null)
                    {
                        endNode = node;
                        currentNode.NextNode = endNode;
                        endNode.PrevNode = currentNode.PrevNode.NextNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                    }
                }
            }
        }
        public void AddNodeAfter(Node node, int value)
        {
            Node newNode = new Node { Value = value };
            if (node.NextNode == null)
            {
                node.NextNode = newNode;
                endNode = newNode;
                endNode.PrevNode = node;
            }
            else {
                node.NextNode.PrevNode = newNode;
                newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.PrevNode = node;
            }
        }
        public void RemoveNode(int index)
        {
            
            int currentIndex = 0;
            Node currentNode = startNode;
            while (true)
            {
                if (index == 0)
                {
                    startNode = currentNode.NextNode;
                    currentNode.NextNode.PrevNode = null;
                    currentNode.NextNode = null;
                    break;
                }
                else if (currentNode.NextNode == null && currentIndex == index)
                {
                    endNode = currentNode.PrevNode;
                    currentNode.PrevNode.NextNode = null;
                    endNode.NextNode = null;
                    break;
                }
                else if (currentNode.NextNode == null && currentIndex != index)
                {
                    break;
                }
                else if (index == currentIndex)
                {
                    Node nodePrevItem = currentNode.PrevNode;
                    Node nodeNextItem = currentNode.NextNode;
                    nodePrevItem.NextNode = nodeNextItem;
                    nodeNextItem.PrevNode = nodePrevItem;
                    currentNode.NextNode = null;
                    currentNode.PrevNode = null;
                    break;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }
            }
        }
        public void RemoveNode(Node node)
        {
            if (node == null)
            {
                return;
            }
            else if (node.NextNode == null)
            {
                endNode = node.PrevNode;
                node.PrevNode.NextNode = null;
            }
            else if (node.PrevNode == null)
            {
                startNode = node.NextNode;
                node.NextNode.PrevNode = null;
            }
            else
            {
                node.NextNode.PrevNode = node.PrevNode;
                node.PrevNode.NextNode = node.NextNode;
            }
        }
        public Node FindNode(int searchValue)
        {
            Node currentNode = startNode;
            while (true)
            {
                if (currentNode.Value == searchValue)
                {
                    return currentNode;
                }
                else if (currentNode.NextNode == null)
                {
                    break;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                }
            }
            return null;
        }
        public NodeLinkedList(int startValue, int endValue)
        {
            startNode = new Node { Value = startValue };
            endNode = new Node { Value = endValue };
            startNode.NextNode = endNode;
            endNode.PrevNode = startNode;
        }
        public NodeLinkedList()
        {

        }
        public void Output()
        {
            Node currentNode = startNode;
            int count = this.GetCount();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Требуется реализовать класс двусвязного списка и операции вставки, удаления и 
             * поиска элемента в нём в соответствии с интерфейсом.*/
            //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
            
            int[] arrayValues = {1, 78, 54, -85, 41, 0, 63, 4111, 7, -6};
            int[] checkArray = {78, 54, -85, 41, 0, 63, 4111, 7};
            NodeLinkedList startNode = new NodeLinkedList();

            //добавление элементов в список
            for (int i = 0; i < arrayValues.Length; i++)
            {
                startNode.AddNode(arrayValues[i]);
            }

            //Блок проверок
            int checkValue1 = 23333;
            int indexNodeRemove1 = 0;
            int indexNodeRemove2 = 9;
            int indexNodeRemove3 = 50;
            int indexNodeRemove4 = 666;
            int indexNodeRemove5 = 23333;
            //добавление ноды после другой ноды
            startNode.AddNodeAfter(startNode.FindNode(arrayValues[3]), checkValue1); 
            //удаление первой ноды
            startNode.RemoveNode(indexNodeRemove1); 
            //удаление последней ноды
            startNode.RemoveNode(indexNodeRemove2);
            //удаление не существующей ноды
            startNode.RemoveNode(indexNodeRemove3);
            //удаление ноды, найденной по не существующему значению
            startNode.RemoveNode(startNode.FindNode(indexNodeRemove4));
            //удаление ноды, найденной по существующему значению
            startNode.RemoveNode(startNode.FindNode(indexNodeRemove5)); 

            Console.WriteLine($"Number of list items: {startNode.GetCount()}. Expected value: {checkArray.Length}");
            Console.Write("Received LinkedList: ");
            startNode.Output();
            Console.Write("Expected values: ");
            for (int i = 0; i < checkArray.Length; i++) {
                Console.Write($"{checkArray[i]} ");
            }
            Console.ReadKey();
        }        
    }
}