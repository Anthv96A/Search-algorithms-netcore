using System;
using System.Collections.Generic;

namespace Search_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            // *               1
            // *             / | \ \
            // *            2  5  9  13
            // *           /  / \   \
            // *          3  6   8   10
            // *         /  /       /   \  
            // *        4  7       11   12
            // *
            // * 
  
            var graph = new Graph();
            graph.AddNode(1, 2);
            graph.AddNode(1, 5);
            graph.AddNode(1, 9);
            graph.AddNode(1, 13);

            graph.AddNode(2, 3);

            graph.AddNode(3, 4);
       
            graph.AddNode(5, 6);
            graph.AddNode(5, 8);

            graph.AddNode(6, 7);
       
            graph.AddNode(9, 10);

            graph.AddNode(10, 11);
            graph.AddNode(10, 12);
            
            var visited = new List<int>();
            var bfs = new BFS(visited);
            int target = 133;

            bool found = bfs.TransverseTree(graph, 1, target);
            string sfound = found ? "was" : "wasn't";

            Console.WriteLine($"Node {target} {sfound} found ");

            foreach (int location in visited)
            {
                Console.WriteLine($"Node Visited -> {location}");
            }
        }
    }
}
