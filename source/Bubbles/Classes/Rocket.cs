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


        Environment e;

        #endregion

        #region Properties

        public Vector2D position { get; set; }

        public int mass { get; set; }

        /// <summary>
        /// The bubble that this rocket is snapped to
        /// </summary>
        public Bubble snappedTo { get; set; }

        #endregion

        public Rocket(int _mass, Environment parent)
        {
            mass = _mass;

            e = parent;

            position = new Vector2D();
        }

        public void Tick()
        {
            
        }

        public void Draw(PaintEventArgs e, Size windowSize)
        {

            e.Graphics.FillRectangle(Brushes.Green, position.x, position.y, 5, 5);

        }

        public void UpdatePos(int x, int y)
        {
            position.x = x;
            position.y = y;
        }

        public void Snap(Bubble b, int x, int y)
        {
            snappedTo = b;



            position.x = b.mass * (float)Math.Sin(2 * Math.PI - (3 * Math.PI / 2 + Vector2D.Angle(b.position, new Vector2D(x, y)))) + b.position.x;
            position.y = b.mass * (float)Math.Cos(2 * Math.PI - (3 * Math.PI / 2 + Vector2D.Angle(b.position, new Vector2D(x, y)))) + b.position.y;

        }

        public void UnSnap()
        {
            snappedTo = null;

        }

        public void TakeOff()
        {
            UnSnap();
        }
   
        public void ApplyForce(Vector2D force)
        {

        }

        public void UpdatePosition()
        {

        }
    }
}
