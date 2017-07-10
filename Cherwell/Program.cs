using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cherwell.Services;
using System.Drawing;

namespace Cherwell
{
    class Program
    {
        static void Main(string[] args)
        {
            CoordinateService coordService = new CoordinateService();
            decimal width = -1;
            decimal height = -1;
            decimal sideLength = -1;
            bool properGraphCoordinatesEntered = false;
            bool requestSpecificTriangle = true;

            while (!properGraphCoordinatesEntered) {
                while (width == -1)
                {
                    Console.WriteLine("Please enter the width of the image:");
                    var widthInput = Console.ReadLine();

                    if (!Decimal.TryParse(widthInput, out width))
                    {
                        Console.WriteLine("Please enter a numeric only value for the width.");
                    }
                }

                while (height == -1)
                {
                    Console.WriteLine("Please enter the height of the image:");
                    var heightInput = Console.ReadLine();

                    if (!Decimal.TryParse(heightInput, out height))
                    {
                        Console.WriteLine("Please enter a numeric only value for the height.");
                    }
                }

                while (sideLength == -1)
                {
                    Console.WriteLine("Please enter the length of each side of each image graph section:");
                    var sideLengthInput = Console.ReadLine();

                    if (!Decimal.TryParse(sideLengthInput, out sideLength))
                    {
                        Console.WriteLine("Please enter a numeric only value for the side length of each graph section.");
                    }
                }

                properGraphCoordinatesEntered = coordService.GenerateGraph(width, height, sideLength);

                if (!properGraphCoordinatesEntered)
                {
                    Console.WriteLine("Invalid parameters entered to generate a graph with graph sections of the same size.  Please input new parameters.");
                }

                foreach (var Triangle in coordService.Triangles) {
                    Console.WriteLine(Triangle.TriangleName + ":");
                    Console.WriteLine("V1: {" + Triangle.V1.X + "," + Triangle.V1.Y + "}");
                    Console.WriteLine("V2: {" + Triangle.V2.X + "," + Triangle.V2.Y + "}");
                    Console.WriteLine("V3: {" + Triangle.V3.X + "," + Triangle.V3.Y + "}");
                    Console.WriteLine(" ");
                }
            }

            while (requestSpecificTriangle) {
                Console.WriteLine("Would you like to find a specific triangle in the graph (Y or N)?  Any other input will exit the application.");
                var requestSpecificTriangleAnswer = Console.ReadLine();

                if (requestSpecificTriangleAnswer.ToUpper() == "Y") {
                    var ProperV1 = false;
                    var ProperV2 = false;
                    var ProperV3 = false;
                    int XCoord;
                    int YCoord;
                    Point V1 = new Point();
                    Point V2 = new Point();
                    Point V3 = new Point();
                    

                    while (!ProperV1)
                    {
                        Console.WriteLine("Input coordinates for V1 as X and Y separated by a space:");
                        var V1Coordinates = Console.ReadLine().Split(' ');

                        if (V1Coordinates.Count() == 2 && Int32.TryParse(V1Coordinates[0], out XCoord) && Int32.TryParse(V1Coordinates[1], out YCoord)) {
                            ProperV1 = true;
                            V1 = new Point { X = XCoord, Y = YCoord };
                        }
                        else
                            Console.WriteLine("Invalid V1 Coordinates, please re-enter.");
                    }

                    while (!ProperV2)
                    {
                        Console.WriteLine("Input coordinates for V2 as X and Y separated by a space:");
                        var V2Coordinates = Console.ReadLine().Split(' ');

                        if (V2Coordinates.Count() == 2 && Int32.TryParse(V2Coordinates[0], out XCoord) && Int32.TryParse(V2Coordinates[1], out YCoord))
                        {
                            ProperV2 = true;
                            V2 = new Point { X = XCoord, Y = YCoord };
                        }
                        else
                            Console.WriteLine("Invalid V2 Coordinates, please re-enter.");
                    }

                    while (!ProperV3)
                    {
                        Console.WriteLine("Input coordinates for V3 as X and Y separated by a space:");
                        var V3Coordinates = Console.ReadLine().Split(' ');

                        if (V3Coordinates.Count() == 2 && Int32.TryParse(V3Coordinates[0], out XCoord) && Int32.TryParse(V3Coordinates[1], out YCoord))
                        {
                            ProperV3 = true;
                            V3 = new Point { X = XCoord, Y = YCoord };
                        }
                        else
                            Console.WriteLine("Invalid V3 Coordinates, please re-enter.");
                    }

                    Console.WriteLine(coordService.FindCoordinateTriangle(V1, V2, V3));
                }
                else {
                    requestSpecificTriangle = false;
                }
            }
        }
    }
}
