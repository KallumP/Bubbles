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
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2D(float _x, float _y) {

            x = _x;
            y = _y;
        }
    }
}
