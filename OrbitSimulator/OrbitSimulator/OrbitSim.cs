// <copyright file="OrbitSim.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NUnit.Framework;

    /// <summary>
    /// Orbit Simulator Form Program
    /// </summary>
    public partial class OrbitSim : Form
    {
        private List<GravityWell> gravityWells = new List<GravityWell>();
        private List<Planet> planets = new List<Planet>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrbitSim"/> class.
        /// </summary>
        public OrbitSim()
        {
            this.InitializeComponent();
            this.tickTimer.Enabled = true;
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Test function testing the rotation capability of the class
        /// </summary>
        [Test]
        public void RotateTest()
        {
            Point center = new Point(0, 0);
            Point outer = new Point(100, 100);
            Point rotated;

            rotated = this.RotateCoordinates(center, outer, 90);    // rotate by 90 degrees
            Assert.AreEqual(rotated.X, -100);
            Assert.AreEqual(rotated.Y, 100);

            center = new Point(50, 50);
            outer = new Point(60, 50);
            rotated = this.RotateCoordinates(center, outer, 180);    // rotate by 180 degrees
            Assert.AreEqual(rotated.X, 40);
            Assert.AreEqual(rotated.Y, 50);

            center = new Point(50, 50);
            outer = new Point(40, 40);
            rotated = this.RotateCoordinates(center, outer, 45);    // rotate by 45 degrees
            Assert.AreEqual(rotated.X, 50);
            Assert.AreEqual(rotated.Y, 36);
        }

        /// <summary>
        /// Test function testing the Infuence-checking capability of the class
        /// </summary>
        [Test]
        public void InfluenceTest()
        {
            GravityWell well = new GravityWell(50, 50, 20);
            Planet planet = new Planet(50, 50);

            Assert.IsTrue(this.IsUnderInfluence(planet, well));

            planet = new Planet(50, 60);
            Assert.IsTrue(this.IsUnderInfluence(planet, well));

            planet = new Planet(50, 70);
            Assert.IsTrue(this.IsUnderInfluence(planet, well));

            planet = new Planet(50, 80);
            Assert.IsTrue(!this.IsUnderInfluence(planet, well));
        }

        /// <summary>
        /// Timer tick event. Invalidates the picturebox for repainting
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event argument</param>
        private void tickTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }

        /// <summary>
        /// Picture box click event, creating a new planet or gravity well.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event argument</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs click = (MouseEventArgs)e;
            if (this.radioButton1.Checked)
            {
                this.planets.Add(new Planet(click.X, click.Y));
            }
            else if (this.radioButton2.Checked)
            {
                this.gravityWells.Add(new GravityWell(click.X, click.Y, Convert.ToInt32(this.numericUpDown1.Value)));
            }
        }

        /// <summary>
        /// Reset button click event. clears all planets and gravity wells
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event argument</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.planets.Clear();
            this.gravityWells.Clear();
        }

        /// <summary>
        /// Picture box painting object
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event argument</param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (GravityWell well in this.gravityWells)
            {
                g.FillEllipse(Brushes.Gray, new RectangleF(well.Coordinates.X - well.InfluenceRadius, well.Coordinates.Y - well.InfluenceRadius, well.InfluenceRadius * 2, well.InfluenceRadius * 2));
                g.FillEllipse(Brushes.Black, new RectangleF(well.Coordinates.X - 5, well.Coordinates.Y - 5, 10, 10));
            }

            foreach (Planet planet in this.planets)
            {
                g.FillEllipse(Brushes.Blue, new RectangleF(planet.Coordinates.X - 5, planet.Coordinates.Y - 5, 10, 10));

                /* Check whether planet is within the influence radius of a gravity well */
                foreach (GravityWell well in this.gravityWells)
                {
                    if (this.IsUnderInfluence(planet, well))
                    {
                        planet.Coordinates = this.RotateCoordinates(well.Coordinates, planet.Coordinates, 5);
                    }
                }
            }
        }

        /// <summary>
        /// Rotate coordinates helper function transforming
        /// </summary>
        /// <param name="center">Center Point</param>
        /// <param name="rotating">Point to be rotated</param>
        /// <param name="angleDegrees">Angle in degrees</param>
        /// <returns>The new point containing rotated coordinates</returns>
        private Point RotateCoordinates(Point center, Point rotating, double angleDegrees)
        {
            double radians = angleDegrees * (Math.PI / 180);
            double sin = Math.Sin(radians);
            double cos = Math.Cos(radians);

            rotating.X -= center.X;
            rotating.Y -= center.Y;

            double newX = (rotating.X * cos) - (rotating.Y * sin);
            double newY = (rotating.X * sin) + (rotating.Y * cos);

            rotating.X = Convert.ToInt32(newX + center.X);
            rotating.Y = Convert.ToInt32(newY + center.Y);

            return rotating;
        }

        /// <summary>
        /// Checks whether the given planet is within the circle of influence of the gravity well
        /// </summary>
        /// <param name="planet">Planet to be checked</param>
        /// <param name="well">GravityWell to be checked</param>
        /// <returns>true if the planet is affected, false otherwise</returns>
        private bool IsUnderInfluence(Planet planet, GravityWell well)
        {
            /* get distance betweem the center points of both entities */
            double distance = Math.Sqrt(Math.Pow(planet.Coordinates.X - well.Coordinates.X, 2) + Math.Pow(planet.Coordinates.Y - well.Coordinates.Y, 2));

            /* Check if distance is less than radius of influence */
            if (distance <= well.InfluenceRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
