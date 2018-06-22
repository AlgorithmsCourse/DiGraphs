using System.Collections.Generic;

namespace DirectionalGraphs
{
    //determines reachability of a vertex from the source vertex
    class DirectedDFS
    {
        //tracks what V's have been visited
        bool[] _marked;

        //inits the DS and calls the main processing method to start
        public DirectedDFS(DiGraph G, int s)
        {
            _marked = new bool[G.V];
            dfs(G, s);

        }
        
        public DirectedDFS(DiGraph G, IEnumerable<int> sources)
        {
            _marked = new bool[G.V];
            foreach(var s in sources)
            {
                if (!_marked[s])
                {
                    dfs(G, s);
                }
            }
        }

        //internal recursive processing method
        private void dfs(DiGraph G, int v)
        {
            _marked[v] = true;
            foreach(var w in G.Adj(v))
            {
                if (!_marked[w])
                {
                    dfs(G, w);
                }
            }
        }

        public bool Marked(int v) => _marked[v];

    }
}
