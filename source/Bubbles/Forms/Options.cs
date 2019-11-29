using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles
{
    public partial class Options : Form
    {

        #region Variables
        /// <summary>
        /// A reference to the main window
        /// </summary>
        MainWindow parent;

        /// <summary>
        /// Keeps track of whether the debug panel is open
        /// </summary>
        bool debugOpen;

        bool checkBoxFocus;

        #region AnimationVariables
        /// <summary>
        /// The length used for all animations
        /// </summary>
        int animationLength;

        /// <summary>
        /// The size's change steps for the form resize animation
        /// </summary>
        Point sizeAnimationStep;

        /// <summary>
        /// The amount to resize the form by
        /// </summary>
        int resizeAmount;

        /// <summary>
        /// The time left within the animation
        /// </summary>
        int timeLeft;

        /// <summary>
        /// Stores is the window is currently animating
        /// </summary>
        bool animating;
        #endregion
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_parent">A reference to the main window</param>
        /// <param name="drawVel">If the drawVelocity was true in the environment</param>
        public Options(MainWindow _parent, bool drawVel)
        {
            InitializeComponent();

            parent = _parent;

            animationLength = 100;

            resizeAmount = 150;

            checkBoxFocus = false;

            animating = false;

            CheckBoxes(drawVel);
        }

        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_MouseMove(object sender, MouseEventArgs e)
        {
            CheckForDebugAction(e);
        }

        /// <summary>
        /// Checks to see if the mouse was in the right place to activate the debug screen
        /// </summary>
        /// <param name="e"></param>
        void CheckForDebugAction(MouseEventArgs e)
        {

            int triggerStart = 160;
            int triggerEnd = 400;

            //checks to see if the mouse was in the right place to trigger the debug open
            if (e.Y > 0 && e.Y < Size.Height && e.X > triggerStart && e.X < triggerEnd)
            {

                //checks to see if the debug was closed
                if (!debugOpen)

                    OpenDebug();
            }
            else
            {

                //checks to see if the debug was open
                if (debugOpen)

                    CloseDebug();
            }
        }

        /// <summary>
        /// Starts the debug open sequence
        /// </summary>
        void OpenDebug()
        {
            //animates the window to open the debug panel
            SetupSizeAnimation(Size, new Size(Size.Width + resizeAmount, Size.Height), animationLength);
        }

        /// <summary>
        /// Starts the debug close sequence
        /// </summary>
        void CloseDebug()
        {

            //doesnt close the debug if the mouse is over the checkbox
            if (!checkBoxFocus)

                //animates the window to collapse the debug panel
                SetupSizeAnimation(Size, new Size(Size.Width - resizeAmount, Size.Height), animationLength);
        }

        /// <summary>
        /// Sets up the animation for resizing the window
        /// </summary>
        /// <param name="start">The starting vakue of the size</param>
        /// <param name="end">The ending value of the size</param>
        /// <param name="length">The time, in milliseconds, for the animation to last</param>
        void SetupSizeAnimation(Size start, Size end, int length)
        {

            //checks to see if the window isn't being animated
            if (!animating)
            {

                //inverts the debug bool
                debugOpen = !debugOpen;

                //lets the program know that the animation is running
                animating = true;

                timeLeft = length;

                //figures out how many time steps there will be
                int timeSteps = timeLeft / SizeAnimationTimer.Interval;

                Point sizeAnimationDifference = new Point();

                //gets the size difference from the start size to the end size
                sizeAnimationDifference.X = end.Width - start.Width;
                sizeAnimationDifference.Y = end.Height - start.Height;

                sizeAnimationStep = new Point();

                //figures out how much to increase the size each tick
                sizeAnimationStep.X = sizeAnimationDifference.X / timeSteps;
                sizeAnimationStep.Y = sizeAnimationDifference.Y / timeSteps;

                SizeAnimationTimer.Start();
            }
        }

        /// <summary>
        /// Animates the resize of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AnimateResize(object sender, EventArgs e)
        {

            //makes sure that the timer is ticking for the right amount of time
            if (timeLeft > 0)
            {
                //Console.WriteLine(timeLeft);
                Size newSize = new Size(Size.Width + sizeAnimationStep.X, Size.Height + sizeAnimationStep.Y);
                Size = newSize;
            }
            else
            {
                //stops the timer is too long has passed
                SizeAnimationTimer.Stop();

                animating = false;
            }

            //keeps track of how much time has passed
            timeLeft -= (int)SizeAnimationTimer.Interval;
        }

        #region Mode Switching

        private void SpawnMass_radio_CheckedChanged(object sender, EventArgs e)
        {
            parent.mode = MainWindow.Modes.Create;
            parent.SwitchModes(false);
        }

        private void ExplodeMass_radio_CheckedChanged(object sender, EventArgs e)
        {
            parent.mode = MainWindow.Modes.Explode;
            parent.SwitchModes(false);
        }

        private void CreateRockets_radio_CheckedChanged(object sender, EventArgs e)
        {
            parent.mode = MainWindow.Modes.Rocket;
            parent.SwitchModes(false);
        }

        /// <summary>
        /// Checks the relevant boxes
        /// </summary>
        /// <param name="drawVel">The draw velocity lines debug setting</param>
        void CheckBoxes(bool drawVel)
        {
            VelocityLines_check.Checked = drawVel;

            if (parent.mode == MainWindow.Modes.Create)
                SpawnMass_radio.Checked = true;

            else if (parent.mode == MainWindow.Modes.Explode)
                ExplodeMass_radio.Checked = true;

            else if (parent.mode == MainWindow.Modes.Rocket)
                CreateRockets_radio.Checked = true;
        }
        #endregion

        /// <summary>
        /// Click event for the velocity lines checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VelocityLines_check_Click(object sender, EventArgs e)
        {
            bool velocityLinesChecked = false;

            //checks to see if the box was checked
            if (VelocityLines_check.Checked)
                velocityLinesChecked = true;

            //sends the status of the checkbox to the main form
            parent.Debugs(velocityLinesChecked);

        }
    }
}
