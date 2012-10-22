using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Platformer.Controller
{
    public partial class Controller : Form
    {
        ComputerManager manager;
        PlatformerGame game;

        int generationsBetweenWrites;
        int generationsSinceWrite = 0;

        bool generationOver = false;

        #region Properties

        public bool StopGame
        {
            get;
            protected set;
        }

        #endregion


        public Controller()
        {
            InitializeComponent();
        }

        public Controller(PlatformerGame game)
        {
            this.game = game;
            StopGame = false;
            InitializeComponent();
        }

        #region Form Event Handlers

        private void btStart_Click(object sender, EventArgs e)
        {
            string file = inWeightFile.Text;
            int numGenerations = (int)inGenerations.Value;
            if (inRunForever.Checked) numGenerations = -1;

            //I'll deal with this later, hard coded for now
            int levelSelect = 1;

            generationsBetweenWrites = (int)inBetweenWrites.Value;

            manager = new ComputerManager(numGenerations, levelSelect, file);

            //we should have everything we need here, hand control over to the game
            game.GameState = GameState.Play;
        }

        #endregion

        public void Update(GameTime gameTime)
        {
            if (generationOver)
            {
                generationsSinceWrite++;
                if (generationsSinceWrite >= generationsBetweenWrites)
                {
                    generationsSinceWrite = 0;
                    //write the files
                }

                //sort the generation by score
                //drop the lower half
                //breed new generation
                generationOver = false;
                //start over
            }

            GameState state = game.GameState;
            switch (state)
            {
                case GameState.Start:
                    break;

                case GameState.Play:
                    //get inputs,
                    //pass inputs to the neural network,
                    //pass back the actions to take
                    break;

                case GameState.Lose:
                    //score and record stats
                    //reset game
                    //get next computer or mark generation over
                    //restart
                    break;

                default:
                    break;
            }
        }

    }
}
