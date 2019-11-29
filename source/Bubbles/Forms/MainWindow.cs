using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles
{
    public partial class MainWindow : Form
    {
        #region Variables
        /// <summary>
        /// What types of modes there are in the program
        /// </summary>
        public enum Modes { Create, Explode, Rocket }

        /// <summary>
        /// An environment instance
        /// </summary>
        Environment environment;

        /// <summary>
        /// The starting mass for a newly spawned mass
        /// </summary>
        int startingMass = 200;
        #endregion

        #region Properties
        /// <summary>
        /// The current mode of the program
        /// </summary>
        public Modes mode { get; set; }
        #endregion

        #region Methods
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
            WindowState = FormWindowState.Maximized;

            mode = Modes.Explode;

            mode_lbl.Text = "Mode: " + mode.ToString();

            Restart();
        }

        /// <summary>
        /// Sets up the environment
        /// </summary>
        void Restart()
        {

            //instantiates the environment variable
            environment = new Environment();

            //adds one bubble into the center of the scene on load
            environment.AddBubble(new Bubble(startingMass, new Vector2D(Size.Width / 2, Size.Height / 2), environment, true, false)); ;

        }

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {

            //draws the environment
            environment.Draw(e, Size);
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
            environment.Click(mode, e.X, e.Y);
        }

        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            //sends the mouse move event
            environment.Hover(mode, e.X, e.Y);
        }

        /// <summary>
        /// KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //checks to see if the escape key was pressed
            if (e.KeyCode == Keys.Escape)
            {

                //resets the program
                Restart();
            }

            //checks to see if the tab key was pressed
            else if (e.KeyCode == Keys.Tab)
            {
                //switches modes
                SwitchModes(true);
            }

            //checks to see if the S key was pressed
            else if (e.KeyCode == Keys.S)
            {

                //opens the options window
                Options o = new Options(this, environment.drawVectorLines);
                o.Show();
            }

            else if (e.KeyCode == Keys.Space)

                environment.KeyDown(mode, e.KeyCode.ToString());
        }

        /// <summary>
        /// Switches between the different modes in the program
        /// </summary>
        /// <param name="switchMode">If the program should switch the current mode</param>
        public void SwitchModes(bool switchMode)
        {

            //checks to see if the mode should be switched
            if (switchMode)

                if (mode == Modes.Create)
                    mode = Modes.Explode;

                else if (mode == Modes.Explode)
                    mode = Modes.Rocket;

                else if (mode == Modes.Rocket)
                    mode = Modes.Create;

            //updates the label
            mode_lbl.Text = "Mode: " + mode.ToString();
        }

        /// <summary>
        /// Updates the debug values for the environment
        /// </summary>
        /// <param name="velocityLines"></param>
        public void Debugs(bool velocityLines)
        {
            environment.drawVectorLines = velocityLines;
        }
        #endregion


    }
}
