using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles
{
    public partial class MainWindow : Form
    {
        #region Statics
        static int baseTimerInterval = 16;

        /// <summary>
        /// The types of starting modes for the program
        /// </summary>
        public enum StartModes { default_, twoBod, threeBod, solar}

        /// <summary>
        /// What types of interactive modes there are in the program
        /// </summary>
        public enum Modes { Create, Explode, Rocket }
        #endregion

        #region Variables


        /// <summary>
        /// An environment instance
        /// </summary>
        Environment environment;

        /// <summary>
        /// The starting mass for a newly spawned mass
        /// </summary>
        int startingMass = 200;

        /// <summary>
        /// Stores if the timer should tick the environment
        /// </summary>
        public static bool timeOn = true;
        #endregion

        #region Properties
        /// <summary>
        /// The current mode of the program
        /// </summary>
        public Modes mode { get; set; }

        /// <summary>
        /// The current start mode
        /// </summary>
        public StartModes startMode { get; set; }
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

            //maximises the form
            WindowState = FormWindowState.Maximized;

            //sets the interactive mode to explode
            mode = Modes.Explode;

            //updates the mode text
            mode_lbl.Text = "Mode: " + mode.ToString();

            //sets the starting mode to default
            startMode = StartModes.default_;

            //starts the program
            Restart();
        }

        #region ResetMethods
        /// <summary>
        /// Sets up the environment
        /// </summary>
        public void Restart()
        {

            //instantiates the environment variable
            environment = new Environment();

            //checks to see what sort of restart was required
            if (startMode == StartModes.default_)
                DefaultScene();

            else if (startMode == StartModes.twoBod)
                TwoBodyScene();
        }

        /// <summary>
        /// The default starting scene
        /// </summary>
        void DefaultScene()
        {
            //adds one bubble into the center of the scene on load
            environment.AddBubble(new Bubble(startingMass, new Vector2D(Size.Width / 2, Size.Height / 2), environment, true, false)); ;
        }

        /// <summary>
        /// Two body scene, where two masses go toward each other
        /// </summary>
        void TwoBodyScene()
        {
            //adds two bubble into the going towards each other offset on the y axis
            environment.AddBubble(new Bubble(50, new Vector2D(Width/2, 4* Height/10), Vector2D.CreateVector(150, (float)(3 * Math.PI / 2)), environment, false, false));
            environment.AddBubble(new Bubble(50, new Vector2D(Width/2, 6*Height/10), Vector2D.CreateVector(150, (float)(Math.PI / 2)), environment, false, false));
        }
        #endregion

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {

            //variable used to store the size of the play/pause button
            int buttonSize = 50;

            if (timeOn)

                e.Graphics.DrawImage(
                    Properties.Resources.play,
                    0,
                    0,
                    buttonSize,
                    buttonSize);
            else

                e.Graphics.DrawImage(
                    Properties.Resources.pause,
                    0,
                    0,
                    buttonSize,
                    buttonSize);

            //draws the environment
            environment.Draw(e, Size, ProgramTimer.Interval);
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
                Options o = new Options(this);
                o.Show();
            }

            else if (e.KeyCode == Keys.P)
            {

                //opens the presets window
                Presets p = new Presets(this);
                p.Show();
            }

            else if (e.KeyCode == Keys.Space)
            {

                ToggleTimer();
            }

            else if (e.KeyCode == Keys.Enter)
            {

                environment.KeyDown(mode, e.KeyCode.ToString());
            }
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
        /// Toggles turning the timer on or off
        /// </summary>
        public void ToggleTimer()
        {
            timeOn = !timeOn;
        }

        /// <summary>
        /// Updates the speed of the timer
        /// </summary>
        public void UpdateTimerInterval()
        {

            //updates the timer interval using the speed set from the options window
            ProgramTimer.Interval = (int)(baseTimerInterval / Environment.speed);
        }
        #endregion
    }
}
