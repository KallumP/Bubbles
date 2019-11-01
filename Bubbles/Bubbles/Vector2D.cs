using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bubbles {
    class Vector2D {

        /// <summary>
        /// X value
        /// </summary>
        public float x { get; set; }

        /// <summary>
        /// Y value
        /// </summary>
        public float y { get; set; }

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
        public void Add(Vector2D v)
        {
            x += v.x;
            y += v.y;
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
    }
}
