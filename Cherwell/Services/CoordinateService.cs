using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Cherwell.Classes;

namespace Cherwell.Services
{
    public class CoordinateService
    {
        public List<Box> Boxes { get; set; }
        public List<Triangle> Triangles { get; set; }
        private static char[] AlphabetNamesByRow = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                                                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
                                                                'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        public CoordinateService()
        {
            Boxes = new List<Box>();
            Triangles = new List<Triangle>();
        }

        public bool GenerateGraph(decimal width, decimal height, decimal sideLength) {
            var result = true;
            int x = 0;
            int y = 0;
            int boxCounter = 0;
            int triangleCounter = 0;

            if ((width / sideLength) % 1 != 0
                ||
                (height / sideLength) % 1 != 0) {
                Console.WriteLine("Given parameters would not generate a symmetrical grid");
                return false;
            }

            while (y < height / sideLength)
            {              
                while (x < width / sideLength) {
                    boxCounter++;
                    triangleCounter++;
                    Box CurrentBox = new Box
                    {
                        BoxName = AlphabetNamesByRow[y] + "Box" + boxCounter,
                        V1 = new Point { X = x, Y = y },
                        V2 = new Point { X = x + 1, Y = y },
                        V3 = new Point { X = x, Y = y + 1 },
                        V4 = new Point { X = x + 1, Y = y + 1 }
                    };
                    Boxes.Add(CurrentBox);

                    Triangles.Add(new Triangle
                    {
                        TriangleName = AlphabetNamesByRow[y] + triangleCounter.ToString(),
                        V1 = CurrentBox.V1,
                        V2 = CurrentBox.V3,
                        V3 = CurrentBox.V4
                    });

                    triangleCounter++;
                    Triangles.Add(new Triangle {
                        TriangleName = AlphabetNamesByRow[y] + triangleCounter.ToString(),
                        V1 = CurrentBox.V1,
                        V2 = CurrentBox.V2,
                        V3 = CurrentBox.V4
                    });
                    x++;
                }
                x = 0;
                boxCounter = 0;
                triangleCounter = 0;
                y++;
            }

            return result;
        }

        public string FindCoordinateTriangle(Point V1, Point V2, Point V3) {                        
            //V1V2V3, 
            var TriangleThatMatchesV1V2V3 = Triangles.SingleOrDefault(t => t.V1.X == V1.X && t.V1.Y == V1.Y
                                                                            &&
                                                                          t.V2.X == V2.X && t.V2.Y == V2.Y
                                                                            &&
                                                                          t.V3.X == V3.X && t.V3.Y == V3.Y);

            if(TriangleThatMatchesV1V2V3 != null) {
                return "The triangle at " + TriangleThatMatchesV1V2V3.TriangleName + " matches the coordinates provided.";
            }

            //V1V3V2,
            var TriangleThatMatchesV1V3V2 = Triangles.SingleOrDefault(t => t.V1.X == V1.X && t.V1.Y == V1.Y
                                                                            &&
                                                                          t.V2.X == V3.X && t.V2.Y == V3.Y
                                                                            &&
                                                                          t.V3.X == V2.X && t.V3.Y == V2.Y);

            if (TriangleThatMatchesV1V3V2 != null) {
                return "The triangle at " + TriangleThatMatchesV1V3V2.TriangleName + " matches the coordinates provided.";
            }

            //V2V1V3,
            var TriangleThatMatchesV2V1V3 = Triangles.SingleOrDefault(t => t.V1.X == V2.X && t.V1.Y == V2.Y
                                                                            &&
                                                                          t.V2.X == V1.X && t.V2.Y == V1.Y
                                                                            &&
                                                                          t.V3.X == V3.X && t.V3.Y == V3.Y);

            if (TriangleThatMatchesV2V1V3 != null) {
                return "The triangle at " + TriangleThatMatchesV2V1V3.TriangleName + " matches the coordinates provided.";
            }

            //V2V3V1,
            var TriangleThatMatchesV2V3V1 = Triangles.SingleOrDefault(t => t.V1.X == V2.X && t.V1.Y == V2.Y
                                                                            &&
                                                                          t.V2.X == V3.X && t.V2.Y == V3.Y
                                                                            &&
                                                                          t.V3.X == V1.X && t.V3.Y == V1.Y);

            if(TriangleThatMatchesV2V3V1 != null) {
                return "The triangle at " + TriangleThatMatchesV2V3V1.TriangleName + " matches the coordinates provided.";
            }

            //V3V1V2, 
            var TriangleThatMatchesV3V1V2 = Triangles.SingleOrDefault(t => t.V1.X == V3.X && t.V1.Y == V3.Y
                                                                            &&
                                                                          t.V2.X == V1.X && t.V2.Y == V1.Y
                                                                            &&
                                                                          t.V3.X == V2.X && t.V3.Y == V2.Y);

            if(TriangleThatMatchesV3V1V2 != null) {
                return "The triangle at " + TriangleThatMatchesV3V1V2.TriangleName + " matches the coordinates provided.";
            }       
            
            //V3V2V1
            var TriangleThatMatchesV3V2V1 = Triangles.SingleOrDefault(t => t.V1.X == V3.X && t.V1.Y == V3.Y
                                                                            &&
                                                                          t.V2.X == V2.X && t.V2.Y == V2.Y
                                                                            &&
                                                                          t.V3.X == V1.X && t.V3.Y == V1.Y);

            if(TriangleThatMatchesV3V2V1 != null) {
                return "The triangle at " + TriangleThatMatchesV3V2V1.TriangleName + " matches the coordinates provided.";
            }

            return "No triangle found with the supplied coordinate set."; ;
        }
    }
}
