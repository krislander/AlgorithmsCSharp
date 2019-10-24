using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Graph
    {
        private int Vertices { get; set; }
        private List<int>[] adj { get; set; }

        public Graph(int v) {
            Vertices = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            this.adj[v].Add(w);
        }

        public void BFS(int s)
        {
            bool[] visited = new bool[Vertices];

            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                Console.WriteLine($"next element: {s}");

                foreach (int next in adj[s])
                {
                    if(!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
            }
        }

        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];

            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine($"next element: {s}");
                foreach (int next in adj[s])
                {
                    if (!visited[next])
                    {
                        visited[next] = true;
                        stack.Push(next);
                    }
                }
            }
        }

        public void printMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write($"{i}:[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + ( k + "," );
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
    }
}
