﻿#pragma checksum "C:\Users\mails\Documents\GitHub\Gravitas\WindowsApp2\Views\Splash.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B123AB2AD73D253375C3402594971B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsApp2.Views
{
    partial class Splash : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.RingStoryboard = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Media.Animation.DoubleAnimationUsingKeyFrames element2 = (global::Windows.UI.Xaml.Media.Animation.DoubleAnimationUsingKeyFrames)(target);
                    #line 16 "..\..\..\Views\Splash.xaml"
                    ((global::Windows.UI.Xaml.Media.Animation.DoubleAnimationUsingKeyFrames)element2).Completed += this.DoubleAnimationUsingKeyFrames_Completed;
                    #line default
                }
                break;
            case 3:
                {
                    this.MyCanvas = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            case 4:
                {
                    this.MyImage = (global::Windows.UI.Xaml.Controls.Viewbox)(target);
                }
                break;
            case 5:
                {
                    this.MyRingSlice = (global::Template10.Controls.RingSegment)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

