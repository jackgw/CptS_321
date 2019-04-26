// <copyright file="GravityWell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class representing a gravity well with a set of coordinates and an influence radius
    /// </summary>
    public class GravityWell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GravityWell"/> class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="radius">Influence Radius</param>
        public GravityWell(int x, int y, int radius)
        {
            this.Coordinates = new Point(x, y);
            this.InfluenceRadius = radius;
        }

        /// <summary>
        /// Gets or sets coordinates of the Gravity Well
        /// </summary>
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or sets the radius of influence
        /// </summary>
        public int InfluenceRadius { get; set; }
    }
}
