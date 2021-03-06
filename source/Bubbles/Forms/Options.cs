﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles {
    public partial class Options : Form {

        #region Variables
        /// <summary>
        /// A reference to the main window
        /// </summary>
        MainWindow parent;

        /// <summary>
        /// Keeps track of whether the debug panel is open
        /// </summary>
        bool debugOpen;

        #region AnimationVariables
        /// <summary>
        /// The length used for all animations (milliseconds)
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
        public Options(MainWindow _parent) {

            InitializeComponent();

            parent = _parent;

            animationLength = 100;

            resizeAmount = 150;

            animating = false;

            UpdateControls();
        }

        #region Animation
        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_MouseMove(object sender, MouseEventArgs e) {
            CheckForDebugAction(e);
        }

        /// <summary>
        /// Checks to see if the mouse was in the right place to activate the debug screen
        /// </summary>
        /// <param name="e"></param>
        void CheckForDebugAction(MouseEventArgs e) {

            int triggerStart = 580;
            int triggerEnd = 750;

            //checks to see if the mouse was in the right place to trigger the debug open
            if (e.Y > 0 && e.Y < Size.Height && e.X > triggerStart && e.X < triggerEnd) {

                //checks to see if the debug was closed
                if (!debugOpen)

                    OpenDebug();
            } else {

                //checks to see if the debug was open
                if (debugOpen)

                    CloseDebug();
            }
        }

        /// <summary>
        /// Starts the debug open sequence
        /// </summary>
        void OpenDebug() {
            //animates the window to open the debug panel
            SetupSizeAnimation(Size, new Size(Size.Width + resizeAmount, Size.Height), animationLength);
        }

        /// <summary>
        /// Starts the debug close sequence
        /// </summary>
        void CloseDebug() {

            //animates the window to collapse the debug panel
            SetupSizeAnimation(Size, new Size(Size.Width - resizeAmount, Size.Height), animationLength);
        }

        /// <summary>
        /// Sets up the animation for resizing the window
        /// </summary>
        /// <param name="start">The starting vakue of the size</param>
        /// <param name="end">The ending value of the size</param>
        /// <param name="length">The time, in milliseconds, for the animation to last</param>
        void SetupSizeAnimation(Size start, Size end, int length) {

            //checks to see if the window isn't being animated
            if (!animating) {

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
        void AnimateResize(object sender, EventArgs e) {

            //makes sure that the timer is ticking for the right amount of time
            if (timeLeft > 0) {
                //Console.WriteLine(timeLeft);
                Size newSize = new Size(Size.Width + sizeAnimationStep.X, Size.Height + sizeAnimationStep.Y);
                Size = newSize;
            } else {
                //stops the timer is too long has passed
                SizeAnimationTimer.Stop();

                animating = false;
            }

            //keeps track of how much time has passed
            timeLeft -= (int)SizeAnimationTimer.Interval;
        }
        #endregion

        /// <summary>
        /// Updates all the controls with data from the rest of the data
        /// </summary>
        void UpdateControls() {

            //selectes the right radio button for the mode
            if (parent.Mode == MainWindow.InteractiveModes.Create)
                SpawnMass_radio.Checked = true;

            else if (parent.Mode == MainWindow.InteractiveModes.Explode)
                ExplodeMass_radio.Checked = true;

            else if (parent.Mode == MainWindow.InteractiveModes.Rocket)
                CreateRockets_radio.Checked = true;

            else if (parent.Mode == MainWindow.InteractiveModes.Interact)
                Interaction_radio.Checked = true;

            //gets the bubble default info
            BubbleMass_txt.Text = Bubble.startingMass.ToString();
            BubbleStatic_chk.Checked = Bubble.startingStatic;
            BubbleZMass_chk.Checked = Bubble.startingZeroMass;
            BubbleAngle_bar.Value = (int)(Bubble.startingAngle * 1000);
            BubbleForce_txt.Text = Bubble.startingForce.ToString();
            BubbleTVel_txt.Text = Bubble.startingTerminalVel.ToString();

            //gets the rocket default info
            RocketMass_txt.Text = Rocket.startingMass.ToString();
            RocketTank_txt.Text = Rocket.startingFuelTime.ToString();
            RocketTVel_txt.Text = Rocket.startingTerminalVel.ToString();

            //checks or unchecks the debug boxes
            VelocityLines_check.Checked = Bubble.drawVelocityLines;
            TrailLines_check.Checked = Bubble.drawTrailLines;
            Speed_lbl.Text = "Speed: " + MainWindow.timerSpeed.ToString();
            Speed_bar.Value = (int)(MainWindow.timerSpeed * 10);
        }

        #region Updating Program Values
        /// <summary>
        /// Click event for the velocity lines checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VelocityLines_check_Click(object sender, EventArgs e) {

            Bubble.drawVelocityLines = VelocityLines_check.Checked;

        }

        /// <summary>
        /// Click event for the trail lines checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrailLines_check_CheckedChanged(object sender, EventArgs e) {
            Bubble.drawTrailLines = TrailLines_check.Checked;
        }

        /// <summary>
        /// Close event for the options window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_FormClosing(object sender, FormClosingEventArgs e) {

            int BMassDefault = 20;
            int BTVelDefault = 10;
            int RMassDefault = 50;
            int RTankDefault = 500;
            int RTVelDefault = 5;
            int BForcDefault = 100;

            int BMass = ConvertText(BubbleMass_txt.Text);
            int BTVel = ConvertText(BubbleTVel_txt.Text);
            int BForc = ConvertText(BubbleForce_txt.Text);
            int RMass = ConvertText(RocketMass_txt.Text);
            int RTank = ConvertText(RocketTank_txt.Text);
            int RTVel = ConvertText(RocketTVel_txt.Text);


            if (BMass != -1)
                Bubble.startingMass = BMass;
            else
                Bubble.startingMass = BMassDefault;

            if (BTVel != -1)
                Bubble.startingTerminalVel = BTVel;
            else
                Bubble.startingTerminalVel = BTVelDefault;

            if (BForc != -1)
                Bubble.startingForce = BForc;
            else
                Bubble.startingForce = BForcDefault;

            Bubble.startingStatic = BubbleStatic_chk.Checked;

            Bubble.startingZeroMass = BubbleZMass_chk.Checked;


            if (RMass != -1)
                Rocket.startingMass = RMass;
            else
                Rocket.startingMass = RMassDefault;

            if (RTank != -1)
                Rocket.startingFuelTime = RTank;
            else
                Rocket.startingFuelTime = RTankDefault;

            if (RTVel != -1)
                Rocket.startingTerminalVel = RTVel;
            else
                Rocket.startingTerminalVel = RTVelDefault;
        }

        /// <summary>
        /// Checks to see if the input string was good
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns>Returns the input number, or -1 if no conversian was possible</returns>
        int ConvertText(string inputText) {
            int returner;

            //checks to see if the input was empty
            if (inputText == "")

                //sets the return to -1
                returner = -1;

            //checks if the input wasnt a number (while also converting if it was)
            else if (!int.TryParse(inputText, out returner))

                returner = -1;

            //returns the value
            return returner;
        }

        #region Mode Switching

        private void SpawnMass_radio_CheckedChanged(object sender, EventArgs e) {
            parent.Mode = MainWindow.InteractiveModes.Create;
            parent.SwitchModes(false);
        }

        private void ExplodeMass_radio_CheckedChanged(object sender, EventArgs e) {
            parent.Mode = MainWindow.InteractiveModes.Explode;
            parent.SwitchModes(false);
        }

        private void CreateRockets_radio_CheckedChanged(object sender, EventArgs e) {
            parent.Mode = MainWindow.InteractiveModes.Rocket;
            parent.SwitchModes(false);
        }

        private void Interaction_radio_CheckedChanged(object sender, EventArgs e) {
            parent.Mode = MainWindow.InteractiveModes.Interact;
            parent.SwitchModes(false);
        }
        #endregion

        /// <summary>
        /// Scroll event for the angle bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BubbleAngle_bar_Scroll(object sender, EventArgs e) {

            Bubble.startingAngle = (float)BubbleAngle_bar.Value / 1000;

            AngleDemo_pic.Invalidate();
        }

        /// <summary>
        /// Scroll event for the speed bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speed_bar_Scroll(object sender, EventArgs e) {

            MainWindow.timerSpeed = (float)Speed_bar.Value / 10;

            if (MainWindow.timerSpeed == 0)
                MainWindow.timerSpeed = 0.1f;

            Speed_lbl.Text = "Speed: " + MainWindow.timerSpeed.ToString();

            parent.UpdateTimerInterval();
        }
        #endregion

        /// <summary>
        /// Paint event for the angle demo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AngleDemo_pic_Paint(object sender, PaintEventArgs e) {

            int x = (int)(AngleDemo_pic.Width / 2 * Math.Sin(Bubble.startingAngle) + AngleDemo_pic.Width / 2);
            int y = (int)(AngleDemo_pic.Width / 2 * Math.Cos(Bubble.startingAngle) + AngleDemo_pic.Height / 2);

            e.Graphics.DrawLine(Pens.Black, AngleDemo_pic.Width / 2, AngleDemo_pic.Height / 2, x, y);
        }
    }
}
