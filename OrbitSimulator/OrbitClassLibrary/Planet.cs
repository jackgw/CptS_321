// <copyright file="Planet.cs" company="PlaceholderCompany">
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
    /// Planet class containing a set of coordinates
    /// </summary>
    public class Planet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Planet"/> class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Planet(int x, int y)
        {
            this.Coordinates = new Point(x, y);
        }

        /// <summary>
        /// Gets or sets coordinates of the Planet
        /// </summary>
        public Point Coordinates { get; set; }
    }
}
