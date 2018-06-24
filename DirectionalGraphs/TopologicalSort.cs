using System.Collections.Generic;

namespace DirectionalGraphs
{
    class TopologicalSort
    {
        private IEnumerable<int> _order;
        private bool[] _marked;

        public TopologicalSort(DiGraph g)
        {
            DirectedCycle Dc = new DirectedCycle(g);
            if (!Dc.HasCycle())
            {
                DepthFirstOrder dfo = new DepthFirstOrder(g);
                _order = dfo.ReversePostOrder;
            }
        }
       
        public bool IsDAG()
        {
            return (_order == null);
        }

        public IEnumerable<int> Order() => _order;
    }
}