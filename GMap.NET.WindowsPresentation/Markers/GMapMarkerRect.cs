﻿using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace System.Windows.Controls
{
   public class GMapMarkerRect : GMapMarker
   {
      Rectangle el = new Rectangle();

      public GMapMarkerRect(GMap Map)
      {
         this.Map = Map;

         el.Width = 30;
         el.Height = 30;
         el.Stroke = Brushes.Blue;
         el.Fill = Brushes.Yellow;
         el.StrokeThickness = 2;
         el.MouseEnter += new MouseEventHandler(el_MouseEnter);
         el.MouseLeave += new MouseEventHandler(el_MouseLeave);
         el.MouseUp += new MouseButtonEventHandler(el_MouseUp);

         TextBlock.Foreground = Brushes.Blue;
      }

      void el_MouseUp(object sender, MouseButtonEventArgs e)
      {
         if(e.ChangedButton == MouseButton.Middle)
         {
            el.Width = 30;
            el.Height = 30;

            base.UpdateLocalPosition(Map);
         }
      }

      void el_MouseLeave(object sender, MouseEventArgs e)
      {
         Shape.Stroke = Brushes.Blue;
         Shape.Fill = Brushes.Yellow;
      }

      void el_MouseEnter(object sender, MouseEventArgs e)
      {
         Shape.Fill = Brushes.Yellow; 
         Shape.Stroke = Brushes.Black;
      }

      public override Shape Shape
      {
         get
         {
            return el;
         }
      }

      public override void SetShapeCenter()
      {
         Objects[Shape] = new Point(-Shape.ActualWidth/2, -Shape.ActualHeight/2);
         Objects[TextBlock] = new Point(-TextBlock.ActualWidth/2, -TextBlock.ActualHeight/2);
      }
   }
}