using System.Drawing;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Pathfinding
{
    internal class PathFinder
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Node[,] Nodes { get; set; }
        private Node StartNode { get; set; }
        private Node EndNode { get; set; }
        private NextStep searchParameters { get; set; }
        private Client Session { get; set; }
        private Scenery? Sala { get; set; }
        public PathFinder(NextStep searchParameters, Client Session)
        {
            this.searchParameters = searchParameters;
            InitializeNodes(searchParameters.Map);
            this.StartNode = this.Nodes[searchParameters.StartLocation.X, searchParameters.StartLocation.Y];
            this.StartNode.State = NodeState.Open;
            this.EndNode = this.Nodes[searchParameters.EndLocation.X, searchParameters.EndLocation.Y];
            this.Session = Session;
            this.Sala = Session.User?.Scenery;
        }
        public List<Point> FindPath()
        {
            List<Point> path = [];
            bool success = Search(StartNode);
            if (success)
            {
                Node node = this.EndNode;
                while (node.ParentNode != null)
                {
                    path.Add(node.Location);
                    node = node.ParentNode;
                }
                path.Reverse();
            }
            return path;
        }

        private void InitializeNodes(bool[,] map)
        {
            this.Width = map.GetLength(0);
            this.Height = map.GetLength(1);
            this.Nodes = new Node[this.Width, this.Height];
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.Nodes[x, y] = new Node(x, y, map[x, y], this.searchParameters.EndLocation);
                }
            }
        }
        private bool Search(Node currentNode)
        {
            currentNode.State = NodeState.Closed;
            List<Node> nextNodes = GetAdjacentWalkableNodes(currentNode);
            nextNodes.Sort((node1, node2) => node1.F.CompareTo(node2.F));
            foreach (var nextNode in nextNodes)
            {
                if (nextNode.Location == this.EndNode.Location)
                {
                    return true;
                }
                else
                {
                    if (Search(nextNode))
                        return true;
                }
            }
            return false;
        }
        private List<Node> GetAdjacentWalkableNodes(Node fromNode)
        {
            List<Node> walkableNodes = [];
            Point[] nextLocations = GetAdjacentLocations(fromNode.Location);
            foreach (var location in nextLocations)
            {
                Node node = this.Nodes[location.X, location.Y];
                if (
                    (location.X < 0 || location.X >= this.Width || location.Y < 0 || location.Y >= this.Height)
                    || !Sala.MapAreaObject.IsWalkable(node.Location.X, node.Location.Y)
                    || Sala.GetClientInPosition(new(node.Location.X, node.Location.Y)) != null
                    //|| !Sala.WalkByObjects(node.Location.X, node.Location.Y)
                    || node.State == NodeState.Closed
                    )
                {
                    continue;
                }

                if (node.State == NodeState.Open)
                {
                    float traversalCost = Node.GetTraversalCost(node.Location, node.ParentNode.Location);
                    float gTemp = fromNode.G + traversalCost;
                    if (gTemp < node.G)
                    {
                        node.ParentNode = fromNode;
                        walkableNodes.Add(node);
                    }
                }
                else
                {
                    node.ParentNode = fromNode;
                    node.State = NodeState.Open;
                    walkableNodes.Add(node);
                }
            }
            return walkableNodes;
        }

        private static Point[] GetAdjacentLocations(Point fromLocation)
        {
            return
            [
                new (fromLocation.X+1, fromLocation.Y+1),
                new (fromLocation.X-1, fromLocation.Y-1),
                new (fromLocation.X+1, fromLocation.Y),
                new (fromLocation.X, fromLocation.Y+1),
                new (fromLocation.X-1, fromLocation.Y),
                new (fromLocation.X, fromLocation.Y-1),
                new (fromLocation.X+1, fromLocation.Y-1),
                new (fromLocation.X-1, fromLocation.Y+1)
            ];
        }
    }
}
