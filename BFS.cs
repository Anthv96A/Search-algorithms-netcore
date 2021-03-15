using System.Collections.Generic;

namespace Search_algorithms
{
    public class BFS
    {
        
        private readonly Queue<int> tree = new Queue<int>();
        private readonly List<int> visited;

        public BFS(List<int> visited)
        {
            this.visited = visited;
        }

        public bool TransverseTree(Graph graph, int source, int target)
        {
            graph.MarkAsVisited(source);
            visited.Add(source);

            if (source == target)
            {
                return true;
            }

            IEnumerable<Node> childrenNodes = graph.GetChildrenNodes(source);

            foreach (Node node in childrenNodes)
            {
                if (!node.Visited)
                {
                    tree.Enqueue(node.Location);
                    graph.MarkAsVisited(source, node.Location);
                }
            }

            if(this.tree.Count == 0) 
            {
                return false;
            }
    
            return this.TransverseTree(graph, tree.Dequeue(), target);
        } 
    }
}
