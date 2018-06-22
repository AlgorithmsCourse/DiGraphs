using System;
using System.Collections.Generic;

namespace DirectionalGraphs
{ 
    //represents a Directional Graph where each set of Edges form a one way connection -- from v to w
    public class DiGraph
    {   
        //ctor takes num of V's and sets inits internal DSs
        private int _v;
        private int _e;
        LinkedList<int>[] _adj;

        DiGraph(int v)
        {
            _v = v;
            _adj = new LinkedList<int>[v];
            for(int i=0; i<v; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
        }


        //Entry point called from client and takes in internal information to parse and sets values to DSs/calls other ctor
        //input is string Array where [0] is num of Vs; [1] is num of Es; and remaining strings are V pairs repr a single directional edge
        public DiGraph(string[] input): this(Convert.ToInt32(input[0]))
        {
            for ( int i = 2; i < input.Length; i++)
            {
                string[] splitUp = input[i].Split();
                int v = Convert.ToInt32(splitUp[0]);
                int w = Convert.ToInt32(splitUp[1]);
                AddEdge(v, w);
                _e++;
            }
        }

        //Gets number of Vertices
        public int V => _v;
        //Gets number of Edges
        public int E => _e;

        //Adds a directed Edge v points to w
        private void AddEdge(int v, int w)
        {
            _adj[v].AddFirst(w);
        }
        //a V and list of all succeeding adj V's/pointing FROM indexed V; public/client access to private _adj field
        public IEnumerable<int> Adj(int v) => _adj[v];
 
        //creates and returns a new Digraph in reverse, listing all V's pointing TO the indexed v(preceding v's)
        public DiGraph Reverse()
        {
            DiGraph R = new DiGraph(_v);
            for(int i=0; i<_v; i++)
            {
                foreach(var w in _adj[i])
                {
                    R.AddEdge(w, i);
                    R._e++;
                }
            }
            return R;
        }



    }
    
}
