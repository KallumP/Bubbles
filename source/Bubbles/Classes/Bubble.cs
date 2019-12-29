using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bubbles {
    class Bubble {

        #region Statics

        public static int startingMass = 20;

        public static bool startingStatic = false;

        public static bool startingZeroMass = true;

        public static int startingTerminalVel = 10;

        public static float startingForce = 100;

        public static float startingAngle = 3.1415f;



        /// <summary>
        /// Debug value that determins whether the vector lines should be draw
        /// </summary>
        public static bool drawVelocityLines = false;

        /// <summary>
        /// Debug vaule that determins whether the trail should be drawn
        /// </summary>
        public static bool drawTrailLines = true;

        /// <summary>
        /// The amount of trail points allowed in the trail list
        /// </summary>
        public static int trailLength = 200;
        #endregion

        #region Variables
        /// <summary>
        /// A variable used to generate random numbers
        /// </summary>
        static Random rnd = new Random();

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

        /// <summary>
        /// A list of all the positions
        /// </summary>
        List<Vector2D> trail;

        /// <summary>
        /// An enum containing all the statuses a bubble can be in
        /// </summary>
        public enum Statuses { FreeFall, MouseControl }
        #endregion

        #region Properties

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
        public Vector2D Position { get; set; }

        /// <summary>
        /// The mass (radius is direcly correlated to mass)
        /// </summary>
        public int Mass { get; set; }

        /// <summary>
        /// The bubble's status
        /// </summary>
        public Statuses status;
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
        public Bubble(int _mass, Vector2D _position, Environment parent, bool _static, bool _zeroMass) {

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
        public Bubble(int _mass, Vector2D _position, Vector2D _force, Environment parent, bool _static, bool _zeroMass) {

            Setup(_mass, _position, parent, _static, _zeroMass);

            ApplyForce(_force);
        }

        /// <summary>
        /// A constructor that just uses the default values
        /// </summary>
        /// <param name="parent">Reference to the environment</param>
        /// <param name="_position">The position of the bubble</param>
        public Bubble(Environment parent, Vector2D _position) {

            //Sets up the bubble using default values
            Setup(startingMass, _position, parent, startingStatic, startingZeroMass);

            //applies the default force
            ApplyForce(Vector2D.CreateVector(startingForce, startingAngle));
        }

        /// <summary>
        /// Sets up the bubble using values from the constructor
        /// </summary>
        /// <param name="_mass">Mass of the bubble</param>
        /// <param name="_position">Position of the bubble</param>
        /// <param name="parent">Reference to the environment</param>
        /// <param name="_static">If the bubble can move</param>
        /// <param name="_zeroMass">If the bubble has any mass</param>
        public void Setup(int _mass, Vector2D _position, Environment parent, bool _static, bool _zeroMass) {

            environment = parent;
            Mass = _mass;
            Position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

            terminalVelocity = startingTerminalVel;

            Static = _static;

            ZeroMass = _zeroMass;

            trail = new List<Vector2D>();
        }

        /// <summary>
        /// Checks to see if the bubble was clicked
        /// </summary>
        /// <param name="x">The x coordinate of the mouse</param>
        /// <param name="y">The y coordinate of the mouse</param>
        /// <param name="mode"> The mode of the program</param>
        public void CheckClick(int x, int y, MainWindow.InteractiveModes mode) {

            //gets the x distance between the two points
            float xDist = Position.x - x;

            //gets the y distance between the two points
            float yDist = Position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if (dist < Mass)
                MouseDown(mode);
        }

        /// <summary>
        /// Bubble mouse down event
        /// </summary>
        void MouseDown(MainWindow.InteractiveModes mode) {

            //checks to see if explode mode was on
            if (mode == MainWindow.InteractiveModes.Explode)
                Explode();

            //checks to see if ineraction mode was on
            else if (mode == MainWindow.InteractiveModes.Interact)
                status = Statuses.MouseControl;
        }

        /// <summary>
        /// Bubble mouse up event
        /// </summary>
        /// <param name="mode"></param>
        public void MouseUp(MainWindow.InteractiveModes mode) {

            //makes sure that the bubble was in mousecontrol mode
            if (status == Statuses.MouseControl)

                //checks to see if the mode was set to interact
                if (mode == MainWindow.InteractiveModes.Interact)

                    SetToFreeFall();
        }

        /// <summary>
        /// Bubble mouse move event
        /// </summary>
        /// <param name="x">The x coordinate of the mouse</param>
        /// <param name="y">The y coordinate of the mouse</param>
        /// <param name="mode">The mode of the program</param>
        public void MouseMove(int x, int y, MainWindow.InteractiveModes mode) {

            //checks to see if the mode was set to interact
            if (mode == MainWindow.InteractiveModes.Interact)

                //makes sure that the bubble was in mousecontrol mode
                if (status == Statuses.MouseControl)

                    //moves the bubble to the mouse position
                    ConstrainToMouse(new Vector2D(x, y));
        }

        /// <summary>
        /// Checks if the input coordinates were inside this bubble
        /// </summary>
        /// <param name="x">Input x</param>
        /// <param name="y">Input y</param>
        public bool CheckInside(int x, int y) {

            //gets the x distance between the two points
            float xDist = Position.x - x;

            //gets the y distance between the two points
            float yDist = Position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if (dist < Mass)
                return true;

            return false;
        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window being drawn to</param>
        public void Draw(PaintEventArgs e, Size windowSize) {

            Point pointer = new Point();
            bool draw = true;

            //sets up the window size to be right actual size
            windowSize.Width -= 17;
            windowSize.Height -= 40;

            int inset = 5;

            //checks to see if any part of the bubble was within the width
            if (Position.x - Mass < windowSize.Width - inset && Position.x + Mass > inset) {

                //saves the x position of the pointer as the bubble's x postion
                pointer.X = (int)Position.x;

            } else if (Position.x - Mass > windowSize.Width - inset) {

                //saves the x position of the pointer as the right most side of the window
                pointer.X = windowSize.Width - inset;
                draw = false;

            } else if (Position.x + Mass < inset) {

                //saves the x position of the pointer as the left most side of the window
                pointer.X = inset;
                draw = false;
            }


            if (Position.y - Mass < windowSize.Height - inset && Position.y + Mass > inset) {

                //saves the y position of the pointer as the bubble's y postion
                pointer.Y = (int)Position.y;

            } else if (Position.y - Mass > windowSize.Height - inset) {

                //saves the y position of the pointer as the right most side of the window
                pointer.Y = windowSize.Height - inset;
                draw = false;

            } else if (Position.y + Mass < inset) {

                //saves the y position of the pointer as the left most side of the window
                pointer.Y = inset;
                draw = false;
            }

            //checks to see if the bubble should be drawn
            if (draw)

                //draws the bubble with a default color, position and radius
                e.Graphics.DrawEllipse(Pens.Blue, Position.x - Mass, Position.y - Mass, Mass * 2, Mass * 2);

            else

                //draws out a pointer showing where the bubble is offscreen
                e.Graphics.FillEllipse(Brushes.Red, pointer.X, pointer.Y, 5, 5);


            //checks to see if the velocity lines should be drawn
            if (drawVelocityLines)

                //draws out the velocity of the bubble
                e.Graphics.DrawLine(Pens.Black, Position.x, Position.y, Position.x + velocity.x * 3, Position.y + velocity.y * 3);

            //checks to see if the trail should be draw
            if (drawTrailLines)

                //loops through the trail
                foreach (Vector2D t in trail)

                    //draws the trail
                    e.Graphics.DrawEllipse(Pens.Red, t.x - 1, t.y - 1, 2, 2);
        }

        /// <summary>
        /// Applies a force to the bubble using newtonian physics
        /// </summary>
        /// <param name="_force">The force to apply</param>
        public void ApplyForce(Vector2D _force) {

            //calculates the accelaration of the bubble
            Vector2D accelaration = Vector2D.DivideByNumber(_force, Mass);

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
        public void Move() {

            SaveTrail();

            if (status == Statuses.FreeFall)
                Position = Vector2D.Add(Position, velocity);
        }

        /// <summary>
        /// Checks to see if there was a collision with this and the input bubble
        /// </summary>
        /// <param name="b">The bubble to check for a collision with</param>
        /// <returns>If there was a collision</returns>
        public bool CheckCollision(Bubble b) {

            //checks to see if the distance between the two points is smaller than the two radii (mass = radius)
            if (Vector2D.Distance(Position, b.Position) <= Mass + b.Mass) {

                //starts the collision sequence
                Collide(b);

                //lets the environment know that there was a collision
                return true;

            } else

                //lets the environment know that there was no collision
                return false;
        }

        /// <summary>
        /// The collision sequence
        /// </summary>
        /// <param name="b">The bubble that this collided with</param>
        void Collide(Bubble b) {

            //declares a variable used to store what position to put the new bubble at
            Vector2D positionToTake;

            //checks to see if the two masses were equal
            if (Mass == b.Mass)

                //sets the new bubble's position to the midpoint of the two colliding bubbles
                positionToTake = Vector2D.Midpoint(Position, b.Position);

            //checks to see if this has less mass than b
            else if (Mass < b.Mass)

                //sets the new bubble's position to b's position
                positionToTake = b.Position;

            else

                //sets the new bubble's position to this' position
                positionToTake = Position;


            //calculates the net velocity of the two colliding bubbles
            Vector2D net = Vector2D.Add(b.velocity, velocity);

            //calculates how much force is needed to push the new bubble to the net velocity
            //Vector2D forceForNet = Vector2D.DivideByNumber(net, 1f / (mass + b.mass));

            //creates the new bubble to be added to the simulation
            Bubble next = new Bubble(Mass + b.Mass, positionToTake, net, environment, false, false);


            //checks to see if any rockets were attatched to the two bubbles being worked with
            environment.CheckForReSnap(this, next);
            environment.CheckForReSnap(b, next);

            //adds the new bubble with the combined mass
            environment.AddBubble(next);

            //removes the two colliding bubbles
            environment.RemoveBubble(this);
            environment.RemoveBubble(b);
        }

        /// <summary>
        /// Makes the bubble explode into smaller bubbles
        /// </summary>
        public void Explode() {

            //sets up how many bubbles to take in the explosion
            int newBubbleCount = rnd.Next(20, 30);

            //sets up the size of the new bubbles
            int newMass = Mass / newBubbleCount;

            //makes sure that the new masses are big enough to explode
            if (newMass > 1) {
                //loops through and makes the correct amount of bubbles
                for (int i = 0; i < newBubbleCount; i++) {

                    //creates a new random force magnitude
                    int forceMagnitude = rnd.Next(100, 300);

                    //creates the gravitational force
                    Vector2D force = Vector2D.CreateVector(forceMagnitude);

                    //adds a bubble into the environment
                    environment.AddBubble(new Bubble(newMass, Vector2D.Add(Position, Vector2D.DivideByNumber(force, 2f)), force, environment, false, false));
                }


                //checks to see if any of the rockets need to unsnapped from this bubble
                environment.CheckForUnSnap(this);

                //Removes this bubble instance after the explosion
                environment.RemoveBubble(this);
            }
        }

        /// <summary>
        /// Saves the position in the trail list
        /// </summary>
        void SaveTrail() {

            //checks to see if there was anything in the trail list
            if (trail.Count > 0) {

                //checks to see if the bubble has moved since the last trail addition
                if (Position != trail[trail.Count - 1]) {

                    //checks to see if the trail was too long
                    if (trail.Count >= trailLength)

                        //removes the first trail point
                        trail.RemoveAt(0);

                    //saves the position to draw out the trail
                    trail.Add(Position);
                }

            } else {

                //saves the position to draw out the trail
                trail.Add(Position);
            }
        }

        /// <summary>
        /// Sets the bubble back to free fall
        /// </summary>
        void SetToFreeFall() {

            status = Statuses.FreeFall;

        }

        /// <summary>
        /// Constrains the position of the bubble to the position of the mouse
        /// </summary>
        /// <param name="newPosition">The position of the mouse</param>
        void ConstrainToMouse(Vector2D newPosition) {

            velocity = Vector2D.Difference(Position, newPosition);

            Position = newPosition;
        }
        #endregion
    }
}
