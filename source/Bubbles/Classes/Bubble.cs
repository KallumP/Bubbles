using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles
{
    class Bubble
    {
        #region Variables
        /// <summary>
        /// A variable used to generate random numbers
        /// </summary>
        static Random rnd = new Random();

        /// <summary>
        /// Keeps track of the next id to assign to a bubble
        /// </summary>
        public static int nextId;

        /// <summary>
        /// An reference to the environment
        /// </summary>
        Environment environment;

        /// <summary>
        /// The velocity
        /// </summary>
        Vector2D velocity;

        /// <summary>
        /// The fastest a bubble can move
        /// </summary>
        int terminalVelocity;
        #endregion

        #region Properties
        /// <summary>
        /// Used to identify the bubble
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Stores if the bubble can move
        /// </summary>
        public bool Static { get; set; }

        /// <summary>
        /// Stores if the bubble will attract other bubbles
        /// </summary>
        public bool ZeroMass { get; set; }

        /// <summary>
        /// The position (center of the bubble)
        /// </summary>
        public Vector2D position { get; set; }

        /// <summary>
        /// The mass (radius is direcly correlated to mass)
        /// </summary>
        public int mass { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for a bubble
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="parent">An instance to the environment</param>
        /// <param name="_static">If the bubble can move</param>
        /// <param name="_zeroMass">If the bubble will have a gravitational force</param>
        public Bubble(int _mass, Vector2D _position, Environment parent, bool _static, bool _zeroMass)
        {
            Setup(_mass, _position, parent, _static, _zeroMass);
        }

        /// <summary>
        /// Constructor for creating a bubble with an inital force
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="_force">The starting force</param>
        /// <param name="parent">An instance to the environment</param>
        /// <param name="_static">If the bubble can move</param>
        /// <param name="_zeroMass">If the bubble will have a gravitational force</param>
        public Bubble(int _mass, Vector2D _position, Vector2D _force, Environment parent, bool _static, bool _zeroMass)
        {

            Setup(_mass, _position, parent, _static, _zeroMass);

            ApplyForce(_force);
        }

        /// <summary>
        /// Sets up the bubble
        /// </summary>
        /// <param name="_mass"></param>
        /// <param name="_position"></param>
        /// <param name="parent"></param>
        /// <param name="_static"></param>
        /// <param name="_zeroMass"></param>
        public void Setup(int _mass, Vector2D _position, Environment parent, bool _static, bool _zeroMass)
        {
            environment = parent;
            mass = _mass;
            position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

            terminalVelocity = 10;

            Static = _static;

            ZeroMass = _zeroMass;


            //assgns the next id
            Id = nextId++;
        }

        /// <summary>
        /// Checks to see if the bubble was clicked
        /// </summary>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        public void CheckClick(int x, int y)
        {

            //gets the x distance between the two points
            float xDist = position.x - x;

            //gets the y distance between the two points
            float yDist = position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if (dist < mass)
                Click();
        }

        /// <summary>
        /// What happens when the bubble is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Click()
        {
            Explode();
        }

        /// <summary>
        /// Checks if the inputed mouse location hovered over this bubble
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public bool CheckHover(int x, int y)
        {
            //gets the x distance between the two points
            float xDist = position.x - x;

            //gets the y distance between the two points
            float yDist = position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if (dist < mass)
                return true;

            return false;
        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window being drawn to</param>
        /// <param name="velocityLines">If the program should draw the velocity lines of the bubble</param>
        public void Draw(PaintEventArgs e, Size windowSize, bool velocityLines)
        {
            Point pointer = new Point();
            bool draw = true;

            //sets up the window size to be right actual size
            windowSize.Width -= 17;
            windowSize.Height -= 40;

            int inset = 5;

            //checks to see if any part of the bubble was within the width
            if (position.x - mass < windowSize.Width - inset && position.x + mass > inset)
            {

                //saves the x position of the pointer as the bubble's x postion
                pointer.X = (int)position.x;
            }
            else if (position.x - mass > windowSize.Width - inset)
            {

                //saves the x position of the pointer as the right most side of the window
                pointer.X = windowSize.Width - inset;
                draw = false;
            }
            else if (position.x + mass < inset)
            {

                //saves the x position of the pointer as the left most side of the window
                pointer.X = inset;
                draw = false;
            }


            if (position.y - mass < windowSize.Height - inset && position.y + mass > inset)
            {

                //saves the y position of the pointer as the bubble's y postion
                pointer.Y = (int)position.y;
            }
            else if (position.y - mass > windowSize.Height - inset)
            {

                //saves the y position of the pointer as the right most side of the window
                pointer.Y = windowSize.Height - inset;
                draw = false;
            }
            else if (position.y + mass < inset)
            {

                //saves the y position of the pointer as the left most side of the window
                pointer.Y = inset;
                draw = false;
            }

            //checks to see if the bubble should be drawn
            if (draw)

                //draws the bubble with a default color, position and radius
                e.Graphics.DrawEllipse(Pens.Blue, position.x - mass, position.y - mass, mass * 2, mass * 2);

            else

                //draws out a pointer showing where the bubble is offscreen
                e.Graphics.FillEllipse(Brushes.Red, pointer.X, pointer.Y, 5, 5);


            //checks to see if the velocity lines should be drawn
            if (velocityLines)

                //draws out the velocity of the bubble
                e.Graphics.DrawLine(Pens.Black, position.x, position.y, position.x + velocity.x * 3, position.y + velocity.y * 3);

            //draws out the id of the bubble
            //e.Graphics.DrawString(Id.ToString(), SystemFonts.DefaultFont, Brushes.Blue, position.x, position.y);
        }

        /// <summary>
        /// Applies a force to the bubble using newtonian physics
        /// </summary>
        /// <param name="_force">The force to apply</param>
        public void ApplyForce(Vector2D _force)
        {
            //calculates the accelaration of the bubble
            Vector2D accelaration = Vector2D.DivideByNumber(_force, mass);

            //calculates the velocity of the bubble
            velocity = Vector2D.Add(velocity, accelaration);

            //checks to see if the veclocity is too fast
            if (velocity.Magnitude() > terminalVelocity)

                //constrains the velocity
                velocity.Constrain(terminalVelocity);
        }

        /// <summary>
        /// Moves the bubble by its velocity
        /// </summary>
        public void Move()
        {
            position = Vector2D.Add(position, velocity);
        }

        /// <summary>
        /// Checks to see if there was a collision with this and the input bubble
        /// </summary>
        /// <param name="b">The bubble to check for a collision with</param>
        /// <returns>If there was a collision</returns>
        public bool CheckCollision(Bubble b)
        {

            //checks to see if the distance between the two points is smaller than the two radii (mass = radius)
            if (Vector2D.Distance(position, b.position) <= mass + b.mass)
            {
                //starts the collision sequence
                Collide(b);

                //lets the environment know that there was a collision
                return true;
            }
            else

                //lets the environment know that there was no collision
                return false;
        }

        /// <summary>
        /// The collision sequence
        /// </summary>
        /// <param name="b">The bubble that this collided with</param>
        void Collide(Bubble b)
        {
            //declares a variable used to store what position to put the new bubble at
            Vector2D positionToTake;

            //checks to see if the two masses were equal
            if (mass == b.mass)

                //sets the new bubble's position to the midpoint of the two colliding bubbles
                positionToTake = Vector2D.Midpoint(position, b.position);

            //checks to see if this has less mass than b
            else if (mass < b.mass)

                //sets the new bubble's position to b's position
                positionToTake = b.position;
            else

                //sets the new bubble's position to this' position
                positionToTake = position;

            //adds the new bubble with the combined mass
            environment.AddBubble(new Bubble(mass + b.mass, positionToTake, environment, false, false));

            //removes the two colliding bubbles
            environment.RemoveBubble(Id);
            environment.RemoveBubble(b.Id);
        }

        /// <summary>
        /// Makes the bubble explode into smaller bubbles
        /// </summary>
        public void Explode()
        {

            //sets up how many bubbles to take in the explosion
            int newBubbleCount = rnd.Next(20, 30);

            //sets up the size of the new bubbles
            int newMass = mass / newBubbleCount;

            //makes sure that the new masses are not too small
            if (newMass > 1)

                //loops through and makes the correct amount of bubbles
                for (int i = 0; i < newBubbleCount; i++)
                {

                    //creates a new random force magnitude
                    int forceMagnitude = rnd.Next(100, 300);

                    //creates the gravitational force
                    Vector2D force = Vector2D.CreateVector(forceMagnitude);

                    //adds a bubble into the environment
                    environment.AddBubble(new Bubble(newMass, Vector2D.Add(position, Vector2D.DivideByNumber(force, 2f)), force, environment, false, false));
                }

            //Removes this bubble instance after the explosion
            environment.RemoveBubble(Id);
        }
        #endregion
    }
}
