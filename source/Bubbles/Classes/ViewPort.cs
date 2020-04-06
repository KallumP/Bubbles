using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubbles {
    class ViewPort {

        public Vector2D Position { get; set; }

        public float Zoom { get; set; }


        public ViewPort() {
            Position = new Vector2D(0f, 0f);
            Zoom = 1f;
        }
    }
}
