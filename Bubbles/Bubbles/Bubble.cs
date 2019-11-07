using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bubbles
{
    class Bubble
    {
        #region Variables
        /// <summary>
        /// A variable used to generate random numbers
        /// </summary>
        static Random rnd = new Random();

        /// <summary>
        /// Keeps track of the next id to assign to a bubble
        /// </summary>
        public static int nextId;

        /// <summary>
        /// An reference to the environment
        /// </summary>
        Environment environment;

        /// <summary>
        /// The mass (radius is direcly correlated to mass)
        /// </summary>
        int mass;

        /// <summary>
        /// The velocity
        /// </summary>
        Vector2D velocity;

        /// <summary>
        /// The position (center of the bubble)
        /// </summary>
        Vector2D position;
        #endregion

        #region Properties
        /// <summary>
        /// Used to identify the bubble
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Stores if the bubble can move
        /// </summary>
        public bool Static { get; set; }

        /// <summary>
        /// Stores if the bubble will attract other bubbles
        /// </summary>
        public bool ZeroMass { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Constructor for a bubble
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="parent">An instance to the environment</param>
        /// <param name="_static">If the bubble can move</param>
        /// <param name="_zeroMass">If the bubble will have a gravitational force</param>
        public Bubble(int _mass, Vector2D _position, Environment parent, bool _static, bool _zeroMass)
        {

            environment = parent;
            mass = _mass;
            position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

            Static = _static;

            ZeroMass = _zeroMass;

            //assgns the next id
            Id = nextId++;
        }

        /// <summary>
        /// Constructor for creating a bubble with an inital force
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="_force">The starting force</param>
        /// <param name="parent">An instance to the environment</param>
        /// <param name="_static">If the bubble can move</param>
        /// <param name="_zeroMass">If the bubble will have a gravitational force</param>
        public Bubble(int _mass, Vector2D _position, Vector2D _force, Environment parent, bool _static, bool _zeroMass)
        {
            environment = parent;
            mass = _mass;
            position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

            Static = _static;

            ZeroMass = _zeroMass;

            ApplyForce(_force);

            //assgns the next id
            Id = nextId++;
        }

        /// <summary>
        /// Moves the bubble by its velocity
        /// </summary>
        public void Move()
        {
            position = Vector2D.Add(position, velocity);
        }

        /// <summary>
        /// Applies a force to the bubble using newtonian physics
        /// </summary>
        /// <param name="_force">The force to apply</param>
        void ApplyForce(Vector2D _force)
        {
            //calculates the accelaration of the bubble
            Vector2D accelaration = Vector2D.DivideByNumber(_force, mass);

            //calculates the velocity of the bubble
            velocity = Vector2D.Add(velocity, accelaration);
        }

        /// <summary>
        /// Checks to see if the bubble was clicked
        /// </summary>
        /// <param name="x">The x coordinate of the click</param>
        /// <param name="y">The y coordinate of the click</param>
        public void CheckClick(int x, int y)
        {

            //gets the x distance between the two points
            float xDist = position.x - x;

            //gets the y distance between the two points
            float yDist = position.y - y;

            //calculates the hypotenuse using pythagoras
            float dist = (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));

            //checks to see if the distance found is smaller than the radius
            if (dist < mass)
                Click();
        }

        /// <summary>
        /// What happens when the bubble is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Click()
        {
            Explode();
        }

        /// <summary>
        /// Makes the bubble explode into smaller bubbles
        /// </summary>
        void Explode()
        {

            //sets up how many bubbles to make in the explosion
            int newBubbleCount = rnd.Next(10, 15);

            //sets up the size of the new bubbles
            int newMass = mass / newBubbleCount;

            //works out the angle to put the bubbles in at
            float angle = ((float)Math.PI * 2) / newBubbleCount;



            //loops through and makes the correct amount of bubbles
            for (int i = 0; i < newBubbleCount; i++)
            {

                //Vector2D currentForce = Vector2D.CreateVector(10, angle * i);
                //environment.AddBubble(new Bubble(newMass, position, currentForce, environment));


                int forceMagnitude = rnd.Next(10, 30);
                environment.AddBubble(new Bubble(newMass, position, Vector2D.CreateVector(forceMagnitude), environment, false, false)); ;
            }


            //tells the environment to remove this bubble instance after the explosion
            environment.RemoveBubble(Id);
        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {

            //draws the bubble with a default color, position and radius
            e.Graphics.DrawEllipse(
                Pens.Blue,
                position.x - mass,
                position.y - mass,
                mass * 2,
                mass * 2);

            //draws out the id of the bubble
            e.Graphics.DrawString(Id.ToString(),
                SystemFonts.DefaultFont,
                Brushes.Blue,
                position.x,
                position.y);

        }
        #endregion
    }
}
