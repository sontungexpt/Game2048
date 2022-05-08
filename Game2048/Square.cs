using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal class Square : Rectangle
    {
        private int edge;
        //constructor
        public Square() : base()
        {
            this.edge = 0;
        }
        public Square(int edge) : base(edge, edge)
        {
            this.edge = edge;
        }
        public Square(Coord origin) : base(origin) { }
        public Square(int edge, Coord origin) : base(edge, edge, origin)
        {
            this.edge = edge;
        }

        public void Init()
        {
            base.Init();
        }
        public void Init(int edge)
        {
            this.edge=edge;
            base.Init(edge, edge);
        }
        public void Init(Coord origin)
        {
            base.Init(origin);
        }
        public void Init(int edge, Coord origin)
        {
            this.edge = edge;
            base.Init(edge, edge, origin);
        }


        //properties

        //method 



    }
}
