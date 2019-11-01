using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles {
    public partial class MainWindow : Form {

        Environment environment;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            //instantiates the environment variable
            environment = new Environment();
        }

        /// <summary>
        /// What happens when the window loads up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e) {

            //adds one bubble into the center of the scene on load
            environment.AddBubble(new Bubble(100, new Vector2D(Size.Width / 2, Size.Height / 2), environment));
            environment.bubbles[0].Explode();
        }

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Paint(object sender, PaintEventArgs e) {

            //draws the environment
            environment.Draw(e);
        }

        /// <summary>
        /// Allows time to pass in the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramTimer_Tick(object sender, EventArgs e) {

            //passes time in the environment
            environment.Tick();

            //redraws the form
            Invalidate();
        }

        /// <summary>
        /// Sends a click position to the environment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseClick(object sender, MouseEventArgs e) {

            environment.Click(e.X, e.Y);
        }
    }
}
