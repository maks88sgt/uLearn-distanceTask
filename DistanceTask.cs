using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double distFromPointToA = FindLengthOfVector(ax, ay, x, y); 
            double distFromPointToB = FindLengthOfVector(bx, by, x, y);
            double lengthOfAB = FindLengthOfVector(ax, ay, bx, by);
            if (lengthOfAB == 0)
            {
                return distFromPointToA;
            }
            else if (ScalarMulty(ax, ay, bx, by, x, y) >= 0 && ScalarMulty(bx, by, ax, ay, x, y) >= 0)
            {
                
                return (2 * SquareOfTriangle(ax, ay, bx, by, x, y)) / lengthOfAB;
            }
            else if (ScalarMulty(ax, ay, bx, by, x, y) < 0 || ScalarMulty(bx, by, ax, ay, x, y) < 0)
            {
                return Math.Min(distFromPointToA, distFromPointToB);
            }
            else return 0;
        }
        public static double ScalarMulty(double x0, double y0, double x1, double y1, double x2, double y2)
        {
            return (x1 - x0) * (x2 - x0) + (y1 - y0) * (y2 - y0);
        }
        public static double FindLengthOfVector(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        public static double SquareOfTriangle ( double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double halfOfPerimeter = (FindLengthOfVector(x1, y1, x2, y2) + FindLengthOfVector(x1, y1, x3, y3) + FindLengthOfVector(x3, y3, x2, y2)) / 2;
            return Math.Sqrt(Math.Abs((halfOfPerimeter * (halfOfPerimeter - FindLengthOfVector(x1, y1, x2, y2)) * (halfOfPerimeter - FindLengthOfVector(x1, y1, x3, y3)) * (halfOfPerimeter - FindLengthOfVector(x3, y3, x2, y2)))));
        }
    }
}