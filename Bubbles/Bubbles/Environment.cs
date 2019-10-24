using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bubbles {
    class Environment {

        /// <summary>
        /// Used to store the bubbles in the environment
        /// </summary>
        List<Bubble> bubbles;

        /// <summary>
        /// Constructor
        /// </summary>
        public Environment() {

            //instantiates the list of bubbles
            bubbles = new List<Bubble>();
        }

        /// <summary>
        /// Adds a new bubbles into the environment's list of bubbles
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_radius">The radius of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        public void AddBubble(int _mass, int _radius, int x, int y) {

            //adds the bubble into the list
            bubbles.Add(new Bubble(_mass, _radius, new Vector2D(x, y)));
        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick() {

            //loops through the bubbles
            foreach(Bubble b in bubbles)

                //ticks each bubble
                b.Tick();

        }

        /// <summary>
        /// Draws out the instance of the environment, along with everything in it
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e) {

            //loops through the bubbles
            foreach(Bubble b in bubbles)

                //draws out the current bubble
                b.Draw(e);
        }
    }
}
