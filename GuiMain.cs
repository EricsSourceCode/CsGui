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



public class GuiMain
{
private MainData mData;
private RecBtn democratBtn;
private RecBtn repubBtn;
private RecBtn testBtn;


private GuiMain()
{
}


internal GuiMain( MainData mDataToUse )
{
mData = mDataToUse;
democratBtn = new RecBtn( mData,
                          5, // x
                          7, // y
                          202, // width
                          50, // height
                          "Democrat" );

repubBtn = new RecBtn( mData,
                       215, // x
                       7, // y
                       250, // width
                       50, // height
                       "Republican" );

testBtn = new RecBtn( mData,
                          1000, // x
                          7, // y
                          120, // width
                          50, // height
                          "Test" );

}


internal bool isInsideDemocratBtn(
                      int mouseX, int mouseY )
{
// private RecBtn repubBtn;

return democratBtn.isInside( mouseX, mouseY );
}


internal bool isInsideRepubBtn(
                      int mouseX, int mouseY )
{
return repubBtn.isInside( mouseX, mouseY );
}



internal bool isInsideTestBtn(
                      int mouseX, int mouseY )
{
return testBtn.isInside( mouseX, mouseY );
}



internal void draw( int width,
                    int height,
                    Graphics useGraphics )
{
try
{
// if( !IsEnabled )
//  return;

if( mData.getIsClosing())
  return;

if( useGraphics == null )
  return;

if( width < 10 )
      width = 10;

if( height < 10 )
  height = 10;

useGraphics.Clear( Color.Black );

// Color OceanColor = Color.FromArgb(
//                          0x30, 0x30, 0xFF );

// SolidBrush OceanBrush = new SolidBrush(
         // OceanColor ); // Blue   SteelBlue );


democratBtn.draw( useGraphics );
repubBtn.draw( useGraphics );
testBtn.draw( useGraphics );

}
catch( Exception ) // Except )
  {
  throw new Exception(
           "Exception in GuiMain.Draw()." );
           //  + Except.Message
  }
}



} // Class
