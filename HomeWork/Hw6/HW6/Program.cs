using System;
using System.Collections.Generic;

namespace HW6
{
    public class Node
    {
        public string Value { get; set; }
        public List<Edge> Edges = new List<Edge>(); //исходящие связи
        public bool Status { get; set; }
        public override bool Equals(object obj)
        {
            var node = obj as Node;
            if (node == null)
                return false;
            return node.Value == Value;
        }
    }

    public class Edge
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } //узел, на который связь ссылается
    }

    public class GraphTraversal
    {
        public Node Head { get; set; }
        //обход графа в ширину
        public GraphTraversal(Node node)
        {
            Head = node;
        }
        public void BFS()
        {
            Node currentNode = Head;
            List<Node> visitedNodes = new List<Node> { currentNode };
            Console.WriteLine($"Добавляем стартовую вершину {Head.Value} в массив посещенных узлов.");

            var queue = new Queue<Node>();

            queue.Enqueue(currentNode);
            Console.WriteLine($"Добавляем узел {currentNode.Value} в очередь.");

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Все узлы просмотрены.");
                    break;
                }

                var qValue = queue.Dequeue();
                Console.WriteLine($"Достаем из очереди узел {qValue.Value}.");
                Console.WriteLine($"Проверяем его смежные узлы на присутствие в массиве посещеных узлов.");
                Node[] nodes = new Node[qValue.Edges.Count];
                Node[] nodesVisited = new Node[visitedNodes.Count];
                int index = 0;
                foreach (var node in qValue.Edges) {
                    nodes[index] = node.Node;
                    index++;
                }
                index = 0;
                foreach (var node in visitedNodes)
                {
                    nodesVisited[index] = node;
                    index++;
                }

                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < nodesVisited.Length;j++)
                    {
                        if (nodes[i].Equals(nodesVisited[j]))
                        {
                            Console.WriteLine($"Смежный узел {nodes[i].Value} найден в массиве посещенных узлов. ");
                            Console.WriteLine("Ничего не делаем.");
                            break;
                        }
                        else {
                            if (j == nodesVisited.Length - 1)
                            {
                                Console.WriteLine($"Смежный узел {nodes[i].Value} не найден в массиве посещенных узлов. Добавляем его в массив и в очередь.");
                                queue.Enqueue(nodes[i]);
                                visitedNodes.Add(nodes[i]);
                            }
                        }
                    }
                }
                Console.WriteLine($"");
            }
        }
        //обход графа в глубину
        public void DFS()
        {
            Node currentNode = Head;
            List<Node> visitedNodes = new List<Node> { currentNode };
            Console.WriteLine($"Добавляем стартовую вершину {Head.Value} в массив посещенных узлов.");

            var stack = new Stack<Node>();

            stack.Push(currentNode);
            Console.WriteLine($"Добавляем узел {currentNode.Value} в очередь.");

            while (true)
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("Все узлы просмотрены.");
                    break;
                }

                var qValue = stack.Pop();
                Console.WriteLine($"Достаем из очереди узел {qValue.Value}.");
                Console.WriteLine($"Проверяем его смежные узлы на присутствие в массиве посещеных узлов.");
                Node[] nodes = new Node[qValue.Edges.Count];
                Node[] nodesVisited = new Node[visitedNodes.Count];
                int index = 0;
                foreach (var node in qValue.Edges)
                {
                    nodes[index] = node.Node;
                    index++;
                }
                index = 0;
                foreach (var node in visitedNodes)
                {
                    nodesVisited[index] = node;
                    index++;
                }

                for (int i = 0; i < nodes.Length; i++)
                {
                    for (int j = 0; j < nodesVisited.Length; j++)
                    {
                        if (nodes[i].Equals(nodesVisited[j]))
                        {
                            Console.WriteLine($"Смежный узел {nodes[i].Value} найден в массиве посещенных узлов. ");
                            Console.WriteLine("Ничего не делаем.");
                            break;
                        }
                        else
                        {
                            if (j == nodesVisited.Length - 1)
                            {
                                Console.WriteLine($"Смежный узел {nodes[i].Value} не найден в массиве посещенных узлов. Добавляем его в массив и в очередь.");
                                stack.Push(nodes[i]);
                                visitedNodes.Add(nodes[i]);
                            }
                        }
                    }
                }
                Console.WriteLine($"");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node A = new Node() { Value = "A", Status = false };
            Node B = new Node() { Value = "B", Status = false };
            Node C = new Node() { Value = "C", Status = false };
            Node D = new Node() { Value = "D", Status = false };
            Node E = new Node() { Value = "E", Status = false };
            Node F = new Node() { Value = "F", Status = false };
            A.Edges.Add(new Edge() { Weight = 5, Node = B });
            A.Edges.Add(new Edge() { Weight = 8, Node = C });
            C.Edges.Add(new Edge() { Weight = 1, Node = B });
            C.Edges.Add(new Edge() { Weight = 2, Node = D });
            C.Edges.Add(new Edge() { Weight = 1, Node = F });
            B.Edges.Add(new Edge() { Weight = 4, Node = E });
            B.Edges.Add(new Edge() { Weight = 3, Node = D });
            D.Edges.Add(new Edge() { Weight = 9, Node = E });
            E.Edges.Add(new Edge() { Weight = 9, Node = D });
            E.Edges.Add(new Edge() { Weight = 5, Node = F });
            F.Edges.Add(new Edge() { Weight = 5, Node = C });
            GraphTraversal graph = new GraphTraversal(A);
            graph.BFS();
            graph.DFS();
        }
    }
}