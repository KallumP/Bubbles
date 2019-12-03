using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles
{
    class Environment
    {
        #region Variables
        /// <summary>
        /// Stores the bubbles
        /// </summary>
        List<Bubble> bubbles;

        /// <summary>
        /// Stores the rockets
        /// </summary>
        List<Rocket> rockets;

        /// <summary>
        /// A temporary rocket before the user snaps it to a bubble
        /// </summary>
        Rocket tempRocket;

        /// <summary>
        /// Gravitational constant
        /// </summary>
        int G = 50;
        #endregion

        #region Properties

        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public Environment()
        {

            //instantiates the lists
            bubbles = new List<Bubble>();
            rockets = new List<Rocket>();
        }

        /// <summary>
        /// The click event
        /// </summary>
        /// <param name="x">The x coord of the click</param>
        /// <param name="y">The y coord of the click</param>
        public void Click(MainWindow.Modes mode, int x, int y)
        {

            //checks to see if create mode was on
            if (mode == MainWindow.Modes.Create)

                AddBubble(new Bubble(this, new Vector2D(x, y)));

            //checks if explode mode was on
            else if (mode == MainWindow.Modes.Explode)

                //loops backwards through the bubbles
                for (int i = bubbles.Count - 1; i >= 0; i--)
                {
                    //makes sure that the bubble exists
                    if (bubbles[i] != null)

                        //calls the check click event on each bubble
                        bubbles[i].CheckClick(x, y);
                }

            //checks if rocket mode was on
            else if (mode == MainWindow.Modes.Rocket)


                //checks to see if there is no temp rocket
                if (tempRocket == null)
                    AddTempRocket();

                //checks to see if the temp rocket wasn't snapped to a bubble
                else if (tempRocket.status == Rocket.Statuses.temp)
                    RemoveTempRocket();

                //checks to see if the temp rocket was snapped to a bubble
                else if (tempRocket.status == Rocket.Statuses.tempSnapped)
                    AddRocket();

        }

        /// <summary>
        /// The hover event
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Hover(MainWindow.Modes mode, int x, int y)
        {

            //checks to see what mode is active
            if (mode == MainWindow.Modes.Rocket)

                //checks to see if the rocket exists
                if (tempRocket != null)
                {

                    //stores if the rockets position should be updated (if no bubble was found)
                    bool updatePos = true;

                    //loops backwards through the bubbles
                    for (int i = bubbles.Count - 1; i >= 0; i--)

                        //makes sure that the bubble exists
                        if (bubbles[i] != null)

                            //calls the check hover event on each bubble
                            if (bubbles[i].CheckInside(x, y))
                            {

                                //snaps the rocket to the bubble
                                tempRocket.Snap(bubbles[i], x, y);

                                //lets the program know not to update the positon after the loop ends
                                updatePos = false;

                                //stops searching after a bubble was found
                                break;
                            }

                    //checks to see if the position needs to be updated
                    if (updatePos)
                    {
                        //updates the rockets position
                        tempRocket.UpdatePos(x, y);

                        //unsnaps the rocket from the is current bubble
                        tempRocket.UnSnap();
                    }
                }
        }

        /// <summary>
        /// The key down event
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="pressedKey"></param>
        public void KeyDown(MainWindow.Modes mode, string pressedKey)
        {

            //checks to see what modes was activated
            if (mode == MainWindow.Modes.Explode)
            {
                //checks to see if the space key was pressed
                if (pressedKey == Keys.Space.ToString())

                    ExplodeAllBubbles();

            }
            else if (mode == MainWindow.Modes.Rocket)
            {

                //checks to see if the space key was 
                if (pressedKey == Keys.Space.ToString())

                    TakeOffAllRockets();
            }

        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick(int timeInterval)
        {

            //implements gravity
            AttractBubbles();
            AttractRockets();

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //ticks each bubble
                    bubbles[i].Move();

            //loops backwards through the bubbles
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (rockets[i] != null)

                    //ticks each bubble
                    rockets[i].Tick(timeInterval);

            //checks for collisions
            CheckBubbleCollision();
            CheckRocketCollision();
        }

        /// <summary>
        /// Draws out the instance of the environment, along with everything in it
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window being draw to</param>
        /// <param name="timeInterval">Time passed since the last tick</param>
        public void Draw(PaintEventArgs e, Size windowSize, int timeInterval)
        {

            //ticks the environment first
            Tick(timeInterval);

            //checks to see that the temp rocket exists
            if (tempRocket != null)
                tempRocket.Draw(e, windowSize);

            //loops backwards through the bubbles
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (rockets[i] != null)

                    //draws out the current bubble
                    rockets[i].Draw(e, windowSize);

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //draws out the current bubble
                    bubbles[i].Draw(e, windowSize);
        }

        /// <summary>
        /// Adds a new bubbles into the environment's list of bubbles
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_radius">The radius of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        public void AddBubble(Bubble b)
        {

            //adds the bubble into the list
            bubbles.Add(b);
        }

        /// <summary>
        /// Removes a selected bubble from the list
        /// </summary>
        /// <param name="b">The bubble to remove</param>
        public void RemoveBubble(Bubble b)
        {

            //removes the bubble
            bubbles.Remove(b);
        }

        /// <summary>
        /// Applies forces to the bubbles using gravity from other bubbles
        /// </summary>
        void AttractBubbles()
        {

            //loops backwards through each of the bubbles to apply the force
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //checks to see if the bubble should move (not static)
                    if (!bubbles[i].Static)

                        //loops through each of the bubbles to see what force to apply
                        for (int j = bubbles.Count - 1; j >= 0; j--)

                            //makes sure that the bubble exists
                            if (bubbles[j] != null)

                                //makes sure that bubbles isnt attracting to itself
                                if (i != j)

                                    //checks to see if the current bubble will induce a force
                                    if (!bubbles[j].ZeroMass)
                                    {

                                        //gets the distance between the two bubbles
                                        float distance = Vector2D.Distance(bubbles[i].position, bubbles[j].position);

                                        //gets the angle between the two bubbles
                                        float angle = Vector2D.Angle(bubbles[i].position, bubbles[j].position);

                                        //creates a gravitational force using F = (GMm) / (r^2)
                                        Vector2D force = Vector2D.CreateGravityFixedVector(G * bubbles[i].mass * bubbles[j].mass / (float)Math.Pow(distance, 2), angle);

                                        //applies the gravitational force to the bubble;
                                        bubbles[i].ApplyForce(force);
                                    }
        }

        /// <summary>
        /// Checks each of the bubles to see of any of them collided
        /// </summary>
        void CheckBubbleCollision()
        {

            //loops backwards through each of the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //loops backwards through each of the bubbles
                    for (int j = i - 1; j >= 0; j--)

                        //makes sure that the bubble exists
                        if (bubbles[j] != null)

                            //makes sure that bubbles isnt colliding with itself
                            if (i != j)

                                //checks for a collision with the bubble in the second for loop
                                if (bubbles[i].CheckCollision(bubbles[j]))

                                    //stops searching for more collisions
                                    break;
        }

        /// <summary>
        /// Adds a temporary rocket into the environment
        /// </summary>
        void AddTempRocket()
        {
            tempRocket = new Rocket(this);
        }

        /// <summary>
        /// Removes the temporary rocket from the environment
        /// </summary>
        void RemoveTempRocket()
        {
            tempRocket = null;
        }

        /// <summary>
        /// Adds the temp rocket to the list of rockets
        /// </summary>
        void AddRocket()
        {

            //checks to see if there was a temp rocket
            if (tempRocket != null)
            {

                //remvoes the temp status
                tempRocket.RemoveTemp();

                rockets.Add(tempRocket);
            }


            //removes the temp rocket
            RemoveTempRocket();
        }

        /// <summary>
        /// Removes the input rocket from the list
        /// </summary>
        /// <param name="r"></param>
        void RemoveRocket(Rocket r)
        {

            rockets.Remove(r);
        }

        /// <summary>
        /// Attracts each of the rockets to the masses
        /// </summary>
        void AttractRockets()
        {
            //loops backwards through each of the rocket to apply the force
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the rocket exists
                if (rockets[i] != null)

                    //checks to see if the rocket is available to have gravity applied to it (only if it has taken off of is falling)
                    if (rockets[i].status == Rocket.Statuses.takeOff || rockets[i].status == Rocket.Statuses.freeFall)

                        //loops through each of the bubbles to see what force to apply
                        for (int j = bubbles.Count - 1; j >= 0; j--)

                            //makes sure that the bubble exists
                            if (bubbles[j] != null)

                                //checks to see if the current bubble will induce a force
                                if (!bubbles[j].ZeroMass)
                                {

                                    //gets the distance between the two bubbles
                                    float distance = Vector2D.Distance(rockets[i].position, bubbles[j].position);

                                    //gets the angle between the two bubbles
                                    float angle = Vector2D.Angle(rockets[i].position, bubbles[j].position);

                                    //creates a gravitational force using F = (GMm) / (r^2)
                                    Vector2D force = Vector2D.CreateGravityFixedVector(G * rockets[i].mass * bubbles[j].mass / (float)Math.Pow(distance, 2), angle);

                                    //applies the gravitational force to the bubble;
                                    rockets[i].ApplyForce(force);
                                }
        }

        /// <summary>
        /// Checks to see if a rocket should resnap to a new bubble
        /// </summary>
        /// <param name="toUnsnap">The bubble being checked</param>
        /// <param name="">The new bubble to reset to</param>
        public void CheckForReSnap(Bubble toUnsnap, Bubble next)
        {
            //loops backwards through each of the rocket to apply the force
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the rocket exists
                if (rockets[i] != null)

                    //checks to see if the current rocket was snapped to the current bubble
                    if (rockets[i].snappedTo == toUnsnap)

                        //resnaps the rocket to the next bubble
                        rockets[i].ReSnap(next, false);
        }

        /// <summary>
        /// Checks to see if a rocket needs to unsnap from the input bubble
        /// </summary>
        /// <param name="toUnsnap">The bubble being checked for rockets</param>
        public void CheckForUnSnap(Bubble toUnsnap)
        {
            //loops backwards through each of the rocket to apply the force
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the rocket exists
                if (rockets[i] != null)

                    //checks to see if the current rocket was snapped to the current bubble
                    if (rockets[i].snappedTo == toUnsnap)

                        //unsnaps the rocket from the bubble
                         rockets[i].UnSnap();
        }

        /// <summary>
        /// Checks to see if a rocket collides with a bubble
        /// </summary>
        void CheckRocketCollision()
        {
            //loops backwards through each of the rocket to apply the force
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the rocket exists
                if (rockets[i] != null)

                    //checks to see if the rocket is available to have gravity applied to it (only if it has taken off of is falling)
                    if (rockets[i].status == Rocket.Statuses.takeOff || rockets[i].status == Rocket.Statuses.freeFall)

                        //checks to see if the rocket can collide
                        if (rockets[i].timeTillCollidable <= 0)

                            //loops through each of the bubbles to see what force to apply
                            for (int j = bubbles.Count - 1; j >= 0; j--)

                                //makes sure that the bubble exists
                                if (bubbles[j] != null)

                                    //checks to see if the rocker had collided with the bubble
                                    if (bubbles[j].CheckInside((int)rockets[i].position.x, (int)rockets[i].position.y))

                                        rockets[i].ReSnap(bubbles[j], true);
        }

        /// <summary>
        /// Causes all the bubbles to explode
        /// </summary>
        void ExplodeAllBubbles()
        {

            //loops backwards through each of the bubbles to apply the force
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    bubbles[i].Explode();
        }

        /// <summary>
        /// Makes each of the rockets take off
        /// </summary>
        void TakeOffAllRockets()
        {
            //loops backwards through each of the rockets to apply the force
            for (int i = rockets.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (rockets[i] != null)

                    //checks to see if the rockets haven't taken off yet
                    if (rockets[i].status == Rocket.Statuses.snapped)

                        rockets[i].TakeOff();
        }
        #endregion
    }
}
