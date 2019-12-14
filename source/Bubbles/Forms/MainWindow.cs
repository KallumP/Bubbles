using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles {
    public partial class MainWindow : Form {

        #region Statics

        /// <summary>
        /// The speed of the timer (relative to the base tick speed)
        /// </summary>
        public static float timerSpeed = 1;

        /// <summary>
        /// The types of starting modes for the program
        /// </summary>
        public enum StartModes { default_, twoBod, threeBod, solar }

        /// <summary>
        /// What types of interactive modes there are in the program
        /// </summary>
        public enum InteractiveModes { Create, Explode, Rocket }
        #endregion

        #region Variables

        /// <summary>
        /// The starting and base speed of the timer (ms)
        /// </summary>
        int baseTimerInterval = 16;

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
        public InteractiveModes mode { get; set; }

        /// <summary>
        /// The current start mode
        /// </summary>
        public StartModes startMode { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow() {

            InitializeComponent();
        }

        /// <summary>
        /// What happens when the window loads up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e) {

            //maximises the form
            WindowState = FormWindowState.Maximized;

            //sets the interactive mode to explode
            mode = InteractiveModes.Explode;

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
        public void Restart() {

            //instantiates the environment variable
            environment = new Environment();

            //checks to see what sort of restart was required
            if (startMode == StartModes.default_)
                DefaultScene();

            else if (startMode == StartModes.twoBod)
                TwoBodyScene();

            else if (startMode == StartModes.threeBod)
                ThreeBodyScene();
        }

        /// <summary>
        /// The default starting scene
        /// </summary>
        void DefaultScene() {

            //adds one bubble into the center of the scene on load
            environment.AddBubble(new Bubble(startingMass, new Vector2D(Size.Width / 2, Size.Height / 2), environment, true, false)); ;
        }

        /// <summary>
        /// Two body scene, where two masses go toward each other
        /// </summary>
        void TwoBodyScene() {

            //adds two bubble into the going towards each other offset on the y axis
            environment.AddBubble(new Bubble(50, new Vector2D(Width / 2, (Height / 2) - 106), Vector2D.CreateVector(150, (float)(3 * Math.PI / 2)), environment, false, false));
            environment.AddBubble(new Bubble(50, new Vector2D(Width / 2, (Height / 2) + 106), Vector2D.CreateVector(150, (float)(Math.PI / 2)), environment, false, false));

        }

        /// <summary>
        /// Three body scene where one mass orbits two masses
        /// </summary>
        void ThreeBodyScene() {

            environment.AddBubble(new Bubble(93, new Vector2D((Width / 2) - 323, Height / 2), environment, true, false));
            environment.AddBubble(new Bubble(93, new Vector2D((Width / 2) + 323, Height / 2), environment, true, false));

            environment.AddBubble(new Bubble(30, new Vector2D((Width / 2) - 323, (Height / 2) - 223), Vector2D.CreateVector(150, (float)(3 * Math.PI / 2)), environment, false, true));

        }
        #endregion

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Paint(object sender, PaintEventArgs e) {

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
        private void ProgramTimer_Tick(object sender, EventArgs e) {

            //redraws the form
            Invalidate();
        }

        /// <summary>
        /// Sends a click position to the environment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseClick(object sender, MouseEventArgs e) {

            //sends the click event into the environment
            environment.Click(mode, e.X, e.Y);
        }

        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_MouseMove(object sender, MouseEventArgs e) {

            //sends the mouse move event
            environment.Hover(mode, e.X, e.Y);
        }

        /// <summary>
        /// KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {

            //checks to see if the escape key was pressed
            if (e.KeyCode == Keys.Escape) {

                //resets the program
                Restart();

            }

            //checks to see if the tab key was pressed
            else if (e.KeyCode == Keys.Tab) {

                //switches modes
                SwitchModes(true);

            }

            //checks to see if the S key was pressed
            else if (e.KeyCode == Keys.S) {

                //opens the options window
                Options o = new Options(this);
                o.Show();

            }

            //checks to see if the p key was pressed
            else if (e.KeyCode == Keys.P) {

                //opens the presets window
                Presets p = new Presets(this);
                p.Show();

            }

            //checks to see if the space keys was pressed
            else if (e.KeyCode == Keys.Space) {

                //pauses or plays the timer
                ToggleTimer();

            }

            //checks to see if the enter key was pressed
            else if (e.KeyCode == Keys.Enter) {

                //sends a mass action event
                environment.KeyDown(mode, e.KeyCode.ToString());

            }

            //checks to see if number keys were pressed and updates the speed of the environment
            else if (e.KeyCode == Keys.D1)
                Environment.speed = 1;
            else if (e.KeyCode == Keys.D2)
                Environment.speed = 2;
            else if (e.KeyCode == Keys.D3)
                Environment.speed = 3;
            else if (e.KeyCode == Keys.D4)
                Environment.speed = 4;
            else if (e.KeyCode == Keys.D5)
                Environment.speed = 5;
            else if (e.KeyCode == Keys.D6)
                Environment.speed = 6;
            else if (e.KeyCode == Keys.D7)
                Environment.speed = 7;
            else if (e.KeyCode == Keys.D8)
                Environment.speed = 8;
            else if (e.KeyCode == Keys.D9)
                Environment.speed = 9;

            //checks to see if the greater than key was pressed
            else if (e.KeyCode == Keys.OemPeriod) {

                //adds 0.1 to the timer speed
                timerSpeed += 0.1f;

                //constrains the timer speed to 1
                if (timerSpeed > 1)
                    timerSpeed = 1;

                UpdateTimerInterval();
            }

            //checks to see if the less than key was pressed
            else if (e.KeyCode == Keys.Oemcomma) {

                //adds 0.1 to the timer speed
                timerSpeed -= 0.1f;

                //constrains the timer speed to 1
                if (timerSpeed < 0.1)
                    timerSpeed = 0.1f;

                UpdateTimerInterval();
            }

        }

        /// <summary>
        /// Switches between the different modes in the program
        /// </summary>
        /// <param name="updateMode">If the program should update the current mode</param>
        public void SwitchModes(bool updateMode) {

            //checks to see if the mode should be switched
            if (updateMode)

                if (mode == InteractiveModes.Create)
                    mode = InteractiveModes.Explode;

                else if (mode == InteractiveModes.Explode)
                    mode = InteractiveModes.Rocket;

                else if (mode == InteractiveModes.Rocket)
                    mode = InteractiveModes.Create;

            //updates the label
            mode_lbl.Text = "Mode: " + mode.ToString();
        }

        /// <summary>
        /// Toggles turning the timer on or off
        /// </summary>
        public void ToggleTimer() {

            timeOn = !timeOn;
        }

        /// <summary>
        /// Updates the speed of the timer
        /// </summary>
        public void UpdateTimerInterval() {

            //updates the timer interval using the speed set from the options window
            ProgramTimer.Interval = (int)(baseTimerInterval / timerSpeed);
        }
        #endregion
    }
}
