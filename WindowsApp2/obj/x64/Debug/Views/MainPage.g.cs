﻿#pragma checksum "C:\Users\mails\Documents\GitHub\Gravitas\WindowsApp2\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "672F188C22F50E3A8F064709FEE8D258"
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
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
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
                    this.ViewModel = (global::WindowsApp2.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 2:
                {
                    this.AdaptiveVisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3:
                {
                    this.VisualStateNarrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.VisualStateNormal = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.VisualStateWide = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 6:
                {
                    this.pageHeader = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 7:
                {
                    this.asb = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    #line 104 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.asb).TextChanged += this.asb_TextChanged;
                    #line 106 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.asb).QuerySubmitted += this.asb_QuerySubmitted;
                    #line 107 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.asb).SuggestionChosen += this.asb_SuggestionChosen;
                    #line default
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

