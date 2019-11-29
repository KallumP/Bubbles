using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bubbles
{
    class Rocket
    {
        #region Variables
        /// <summary>
        /// A reference to the environment
        /// </summary>
        Environment e;

        /// <summary>
        /// Time left to use the fuel
        /// </summary>
        int fuelTime;

        /// <summary>
        /// Fastest speed 
        /// </summary>
        int terminalVelocity;

        /// <summary>
        /// The rocket's speed
        /// </summary>
        Vector2D velocity;

        /// <summary>
        /// The angle at which the rocket's thrusters point
        /// </summary>
        float thrustAngle;

        /// <summary>
        /// An enum containing all the statuses that the rocket can be in
        /// </summary>
        public enum Statuses { temp, snapped, takeOff, freeFall }
        #endregion

        #region Properties
        /// <summary>
        /// The position of the rocket
        /// </summary>
        public Vector2D position { get; set; }

        /// <summary>
        /// The mass of the rocket
        /// </summary>
        public int mass { get; set; }

        /// <summary>
        /// The bubble that this rocket is snapped to
        /// </summary>
        public Bubble snappedTo { get; set; }

        /// <summary>
        /// The rocket's status
        /// </summary>
        public Statuses status;
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_mass">Mass of the rocket</param>
        /// <param name="parent">Environment reference</param>
        /// <param name="_fuelTime">The time to use the fuel</param>
        public Rocket(int _mass, Environment parent, int _fuelTime)
        {
            mass = _mass;

            e = parent;

            position = new Vector2D();

            velocity = new Vector2D(0, 0);

            fuelTime = _fuelTime;

            terminalVelocity = 5;

            status = Statuses.temp;
        }

        /// <summary>
        /// Tick event for the rocket
        /// </summary>
        /// <param name="timeInterval">Time passed</param>
        public void Tick(int timeInterval)
        {

            //checks that the rocket is snapped to a bubble
            if (status == Statuses.snapped)

                UpdatePos((int)position.x, (int)position.y);

            //checks to see if the rocket is taking off
            else if (status == Statuses.takeOff)
            {
                GenerateThrust(timeInterval);

                Move();
            }
        }

        /// <summary>
        /// Draws out the rocket
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window</param>
        public void Draw(PaintEventArgs e, Size windowSize)
        {

            e.Graphics.FillRectangle(Brushes.Green, position.x, position.y, 5, 5);

        }

        /// <summary>
        /// Updates the position of the rocket, to either the mouse or the snaped bubble
        /// </summary>
        /// <param name="x">Mouse x</param>
        /// <param name="y">Mouse y</param>
        public void UpdatePos(int x, int y)
        {
            //checks to see if the rocket is temporary
            if (status == Statuses.temp)
            {
                position.x = x;
                position.y = y;
            }
            else
            {
                //thrustAngle = (float)(0.5 * Math.PI + Vector2D.Angle(snappedTo.position, new Vector2D(x, y)));
                thrustAngle = (float)(2 * Math.PI - (3 * Math.PI / 2 + Vector2D.Angle(snappedTo.position, new Vector2D(x, y))));

                position.x = snappedTo.mass * (float)Math.Sin(thrustAngle) + snappedTo.position.x;
                position.y = snappedTo.mass * (float)Math.Cos(thrustAngle) + snappedTo.position.y;
            }

        }

        /// <summary>
        /// Snaps to a particular bubble
        /// </summary>
        /// <param name="b">The bubble to snap to</param>
        /// <param name="x">The mouse x</param>
        /// <param name="y">The mouse y</param>
        public void Snap(Bubble b, int x, int y)
        {

            //sets what bubble it is snapped to
            snappedTo = b;

            //changes the status
            status = Statuses.snapped;

            //updates the position to appear snapped
            UpdatePos(x, y);
        }

        /// <summary>
        /// Detatches from the bubble
        /// </summary>
        public void UnSnap()
        {

            //removes the bubble that was being snapped to
            snappedTo = null;

            //updates the status
            status = Statuses.temp;

        }

        /// <summary>
        /// Takeoff sequence
        /// </summary>
        public void TakeOff()
        {

            //unsnaps from the bubble before taking off
            UnSnap();

            status = Statuses.takeOff;
        }

        /// <summary>
        /// Generates the thrust for the rocket's liftoff
        /// </summary>
        /// <param name="timeInterval">The passed time</param>
        void GenerateThrust(int timeInterval)
        {

            //makes sure that thrust is only being generated while there is still fuel
            if (fuelTime > 0)
            {

                //generates the thrust magnitude
                int thrustMagnitude = 10;

                //creates a force in the direction opposite to the mass
                Vector2D force = Vector2D.CreateVector(thrustMagnitude, thrustAngle);

                //applies the force
                ApplyForce(force);
            }

            //reduces the fuel time by the time time that passed
            fuelTime -= timeInterval;
        }

        /// <summary>
        /// Applies a force to the rocket
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
        /// Moves the rocket by the velocity
        /// </summary>
        void Move()
        {
            position = Vector2D.Add(position, velocity);
        }
        #endregion
    }
}
