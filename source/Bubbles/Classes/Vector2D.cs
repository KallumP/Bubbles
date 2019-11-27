using System;

namespace Bubbles
{
    class Vector2D
    {
        #region Variables
        /// <summary>
        /// X value
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// Y value
        /// </summary>
        public float y { get; set; }

        /// <summary>
        /// Random number generator
        /// </summary>
        static Random rnd = new Random();
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for an empty vector
        /// </summary>
        public Vector2D()
        {

        }

        /// <summary>
        /// Consctructor for a populated vector
        /// </summary>
        /// <param name="x">Starting x value</param>
        /// <param name="y">Starting y value</param>
        public Vector2D(float _x, float _y)
        {

            x = _x;
            y = _y;
        }

        /// <summary>
        /// Adds a Vector2D object's components onto this Vector2D object.
        /// </summary>
        /// <param name="v">The Vector2D object to be added on</param>
        public static Vector2D Add(Vector2D v1, Vector2D v2)
        {
            Vector2D returnVector = new Vector2D();

            returnVector.x = v1.x + v2.x;
            returnVector.y = v1.y + v2.y;

            return returnVector;
        }

        /// <summary>
        /// Divides a vector by a single number
        /// </summary>
        /// <param name="v">The vector to be divided</param>
        /// <param name="denominator">The number to divide by</param>
        /// <returns>The new divided vector</returns>
        public static Vector2D DivideByNumber(Vector2D v, float denominator)
        {
            //The vector that will be returned
            Vector2D returnVector = new Vector2D();

            //divides the different components of the vector
            returnVector.x = v.x / denominator;
            returnVector.y = v.y / denominator;

            //returns the vector
            return returnVector;
        }

        /// <summary>
        /// Creates a vector2d object with only a known magnitude
        /// </summary>
        /// <param name="magnitude">The magnitude of the force to be created</param>
        /// <returns>A vector2d that points in a random direction</returns>
        public static Vector2D CreateVector(float magnitude)
        {

            //gets a random x value for the force between negative and positive of the radius
            float xForce = magnitude * ((float)rnd.NextDouble() * 2 - 1); ;

            //calculates the y value for the force (using the x value to keep the magnitude constant)
            float yForce = (float)Math.Sqrt(Math.Pow(magnitude, 2) - Math.Pow(xForce, 2));

            //calculates a 50% chance to flip the y value
            if (rnd.Next(0, 2) == 0)
                yForce = -yForce;

            return new Vector2D(xForce, yForce);
        }

        /// <summary>
        /// Creates a vector with a known magnitude and angle
        /// </summary>
        /// <param name="magnitude">The magnitude of the vector to make</param>
        /// <param name="angle">The angle of the vector to make</param>
        /// <returns>The vector</returns>
        public static Vector2D CreateVector(float magnitude, float angle)
        {

            //instantiates a vector
            Vector2D returnVector = new Vector2D();

            //calculates the x components of the displacement and force vector
            returnVector.x = magnitude * (float)Math.Sin(angle);

            //calculates the y component of the displacement and force vectors
            returnVector.y = magnitude * (float)Math.Cos(angle);

            //returns the vector
            return returnVector;
        }

        /// <summary>
        /// Creates a vector2d object with a known magnitude and angle
        /// </summary>
        /// <param name="magnitude">The magnitude of the vector to make</param>
        /// <param name="angle">The angle to rotate the angle by</param>
        /// <returns>A Vector2D object with the correct magnitude and angle</returns>
        public static Vector2D CreateGravityFixedVector(float magnitude, float angle)
        {

            //instantiates a vector
            Vector2D returnVector = new Vector2D();

            //calculates the x components of the displacement and force vector
            returnVector.x = magnitude * (float)Math.Sin(angle + Math.PI / 2);

            //calculates the y component of the displacement and force vectors
            returnVector.y = magnitude * (float)Math.Cos(angle - Math.PI / 2);


            //returns the vector
            return returnVector;
        }

        /// <summary>
        /// Constrains the vector to a certain magnitude
        /// </summary>
        /// <param name="v">The vector to constrain</param>
        /// <param name="magnitude">The magnitude to constrain the vector by</param>
        /// <returns>The constrained vector</returns>
        public void Constrain(float magnitude)
        {
            //calculates the angle of the vector (0 based)
            float angle = Angle();

            //creates a new vector with the new magnitude
            Vector2D constrainedVector = CreateVector(magnitude, angle);

            //sets the vectors components to the new vector
            x = constrainedVector.x;
            y = constrainedVector.y;
        }

        /// <summary>
        /// Returns the distance between two position vectors
        /// </summary>
        /// <param name="v1">The first position</param>
        /// <param name="v2">The second position</param>
        /// <returns>The distance between the two entered points</returns>
        public static float Distance(Vector2D v1, Vector2D v2)
        {

            //calculates the distance on the x axis
            float xDist = v1.x - v2.x;

            //calculates the squared x distance
            float xDist2 = (float)Math.Pow(xDist, 2);


            //calculates the distance on the y axis
            float yDist = v1.y - v2.y;

            //calculates the squared y distance
            float yDist2 = (float)Math.Pow(yDist, 2);


            //calculates the distance using pythagoras
            float distance = (float)Math.Sqrt(xDist2 + yDist2);

            //returns the distance
            return distance;
        }

        /// <summary>
        /// Gets the center of two position vectors
        /// </summary>
        /// <param name="v1">The first position</param>
        /// <param name="v2">The second position</param>
        /// <returns>The center of the two vectors</returns>
        public static Vector2D Midpoint(Vector2D v1, Vector2D v2)
        {
            //declares and instantiates a vector to return
            Vector2D halfDistance = new Vector2D();

            //finds out what half the distance is between the x and the y
            halfDistance.x = (v2.x - v1.x) / 2;
            halfDistance.y = (v2.y - v1.y) / 2;

            //gets the midpoint by adding the half distance to the first vector
            Vector2D returnVector = Add(halfDistance, v1);

            //returns the midpoint posisition
            return returnVector;
        }

        /// <summary>
        /// Calculates the magnitude for the vector (0 based)
        /// </summary>
        /// <returns>The magnitude of the vector</returns>
        public float Magnitude()
        {
            //finds the magnitude of the vector using pythagorus
            float magnitude = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            //returns the magnitude
            return magnitude;
        }

        /// <summary>
        /// Calculates the angle of a vector
        /// </summary>
        /// <param name="v">The vector who's angle is to be found</param>
        /// <returns>The angle of the vector</returns>
        public float Angle()
        {

            //calculates the vectors angle
            float angle = (float)Math.Atan2(x, y);

            //returns the angle
            return angle;
        }

        /// <summary>
        /// Calculates the angle between two position vectors 
        /// </summary>
        /// <param name="v1">The first position</param>
        /// <param name="v2">The second position</param>
        /// <returns>The angle, north based, in radians (0 radians would be straight up)</returns>
        public static float Angle(Vector2D v1, Vector2D v2)
        {

            //calculates the distance on the x axis
            float xDist = v2.x - v1.x;

            //calculates the distance on the y axis
            float yDist = v2.y - v1.y;

            //calculates the angle between the two positions
            float angle = (float)Math.Atan2(yDist, xDist);

            //returns the angle
            return angle;
        }
        #endregion
    }
}
