using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bubbles {
    class Rocket {

        #region Statics
        public static int startingMass = 30;
        public static int startingFuelTime = 500;
        public static int startingTerminalVel = 5;
        #endregion

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
        /// An enum containing all the statuses a rocket can be in
        /// </summary>
        public enum Statuses { temp, tempSnapped, snapped, unsnapped, takeOff, freeFall, collided }
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

        /// <summary>
        /// The time taken for a rocket to become collidable after taking off
        /// </summary>
        public int timeTillCollidable { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Environment reference</param>
        public Rocket(Environment parent) {

            e = parent;

            mass = startingMass;

            fuelTime = startingFuelTime;

            terminalVelocity = startingTerminalVel;

            timeTillCollidable = 1000;

            position = new Vector2D();

            velocity = new Vector2D(0, 0);

            status = Statuses.temp;
        }

        /// <summary>
        /// Tick event for the rocket
        /// </summary>
        /// <param name="timeInterval">Time passed</param>
        public void Tick(int timeInterval) {

            //checks that the rocket is snapped to a bubble
            if (status == Statuses.snapped)

                UpdatePos((int)position.x, (int)position.y);

            //checks to see if the rocket has unsnapped
            else if (status == Statuses.unsnapped)

                Move();

            //checks that the rocket has collided
            else if (status == Statuses.collided)

                UpdatePos((int)position.x, (int)position.y);

            //checks to see if the rocket is taking off
            else if (status == Statuses.takeOff) {

                GenerateThrust(timeInterval);

                Move();

                //keeps track of time
                timeTillCollidable -= timeInterval;
            }

            //Checks to see if the rocket is freefalling
            else if (status == Statuses.freeFall) {

                Move();

                //keeps track of time
                timeTillCollidable -= timeInterval;
            }
        }

        /// <summary>
        /// Draws out the rocket
        /// </summary>
        /// <param name="e"></param>
        /// <param name="windowSize">The size of the window</param>
        public void Draw(PaintEventArgs e, Size windowSize, ViewPort camera) {

            e.Graphics.FillEllipse(Brushes.Green, position.x - 5, position.y - 5, 10, 10);

        }

        /// <summary>
        /// Snaps to a particular bubble
        /// </summary>
        /// <param name="b">The bubble to snap to</param>
        /// <param name="x">The mouse x</param>
        /// <param name="y">The mouse y</param>
        public void Snap(Bubble b, int x, int y) {

            //sets what bubble it is snapped to
            snappedTo = b;

            //changes the status to snapped
            status = Statuses.tempSnapped;

            //updates the position to appear snapped
            UpdateSnapPos(x, y);
        }

        /// <summary>
        /// Snapps to a newly created bubble
        /// </summary>
        /// <param name="b">The bubble to snap to</param>
        /// <param name="collided">If the rocket has collided with a bubble</param>
        public void ReSnap(Bubble b, bool collided) {

            //sets what bubble it is snapped to
            snappedTo = b;

            UpdateSnapPos((int)position.x, (int)position.y);

            //checks to see if this resnap was a result of a collision
            if (collided) {

                //checks to see if the rocket had taken off or was free falling
                if (status == Statuses.freeFall || status == Statuses.takeOff)

                    //changes the status to collided
                    status = Statuses.collided;
            }

            //checks to see if the rocket was unsnapped
            else if (status == Statuses.unsnapped)

                //changes the status to snapped
                status = Statuses.snapped;
        }

        /// <summary>
        /// Detatches from the bubble
        /// </summary>
        public void UnSnap() {

            //removes the bubble that was being snapped to
            snappedTo = null;

            //checks to see if the rocket was temp snapped
            if (status == Statuses.tempSnapped)

                //changes the status to temp
                status = Statuses.temp;

            //checks to see if the status was snapped
            else if (status == Statuses.snapped)

                //changes the status to unsnapped
                status = Statuses.unsnapped;

            //checks to see if the rocket had taken off and collided
            else if (status == Statuses.collided)

                //changes the status to freefall
                status = Statuses.freeFall;

        }

        /// <summary>
        /// Removes the temporary status from the rocket
        /// </summary>
        public void RemoveTemp() {

            //saves the status as not being temporary
            status = Statuses.snapped;
        }

        /// <summary>
        /// Updates the position for the first time after being snapped
        /// </summary>
        /// <param name="x">Input x</param>
        /// <param name="y">Input y</param>
        public void UpdateSnapPos(int x, int y) {

            //calculates the angle between the bubble center and the rocket
            thrustAngle = (float)(2 * Math.PI - (3 * Math.PI / 2 + Vector2D.Angle(snappedTo.Position, new Vector2D(x, y))));

            //updates the position to stay snapped to the bubble
            position.x = snappedTo.Mass * (float)Math.Sin(thrustAngle) + snappedTo.Position.x;
            position.y = snappedTo.Mass * (float)Math.Cos(thrustAngle) + snappedTo.Position.y;
        }

        /// <summary>
        /// Updates the position of the rocket, to either the mouse or the snaped bubble
        /// </summary>
        /// <param name="x">Mouse x</param>
        /// <param name="y">Mouse y</param>
        public void UpdatePos(int x, int y) {

            //checks to see if the rocket is temporary
            if (status == Statuses.temp) {

                position.x = x;
                position.y = y;

            } else {

                //updates the position to stay snapped to the bubble
                position.x = snappedTo.Mass * (float)Math.Sin(thrustAngle) + snappedTo.Position.x;
                position.y = snappedTo.Mass * (float)Math.Cos(thrustAngle) + snappedTo.Position.y;
            }
        }

        /// <summary>
        /// Takeoff sequence
        /// </summary>
        public void TakeOff() {

            //unsnaps from the bubble before taking off
            UnSnap();

            status = Statuses.takeOff;
        }

        /// <summary>
        /// Generates the thrust for the rocket's liftoff
        /// </summary>
        /// <param name="timeInterval">The passed time</param>
        void GenerateThrust(int timeInterval) {

            //makes sure that thrust is only being generated while there is still fuel
            if (fuelTime > 0) {

                //generates the thrust magnitude
                int thrustMagnitude = 10;

                //creates a force in the direction opposite to the mass
                Vector2D force = Vector2D.CreateVector(thrustMagnitude, thrustAngle);

                //applies the force
                ApplyForce(force);

                //reduces the fuel time by the time time that passed
                fuelTime -= timeInterval;

            } else {

                //changes the status to freefall
                status = Statuses.freeFall;
            }
        }

        /// <summary>
        /// Applies a force to the rocket
        /// </summary>
        /// <param name="_force">The force to apply</param>
        public void ApplyForce(Vector2D _force) {

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
        void Move() {
            position = Vector2D.Add(position, velocity);
        }
        #endregion
    }
}
