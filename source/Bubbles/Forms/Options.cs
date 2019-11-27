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

        #region ResizeAnimationVariables
        /// <summary>
        /// The difference in sizes for the form resize animation
        /// </summary>
        Point sizeAnimationStep;

        /// <summary>
        /// The time left within the animation
        /// </summary>
        int timeLeft;

        /// <summary>
        /// Stores is the window is currently animating
        /// </summary>
        bool animating;

        /// <summary>
        /// Timer used to animate the form resize
        /// </summary>
        System.Timers.Timer sizeAnimationTimer;

        /// <summary>
        /// The interval between ticks for the timer;
        /// </summary>
        int timerInterval = 100;
        #endregion
        #endregion

        public Options(MainWindow _parent)
        {
            InitializeComponent();

            parent = _parent;

            animating = false;
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
            if (!debugOpen)

                //checks to see if the mouse's y was within the control
                if (e.Y > 0 && e.Y < Size.Height)

                    //checks to see if the mouse's x was in the right place for debug
                    if (e.X > 200 && e.X < 250 && !debugOpen)
                    
                        //animates the window to open the debug panel
                        SetupSizeAnimation(Size, new Size(Size.Width + 100, Size.Height), 500);

                    else if (e.X > 0 && e.X <= 200 && debugOpen)
                    
                        //animates the window to collapse the debug panel
                        SetupSizeAnimation(Size, new Size(Size.Width - 100, Size.Height), 500);    
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
                int timeSteps = timeLeft / timerInterval;

                Point sizeAnimationDifference = new Point();

                //gets the size difference from the start size to the end size
                sizeAnimationDifference.X = end.Width - start.Width;
                sizeAnimationDifference.Y = end.Height - start.Height;

                sizeAnimationStep = new Point();

                //figures out how much to increase the size each tick
                sizeAnimationStep.X = sizeAnimationDifference.X / timeSteps;
                sizeAnimationStep.Y = sizeAnimationDifference.Y / timeSteps;


                //sets up the timer for the animation
                sizeAnimationTimer = new System.Timers.Timer();

                sizeAnimationTimer.Interval = timerInterval;
                sizeAnimationTimer.AutoReset = true;
                sizeAnimationTimer.Elapsed += AnimateResize;
                sizeAnimationTimer.Start();
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
            if (timeLeft <= 0)
            {
                Console.WriteLine(timeLeft);
                //Size newSize = new Size(Size.Width + sizeAnimationStep.X, Size.Height + sizeAnimationStep.Y);
                //Size = newSize;
            }
            else
            {
                //stops the timer is too long has passed
                sizeAnimationTimer.Stop();
                animating = false;
            }




            //keeps track of how much time has passed
            timeLeft -= (int)sizeAnimationTimer.Interval;
        }
    }
}
