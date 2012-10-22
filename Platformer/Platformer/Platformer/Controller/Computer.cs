using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.Controller
{
    public class Computer
    {
        int[] weights;
        Score score = new Score();

        public int[] Weights
        {
            get { return weights; }
        }

        public Score Score
        {
            get { return score; }
            set { score = value; }
        }


        public Computer(int[] v)
        {
            weights = v;
        }
    }
}
