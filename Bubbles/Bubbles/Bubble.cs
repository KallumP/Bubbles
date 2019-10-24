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
        /// Keeps track of the next id to assign to a bubble
        /// </summary>
        static int nextID = 0;

        /// <summary>
        /// Used to identify the bubble
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// An instance to the environment
        /// </summary>
        Environment environment;

        /// <summary>
        /// The mass (radius is direcly correlated to mass)
        /// </summary>
        int mass;

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
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_radius">The radius of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="parent">An instance to the environment</param>
        public Bubble(int _mass, Vector2D _position, Environment parent) {

            environment = parent;
            mass = _mass;
            position = _position;

            //assgns the next id
            id = nextID++;
        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick() {

        }

        /// <summary>
        /// Checks to see if the bubble was clicked
        /// </summary>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        public void CheckClick(int x, int y) {

            //gets the x distance between the two points
            float xDist = position.x - x;

            //gets the y distance between the two points
            float yDist = position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if(dist < mass)
                Click();
        }

        /// <summary>
        /// What happens when the bubble is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Click() {
            Explode();
        }

        /// <summary>
        /// Makes the bubble explode into smaller bubbles
        /// </summary>
        public void Explode() {

            //adds two new bubbles into the environment
            environment.AddBubble(mass / 2, (int)position.x - 30, (int)position.y - 30);
            environment.AddBubble(mass / 2, (int)position.x + 30, (int)position.y + 30);

            //tells the environment to remove itself
            environment.RemoveBubble(id);

        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e) {

            //draws the bubble with a default color, position and radius
            e.Graphics.FillEllipse(
                Brushes.Blue,
                position.x - mass,
                position.y - mass,
                mass * 2,
                mass * 2);

        }
        #endregion
    }
}
