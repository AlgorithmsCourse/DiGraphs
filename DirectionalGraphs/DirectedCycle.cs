using System;
using System.Collections;
using System.Collections.Generic;

namespace DirectionalGraphs
{
    //processes graph using DFS and returns a cycle if it has one
    public class DirectedCycle
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private Stack<int> _cycle;
        private bool[] _onStack;

        public DirectedCycle(DiGraph g)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _onStack = new Boolean[g.V];
            for (int i = 0; i < g.V; i++)
            {
                if (!_marked[i])
                {
                    Dfs(g, i);
                }
            }

        }

        private void Dfs(DiGraph g, int v)
        {
            _marked[v] = true;
            _onStack[v] = true;
            foreach (var w in g.Adj(v))
            {
                if (this.HasCycle())
                {
                    return;
                }
                else if (!_marked[w])
                {
                    Dfs(g, w);
                }else if (_onStack[w])
                {
                    _cycle = new Stack<int>();
                    for (int i = v; i == w; i = _edgeTo[i])
                    {
                        _cycle.Push(i);
                    }
                    _cycle.Push(w);
                    _cycle.Push(v);
                }

                _onStack[w] = false;
            }
        }

        public bool HasCycle()
        {
            return (_cycle != null);
        }

        IEnumerable<int> Cycle()
        {
            return _cycle;
        }
    }
}