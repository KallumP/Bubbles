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
        public enum Modes { Create, Explode }

        /// <summary>
        /// An environment instance
        /// </summary>
        Environment environment;

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
        private void AnimationWindow_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            mode = Modes.Explode;

            mode_lbl.Text = "Mode: " + mode.ToString();

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
            environment.AddBubble(new Bubble(startingMass, new Vector2D(Size.Width / 2, Size.Height / 2), environment, true, false)); ;

        }

        /// <summary>
        /// The sequence for drawing out (invalidating) the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationWindow_Paint(object sender, PaintEventArgs e)
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
        private void AnimationWindow_MouseClick(object sender, MouseEventArgs e)
        {

            if (mode == Modes.Explode)

                //sends the click event into the environment
                environment.Click(e.X, e.Y);

            else

                //adds a new bubble on click
                environment.AddBubble(new Bubble(20, new Vector2D(e.X, e.Y), new Vector2D(100, 0), environment, false, true));
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

        /// <summary>
        /// Switches between the different modes in the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Switch_btn_Click(object sender, EventArgs e)
        {

            if (mode == Modes.Create)
                mode = Modes.Explode;
            else
                mode = Modes.Create;

            mode_lbl.Text = "Mode: " + mode.ToString();
        }

        /// <summary>
        /// Changes if the program should show the velocity lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vectorDebug_Click(object sender, EventArgs e)
        {
            environment.drawVectorLines = !environment.drawVectorLines;
        }
        #endregion

        /// <summary>
        /// KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Options o = new Options(this);

                o.Show();
            }
        }
    }
}
