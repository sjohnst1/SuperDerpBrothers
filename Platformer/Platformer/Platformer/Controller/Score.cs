using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.Controller
{
    public class Score : IComparable<Score>
    {
        int tileDistance;
        float elapsedTime;
        bool levelComplete;
        int buttonPresses;

        public int TileDistance
        {
            get { return tileDistance; }
            set { tileDistance = value; }
        }

        public float ElapsedTime
        {
            get { return elapsedTime; }
            set { elapsedTime = value; }
        }

        public bool LevelComplete
        {
            get { return levelComplete; }
            set { levelComplete = value; }
        }

        public int ButtonPresses
        {
            get { return buttonPresses; }
            set { buttonPresses = value; }
        }

        public int CompareTo(Score other)
        {
            if (this.LevelComplete && !other.LevelComplete) return 1;
            if (other.LevelComplete && !this.LevelComplete) return -1;
            if (this.TileDistance > other.TileDistance) return 1;
            if (other.TileDistance > this.TileDistance) return -1;
            if (this.ElapsedTime < other.ElapsedTime) return 1;
            if (other.ElapsedTime < this.ElapsedTime) return -1;
            if (this.ButtonPresses < other.ButtonPresses) return 1;
            if (other.ButtonPresses < this.ButtonPresses) return -1;
            return 0;
        }
    }
}
