using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WordConnectionsViewer.GraphClasses.EdgeClases
{
    public class EdgesStyle
    {
        Color color_1;
        Color color_2;
        Color color_3;
        Color color_4;
        public EdgesStyle(Color[] colors)
        {
            SetColorByWeight(colors[0],colors[1],colors[2],colors[3]);
        }
        public Color GetColorByWeight(int weight)
        {
            if (weight < 0)
            {
                try
                {
                    switch (weight)
                    {
                        case 1: return color_1; 
                        case 2: return color_2; 
                        case 3: return color_3; 
                        case 4: return color_4; 
                    }
                }
                catch { }
            }
            return Color.Transparent;
        }
        public Pen GetPenByWeight(int weight)
        {
            if (weight > 0)
            {
                try
                {
                    switch (weight)
                    {
                        case 1: return new Pen(color_1,weight*3); 
                        case 2: return new Pen(color_2,weight * 3); 
                        case 3: return new Pen(color_3,weight * 3); 
                        case 4: return new Pen(color_4,weight * 3); 
                    }
                }
                catch { }
            }
            return new Pen(Color.Transparent,0);
        }

        public void SetColorByWeight(Color Color_1, Color Color_2, Color Color_3, Color Color_4)
        {
            color_1 = Color_1;
            color_2 = Color_2;
            color_3 = Color_3;
            color_4 = Color_4;
        }
        public Color[] GetAllColors()
        {
            return new Color[]{ color_1,color_2,color_3,color_4 };
        }
    }
}
