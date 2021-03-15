using System.Collections.Generic;
using System.Linq;

namespace Search_algorithms
{
    public class Graph
    {
        private readonly IDictionary<int, Node> rootNodes;
        private readonly IDictionary<int, HashSet<Node>> childNodes;

        public Graph()
        {
            this.rootNodes = new Dictionary<int, Node>();
            this.childNodes = new Dictionary<int, HashSet<Node>>();
        }

        public void AddNode(int root, int child)
        {
            if (this.childNodes.TryGetValue(root, out HashSet<Node> children))
            {
                children.Add(new Node { Location = child, Visited = false });
            }
            else
            {
                this.childNodes.Add(root, new HashSet<Node> { new Node { Location = child, Visited = false } });
                this.rootNodes.Add(root, new Node { Location = root, Visited = false });
            }
        }

        public IEnumerable<Node> GetChildrenNodes(int root)
        {
            if (this.childNodes.TryGetValue(root, out HashSet<Node> children))
            {
                return children;
            }

            return Enumerable.Empty<Node>();
        }

        public void MarkAsVisited(int root)
        {
            if (this.rootNodes.TryGetValue(root, out Node currentRoot))
            {
                currentRoot.Visited = true;
            }
        }

        public void MarkAsVisited(int root, int child)
        {
            if (this.childNodes.TryGetValue(root, out HashSet<Node> children) && children.TryGetValue(c => c.Location == child, out Node toUpdate))
            {
                toUpdate.Visited = true;
            }
        }
    }
}
