// Copyright Eric Chauvin 2024.



// This is licensed under the GNU General
// Public License (GPL).  It is the
// same license that Linux has.
// https://www.gnu.org/licenses/gpl-3.0.html




using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
// using System.Threading;



// namespace


// Rectangle Button.


public class RecBtn
{
private MainData mData;
private int x = 1;
private int y = 1;
private int width = 1;
private int height = 1;
private string label = "";


private RecBtn()
{
}


internal RecBtn( MainData mDataToUse,
                 int useX,
                 int useY,
                 int useWidth,
                 int useHeight,
                 string useLabel )
{
mData = mDataToUse;
x = useX;
y = useY;
width = useWidth;
height = useHeight;
label = useLabel;
}



internal bool isInside( int mouseX, int mouseY )
{
if( mouseX < x )
  return false;

if( mouseX > (x + width) )
  return false;

if( mouseY < y )
  return false;

if( mouseY > (y + height) )
  return false;

return true;
}


internal void draw( Graphics useGraphics )
{
try
{
if( mData.getIsClosing())
  return;

if( useGraphics == null )
  return;

if( width < 10 )
      width = 10;

if( height < 10 )
  height = 10;

SolidBrush blackBrush = new SolidBrush(
                                 Color.Black );

SolidBrush whiteBrush = new SolidBrush(
                                 Color.White );

Pen whitePen = new Pen( Brushes.White );

// Font mainFont = new Font(
//                   FontFamily.GenericSansSerif,
//                   36.0F,
//                   FontStyle.Regular, // Bold
//                   GraphicsUnit.Pixel );

Font mainFont = new System.Drawing.Font(
              "Consolas", 50.0F,
              System.Drawing.FontStyle.Regular,
              System.Drawing.GraphicsUnit.Pixel,
              ((byte)(0)) );

try
{

whitePen.Width = 1.0F;
whitePen.LineJoin = System.Drawing.Drawing2D.
                                   LineJoin.Bevel;
whitePen.DashStyle = DashStyle.Solid;
                     // DashDot, DashDotDot...

useGraphics.FillRectangle( blackBrush, x, y,
                           width, height );

useGraphics.DrawRectangle( whitePen, x, y,
                           width, height );

// SizeF Sz = DrawGraphics.MeasureString(
//           Rec.Label, MainFont );
// XPos - (int)(Sz.Width / 2)

useGraphics.DrawString( label, mainFont,
                        whiteBrush,
                        x + 5, y + 3 );

}
finally
  {
  whitePen.Dispose();
  blackBrush.Dispose();
  whiteBrush.Dispose();
  mainFont.Dispose();
  }

}
catch( Exception ) // Except )
  {
  throw new Exception(
           "Exception in GuiMain.Draw()." );
           //  + Except.Message
  }
}



/*
  internal void DrawLegends( GeoView View,
                             Graphics UseGraphics,
                             int Height,
                             int Width,
                             bool UseEqualization )
    {
    Pen BlackPen = new Pen( Brushes.Black );
    BlackPen.Width = 1.0F;
    // MainPen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
    // MainPen.DashStyle = DashStyle.Solid; // DashDot, DashDotDot, Custom

    SolidBrush BlackBrush = new SolidBrush( Color.Black );
    SolidBrush YellowBrush = new SolidBrush( Color.Yellow ); // $0000C0FF; RGB or BGR?
    SolidBrush SilverBrush = new SolidBrush( Color.Silver );
    SolidBrush KhakiBrush = new SolidBrush( Color.Khaki );

    Font MainFont = new Font( FontFamily.GenericSansSerif,
                              14.0F,
                              FontStyle.Regular,
                              GraphicsUnit.Pixel );

    Font BoldFont = new Font( FontFamily.GenericSansSerif,
                              14.0F,
                              FontStyle.Bold,
                              GraphicsUnit.Pixel );

    try // finally
    {

    ECTime RightNow = new ECTime();
    RightNow.SetToNow();

    string ShowZone = TimeZoneInfo.Local.DisplayName;
    if( ShowZone.Contains( "Arizona" ))
      ShowZone = " AZ Time";
    else
      ShowZone = "";

    string ShowS = RightNow.ToLocalTimeString() +
                   ShowZone + " on " +
                   RightNow.ToLocalDateStringShort() + " ";

    SizeF Sz = UseGraphics.MeasureString( ShowS, BoldFont );
    int X = (Width >> 1) - (int)(Sz.Width / 2); // Width / 2
    int Y = Height - 21;
    UseGraphics.FillRectangle( YellowBrush, X, Y, Sz.Width + 4, 19 );
    UseGraphics.DrawRectangle( BlackPen, X, Y, Sz.Width + 4, 19 );
    UseGraphics.DrawString( ShowS, BoldFont, BlackBrush, X + 2, Y + 1 );

    int Year = RightNow.GetLocalYear();
    ShowS = " Mineralab " + Year.ToString() + " ";
    Sz = UseGraphics.MeasureString( ShowS, BoldFont );
    X = Width - (int)Sz.Width - 8;
    UseGraphics.FillRectangle( YellowBrush, X, Y, Sz.Width + 4, 19 );
    UseGraphics.DrawRectangle( BlackPen, X, Y, Sz.Width + 4, 19 );
    UseGraphics.DrawString( ShowS, BoldFont, BlackBrush, X + 2, Y + 1 );

    if( UseEqualization )
      ShowS = "Readings Equalized* ";
    else
      ShowS = "Readings Not Equalized* ";

    Y = 2; // Height - 44;
    Sz = UseGraphics.MeasureString( ShowS, BoldFont );
    X = (Width >> 1) - (int)(Sz.Width / 2); //  - 8;
    UseGraphics.FillRectangle( YellowBrush, X, Y, Sz.Width + 7, 19 );
    UseGraphics.DrawRectangle( BlackPen, X, Y, Sz.Width + 7, 19 );
    UseGraphics.DrawString( ShowS, BoldFont, BlackBrush, X + 2, Y + 1 );

    // UseGraphics.DrawString( "Some text.", MainFont, BlackBrush, 10, Y + 30 );

    // SizeF Sz = DrawGraphics.MeasureString( ShowCPM, MainFont );
    // DrawGraphics.DrawString( ShowCPM, MainFont, BlackBrush, XPos - (int)(Sz.Width / 2), YPos - (int)(Sz.Height / 2) );

    Bitmap MapLegendImage = MForm.GetMapLegendImage();
    if( MapLegendImage != null )
      {
      Y = Height - MapLegendImage.Size.Height - 20;
      //                                      X, Y, Width, Height
      UseGraphics.FillRectangle( YellowBrush, 1, Y, 48, 19 );
      UseGraphics.DrawRectangle( BlackPen, 1, Y, 48, 19 );
      UseGraphics.DrawString( "CPM", BoldFont, BlackBrush, 6, Y + 1 );

      UseGraphics.DrawImage( MapLegendImage, 1, Height - MapLegendImage.Size.Height - 1 );
      }
    }
    finally
      {
      BlackPen.Dispose();
      BlackBrush.Dispose();
      YellowBrush.Dispose();
      SilverBrush.Dispose();
      KhakiBrush.Dispose();
      MainFont.Dispose();
      BoldFont.Dispose();
      }
    }
*/


} // Class
