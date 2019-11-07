using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// An environment instance
        /// </summary>
        Environment environment;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// What happens when the window loads up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            Setup();
        }

        /// <summary>
        /// Sets up the environment
        /// </summary>
        void Setup()
        {

            //instantiates the environment variable
            environment = new Environment();

            //adds one bubble into the center of the scene on load
            environment.AddBubble(new Bubble(300, new Vector2D(Size.Width / 2, Size.Height / 2), environment, false, false));

        }

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {

            //draws the environment
            environment.Draw(e);
        }

        /// <summary>
        /// Allows time to pass in the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramTimer_Tick(object sender, EventArgs e)
        {

            //redraws the form
            Invalidate();
        }

        /// <summary>
        /// Sends a click position to the environment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            //sends the click event into the environment
            environment.Click(e.X, e.Y);

            //adds a new bubble on click
            //environment.AddBubble(new Bubble(100, new Vector2D(e.X, e.Y), environment, false, false));
        }

        /// <summary>
        /// Restarts the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            Setup();
        }
    }
}
