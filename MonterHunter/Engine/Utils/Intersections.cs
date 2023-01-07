using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonterHunter.Engine.Utils
{
    public static class Intersections
    {
        public static bool CheckForPointInsedePoly(Line[] edges,Point point )
        {
            if (edges.Length < 3) return false;

            Line infiniteLine = new(point, new(int.MaxValue, point.Y));
            int count = 0;
            for(int index = 0; index < edges.Length; index++)
            {
                if (LineIntersect(edges[index], infiniteLine))
                {
                    count++;
                }
            }
            return count % 2!=0;
        }
        private static bool LineIntersect(Line firstLine, Line secondLine)
        {
            //or = short for orientation.
            int or1 = CheckOrientation(firstLine.p1, firstLine.p2, secondLine.p1);
            int or2 = CheckOrientation(firstLine.p1, firstLine.p2, secondLine.p2);
            int or3 = CheckOrientation(secondLine.p1, secondLine.p2, firstLine.p1);
            int or4 = CheckOrientation(secondLine.p1, secondLine.p2, firstLine.p2);

            //check for normal intersection
            if (or1 != or2 && or3 != or4) return true;
            //one end of the line is on the other one (if any is true we got a colision)
            bool result = (or1 == 0 && OnLine(firstLine, secondLine.p1))
                       || (or2 == 0 && OnLine(firstLine, secondLine.p2))
                       || (or3 == 0 && OnLine(secondLine, firstLine.p1))
                       || (or4 == 0 && OnLine(secondLine, firstLine.p2));
            return result;
        }
        private static int CheckOrientation(Point point1, Point point2, Point point3)
        {
            //0 colinear
            //1 clockwise
            //2 counter-clockwise
            int result = (point2.Y - point1.Y) * (point3.X - point2.X) - (point2.X - point1.X) * (point3.Y - point2.Y);
            if (result == 0) return 0;
            return result > 0 ? 1 : 2;
        }
        private static bool OnLine(Line line, Point point)
        {
            return SlopeOfLine(line.p1, point) == SlopeOfLine(point, line.p2);
        }
        private static float SlopeOfLine(Point p1, Point p2)
        {
            return (p2.Y - p1.Y) / (p2.X - p1.X);
        }
    }

    public class Line
    {
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public Point p1, p2;
    }
}


/*
 * l1(p1(x,y),p2(x,y))
 * l2(p1(x,y),p2(x,y)) 
 */