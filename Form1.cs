using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrickGame
{
    public partial class Form1 : Form
    {
        private readonly BrickGame _brickGame;

        public Form1()
        {
            InitializeComponent();
            _brickGame = new BrickGame(Window);
        }

    }
}
