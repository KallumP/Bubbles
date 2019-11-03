﻿using System;
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
        public List<Bubble> bubbles;

        /// <summary>
        /// Constructor
        /// </summary>
        public Environment() {

            //resets the bubble id counter
            Bubble.nextId = 0;

            //instantiates the list of bubbles
            bubbles = new List<Bubble>();
        }

        /// <summary>
        /// Adds a new bubbles into the environment's list of bubbles
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_radius">The radius of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        public void AddBubble(Bubble b) {

            //adds the bubble into the list
            bubbles.Add(b);
        }

        /// <summary>
        /// Removes a selected bubble from the list
        /// </summary>
        /// <param name="id">The id of the bubble to remove</param>
        public void RemoveBubble(int id) {

            //loops backwards through the bubbles
            for(int i = bubbles.Count - 1; i >= 0; i--) {

                //makes sure that the bubble exists
                if(bubbles[i].Id == id) {

                    //ticks each bubble
                    bubbles.RemoveAt(i);

                    //stops searching
                    break;
                }
            }
        }

        /// <summary>
        /// The click event
        /// </summary>
        /// <param name="x">The x coord of the click</param>
        /// <param name="y">The y coord of the click</param>
        public void Click(int x, int y) {

            //loops backwards through the bubbles
            for(int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if(bubbles[i] != null)

                    //ticks each bubble
                    bubbles[i].CheckClick(x, y);
        }

        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick() {

            //loops backwards through the bubbles
            for (int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if (bubbles[i] != null)
                
                    //ticks each bubble
                    bubbles[i].Move();                    
        }

        /// <summary>
        /// Draws out the instance of the environment, along with everything in it
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e) {

            //ticks the environment first
            Tick();

            //loops backwards through the bubbles
            for(int i = bubbles.Count - 1; i >= 0; i--)

                //makes sure that the bubble exists
                if(bubbles[i] != null)

                    //draws out the current bubble
                    bubbles[i].Draw(e);
        }
    }
}
