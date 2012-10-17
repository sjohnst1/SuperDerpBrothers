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


        public Controller()
        {
            InitializeComponent();
        }

        public Controller(PlatformerGame game)
        {
            this.game = game;

            //manager = new ComputerManager();
            InitializeComponent();
        }

        public void Update(GameTime gameTime)
        {
            GameState state = game.GameState;
            switch (state)
            {
                case GameState.Start:

                    break;

                case GameState.Play:

                    break;

                case GameState.Lose:

                    break;

                default:
                    break;
            }
        }
    }
}
