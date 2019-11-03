using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bubbles {
    class Vector2D {

        #region Variables
        /// <summary>
        /// X value
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// Y value
        /// </summary>
        public float y { get; set; }

        static Random rnd = new Random();
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for an empty vector
        /// </summary>
        public Vector2D() {

        }

        /// <summary>
        /// Consctructor for a populated vector
        /// </summary>
        /// <param name="x">Starting x value</param>
        /// <param name="y">Starting y value</param>
        public Vector2D(float _x, float _y) {

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
        public static Vector2D DivideByNumber(Vector2D v, int denominator)
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
        /// Creates a vector2d object with a certain magnitude
        /// </summary>
        /// <param name="magnitude">The magnitude of the force to be created</param>
        /// <returns>A vector2d that points in a random direction</returns>
        public static Vector2D CreateRandomDirection(float magnitude)
        {

            //gets a random x value for the force between negative and positive of the radius
            float xForce = magnitude * ((float)rnd.NextDouble() * 2 - 1); ;

            //calculates the y value for the force
            float yForce = (float)Math.Sqrt(Math.Pow(magnitude, 2) - Math.Pow(xForce, 2));

            //calculates a 50% to flip the y value
            if (rnd.Next(0, 2) == 0)
                yForce = -yForce;

            return new Vector2D(xForce, yForce);
        }
        #endregion
    }
}
