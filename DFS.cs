using System.Collections.Generic;
using System.Linq;

namespace Search_algorithms
{
    public class DFS
    {
        private readonly Stack<int> tree = new Stack<int>();
        private readonly List<int> visited;

        public DFS(List<int> visited)
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

            if (childrenNodes.Any() == false || childrenNodes.All(c => c.Visited == true))
            {
                if(tree.Count == 0) 
                {
                    return false;
                }

                return this.TransverseTree(graph, tree.Pop(), target);
            }

            tree.Push(source);
        
            foreach (Node node in childrenNodes)
            {
                if (!node.Visited)
                {
                    graph.MarkAsVisited(source, node.Location);
                    return this.TransverseTree(graph, node.Location, target);
                }
            }

            return false;
        } 
    }
}
