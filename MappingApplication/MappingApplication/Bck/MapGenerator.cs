using System;
using System.Drawing;

namespace MappingApplication
{
    class MapGenerator
    {
        private double m_mdist;
        public double Distance { get { return m_mdist; } }

        public MapGenerator(double Distance)
        {
            m_mdist = Distance;
        }

        public MPoint GetInitialPoint(PageNode Parent, int NodesPerParent, double angle, double Rad, ref int MyIndex)
        {
            MPoint point1 = new MPoint(0, Rad);
            MyIndex = NodesPerParent * Parent.Index;
            //for (int i = 0; i < MyIndex; i++ )
                point1 = MapMath.TransformPoint(-1 * MyIndex * angle, point1);
            return point1;
        }

        private void SetLayerCoordinates(Layer currentLayer, int NodesPerParent, int TotalNodes, double Distance)
        {
            double d_angle = MapMath.FindDiffAngle(TotalNodes);
            double rad = 0;
            rad = MapMath.FindArcRadius(d_angle, Distance);
            MPoint currentPoint = null;
            PageNode parent = null;
            int i = 0;
            foreach (PageNode pn in currentLayer.Links)
            {
                if (parent != pn.Parent)
                {
                    parent = pn.Parent;
                    currentPoint = GetInitialPoint(parent, NodesPerParent, d_angle, rad, ref i);
                }
                else
                {
                    currentPoint = MapMath.TransformPoint(-1 * d_angle, currentPoint);
                }
                pn.Position = currentPoint;
                pn.Index = i++;
            }
        }

        private void SetCoordinates(Layer RootLayer)
        {
            Layer currentLayer = RootLayer;
            double dist = m_mdist;
            int n_parents = 0;
            int n_total = 0;
            int max = 0;
            SizeF maxsize = new SizeF(0f, 0f);
            while (currentLayer != null)
            {
                if (max == 0)
                    n_total = currentLayer.Size;
                else
                    n_total = max * n_parents;
                MapMath.MINRAD += Math.Sqrt(Math.Pow(maxsize.Width, 2) + Math.Pow(maxsize.Height, 2))/2;
                PageNode currentNode;
                if (n_parents == 0)
                {
                    currentNode = currentLayer.Links[0];
                    currentNode.Position = new MPoint(0.0, 0.0);
                }
                else
                {
                    SetLayerCoordinates(currentLayer, max, n_total, dist);
                }
                n_parents = n_total;
                max = currentLayer.Max;
                maxsize = currentLayer.MaxSize;
                currentLayer = currentLayer.Next;
            }
        }

        public void GenerateMap(Layer RootLayer)
        {
            SetCoordinates(RootLayer);
            MapMath.MINRAD = 0;
        }
    }
}
