using System;
using System.Drawing;

namespace Cherwell.Classes
{
    public class Box
    {
        //Upper Left Coordinate
        public Point V1 { get; set; }

        //Upper Right Coordinate
        public Point V2 { get; set; }

        //Bottom Left Coordinate
        public Point V3 { get; set; }

        //Bottom Right Coordinate
        public Point V4 { get; set; }

        //AB1 - AB6, BB1 - BB6 etc.
        public string BoxName { get; set; }
    }
}
