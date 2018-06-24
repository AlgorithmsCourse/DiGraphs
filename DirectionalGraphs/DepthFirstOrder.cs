using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace DirectionalGraphs
{
    class DepthFirstOrder
    {
        private Queue<int> _preOrder;
        private Queue<int> _postOrder;
        private Stack<int> _reversePostOrder;
        private bool[] _marked;

        public DepthFirstOrder(DiGraph g)
        {
            _marked = new bool[g.V];
            _preOrder = new Queue<int>();
            _postOrder = new Queue<int>();
            _reversePostOrder = new Stack<int>();
            for (int v = 0; v < g.V; v++)
            {
                if (!_marked[v])
                {
                    Dfs(g, v);
                }
            }
        }

        public Queue<int> PreOrder
        {
            get { return _preOrder; }
        }

        public Queue<int> PostOrder
        {
            get { return _postOrder; }
        }

        public Stack<int> ReversePostOrder
        {
            get { return _reversePostOrder; }
        }

        private void Dfs(DiGraph g, int v)
        {
            PreOrder.Enqueue(v);
            _marked[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (!_marked[w])
                {
                    Dfs(g,w);
                }
            }PostOrder.Enqueue(v);
            ReversePostOrder.Push(v);
        }
    }
}