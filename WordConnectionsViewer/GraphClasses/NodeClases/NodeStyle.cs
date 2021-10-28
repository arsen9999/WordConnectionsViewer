using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WordConnectionsViewer.GraphClasses.NodeClases
{
    public class NodeStyle
    {
        public SizeF NodeSize;
        Pen pen;//NodeColorAndBorderSize-------
        public float BorderSize;
        Color TextColor;
        Brush brush;//StringColorAndSize-------
        public StringFormat stringParam;
        Font TextFont;
        public int NodeSizeDifference = 10;

        public NodeStyle(Color textColor,Color backColor,Font textFont,float nodeSize,int nodeSizeDifference)
        {
            NodeSize = new SizeF(nodeSize,nodeSize);
            NodeSizeDifference = nodeSizeDifference;
            SetNodeColor(backColor, NodeSize.Width);
            SetStringParams(textColor, textFont.Name, textFont.Size, textFont.Style);
        }
        public Color GetNodeTextColor()
        {
            return pen.Color;
        }
        void SetPen(Color outlineColor, float NodeBorderSize)
        {
            BorderSize = NodeBorderSize;
            pen = new Pen(outlineColor, BorderSize);
        }
        public void SetNodeColor(Color outlineColor, float NodeBorderSize)
        {
            SetPen(outlineColor, NodeBorderSize);
        }
        public void SetPen(Pen new_pen)
        {
            pen = new_pen;
        }
        public Color GetNodeColor()
        {
            return pen.Color;
        }
        public Pen GetPen()
        {
            return pen;
        }
        public Brush GetBrush()
        {
            return brush;
        }
        public float GetNodeBorderSize()
        {
            return BorderSize;
        }

        #region ----String ----
        public void SetStringParams(Color color, string fontName, float fSize, FontStyle fStyle)
        {
            SetTextColor(color);
            SetFont(fontName, fSize, fStyle);
            stringParam = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
        }

        public void SetTextColor(Color color)
        {
            TextColor = color;
            brush = new SolidBrush(color);
        }
        public Color GetTextColor()
        {
            return TextColor;
        }
        public void SetFont(string fontName, float fSize, FontStyle style)
        {
            TextFont = new Font(new FontFamily(fontName), fSize, style);
        }
        public void SetFont(Font font)
        {
            TextFont = font;
        }
        public Font GetFont()
        {
            return TextFont;
        }
        #endregion
    }
}
