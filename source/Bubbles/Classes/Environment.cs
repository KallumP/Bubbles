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
        /// Used to store the bubbles in the environment
        /// </summary>
        List<Bubble> bubbles;

        /// <summary>
        /// Gravitational constant
        /// </summary>
        int G = 70;
        #endregion

        #region Properties
        /// <summary>
        /// Debug values that determins whether the vector lines should be draw
        /// </summary>
        public bool drawVectorLines { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public Environment()
        {
            //sets up the debug values
            drawVectorLines = false;

            //resets the bubble id counter
            Bubble.nextId = 0;

            //instantiates the list of bubbles
            bubbles = new List<Bubble>();
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
        /// <param name="id">The id of the bubble to remove</param>
        public void RemoveBubble(int id)
        {

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)
            {

                //makes sure that the bubble exists
                if (bubbles[i].Id == id)
                {

                    //ticks each bubble
                    bubbles.RemoveAt(i);

                    //stops searching
                    break;
                }
            }
        }

        /// <summary>
        /// Applies forces to the bubbles using gravity from other bubbles
        /// </summary>
        void Attract()
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
                            if (bubbles[i] != null)

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
        /// The click event
        /// </summary>
        /// <param name="x">The x coord of the click</param>
        /// <param name="y">The y coord of the click</param>
        public void Click(int x, int y)
        {

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //calls the check click event on each bubble
                    bubbles[i].CheckClick(x, y);
        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick()
        {

            //implements gravity
            Attract();

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //ticks each bubble
                    bubbles[i].Move();

            //checks for collisions
            CheckCollision();
        }

        /// <summary>
        /// Draws out the instance of the environment, along with everything in it
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window being draw to</param>
        public void Draw(PaintEventArgs e, Size windowSize)
        {

            //ticks the environment first
            Tick();

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //draws out the current bubble
                    bubbles[i].Draw(e, windowSize, drawVectorLines);
        }

        /// <summary>
        /// Checks each of the bubles to see of any of them collided
        /// </summary>
        void CheckCollision()
        {

            //loops backwards through each of the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)

                    //loops backwards through each of the bubbles
                    for (int j = i - 1; j >= 0; j--)


                        //makes sure that the bubble exists
                        if (bubbles[i] != null)

                            //makes sure that bubbles isnt colliding with itself
                            if (i != j)

                                //checks for a collision with the bubble in the second for loop
                                if (bubbles[i].CheckCollision(bubbles[j]))

                                    //stops searching for more collisions
                                    break;
        }
        #endregion
    }
}
