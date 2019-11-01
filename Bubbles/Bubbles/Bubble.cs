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
        Random rnd = new Random();

        /// <summary>
        /// Keeps track of the next id to assign to a bubble
        /// </summary>
        static int nextId = 0;

        /// <summary>
        /// Used to identify the bubble
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// An instance to the environment
        /// </summary>
        Environment environment;

        /// <summary>
        /// The mass (radius is direcly correlated to mass)
        /// </summary>
        int mass;

        /// <summary>
        /// The accelaration
        /// </summary>
        Vector2D accelaration;

        /// <summary>
        /// The velocity
        /// </summary>
        Vector2D velocity;

        /// <summary>
        /// The position (center of the bubble)
        /// </summary>
        Vector2D position;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor for a bubble
        /// </summary>
        /// <param name="_mass">The mass of the bubble</param>
        /// <param name="_position">The position of the bubble</param>
        /// <param name="parent">An instance to the environment</param>
        public Bubble(int _mass, Vector2D _position, Environment parent)
        {

            environment = parent;
            mass = _mass;
            position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

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
        public Bubble(int _mass, Vector2D _position, Vector2D _force, Environment parent)
        {
            environment = parent;
            mass = _mass;
            position = _position;

            //populates the vector
            velocity = new Vector2D(0, 0);

            ApplyForce(_force);

            //assgns the next id
            Id = nextId++;
        }


        /// <summary>
        /// The tick sequence
        /// </summary>
        public void Tick()
        {
            Move();
        }

        /// <summary>
        /// Moves the bubble by its velocity
        /// </summary>
        void Move()
        {
            position.Add(velocity);
        }

        /// <summary>
        /// Applies a force to the bubble using newtonian physics
        /// </summary>
        /// <param name="_force">The force to apply</param>
        public void ApplyForce(Vector2D _force)
        {
            //calculates the accelaration of the bubble
            accelaration = Vector2D.DivideByNumber(_force, mass);

            //calculates the velocity of the bubble
            velocity.Add(accelaration);


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
        public void Click()
        {
            Explode();
        }

        /// <summary>
        /// Makes the bubble explode into smaller bubbles
        /// </summary>
        public void Explode()
        {

            //sets up the maginituded of the force to apply to the new bubbles
            float radius = rnd.Next(100, 150);

            //sets up how many bubbles to make in the explosion
            //float newBubbleCount = rnd.Next(3, 7);
            float newBubbleCount = 2;


            //gets a random x value for the force between negative and positive of the radius
            float xForce = radius * ((float)rnd.NextDouble() * 2 - 1); ;

            //calculates the y value for the force
            float yForce = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(xForce, 2));


            //adds a new bubbles with a starting force
            environment.AddBubble(new Bubble(mass / 2, position, new Vector2D(xForce, yForce), environment));

            //calculates a 50% to flip the y value
            yForce = -yForce;
            xForce = -xForce;

            //adds a new bubbles with a starting force
            environment.AddBubble(new Bubble(mass / 2, position, new Vector2D(xForce, yForce), environment));

            ////loops through and makes the correct amount of bubbles
            //for (int i = 0; i < newBubbleCount; i++)
            //{

            //    //gets a random x value for the force between negative and positive of the radius
            //    float xForce = radius * ((float)rnd.NextDouble() * 2 - 1); ;

            //    //calculates the y value for the force
            //    float yForce = (float)Math.Sqrt(Math.Pow(radius, 2) - Math.Pow(xForce, 2));

            //    //calculates a 50% to flip the y value
            //    if (rnd.Next(0, 2) == 0)
            //        yForce = -yForce;

            //    //adds a new bubbles with a starting force
            //    environment.AddBubble(new Bubble(mass / 2, position, new Vector2D(xForce, yForce), environment));

            //}

            //tells the environment to remove itself after the explosion
            environment.RemoveBubble(Id);
        }

        /// <summary>
        /// Draws the bubble
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {

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
