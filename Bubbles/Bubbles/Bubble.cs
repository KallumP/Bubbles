using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bubbles {
    class Bubble {

        #region Variables
        /// <summary>
        /// The mass
        /// </summary>
        int mass;

        /// <summary>
        /// The radius
        /// </summary>
        int radius;

        /// <summary>
        /// The position (center of the bubble)
        /// </summary>
        Vector2D position;

        /// <summary>
        /// The velocity
        /// </summary>
        Vector2D velocity;

        /// <summary>
        /// The force
        /// </summary>
        Vector2D force;
        #endregion

        #region Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public Bubble(int _mass, int _radius, Vector2D _position) {

            mass = _mass;
            radius = _radius;
            position = _position;

        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick() {

        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e) {

            //draws the bubble with a default color, position and radius
            e.Graphics.FillEllipse(
                Brushes.Blue, 
                position.x - radius, 
                position.y - radius, 
                radius * 2, 
                radius * 2);

        }
        #endregion
    }
}
