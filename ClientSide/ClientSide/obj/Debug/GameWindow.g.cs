﻿#pragma checksum "..\..\GameWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF64BEF314FBB1E5E8ACBD15E128DD90F5831C3E962FE7C0BC975D09CE7DE64E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClientSide;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClientSide {
    
    
    /// <summary>
    /// GameWindow
    /// </summary>
    public partial class GameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RoomName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label QuestNum;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Question;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ans1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ans2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ans3;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ans4;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Score;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Counter;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Username;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\GameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Exit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientSide;component/gamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 1 "..\..\GameWindow.xaml"
            ((ClientSide.GameWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RoomName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.QuestNum = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Question = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Ans1 = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\GameWindow.xaml"
            this.Ans1.Click += new System.Windows.RoutedEventHandler(this.Ans_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Ans2 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\GameWindow.xaml"
            this.Ans2.Click += new System.Windows.RoutedEventHandler(this.Ans_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Ans3 = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\GameWindow.xaml"
            this.Ans3.Click += new System.Windows.RoutedEventHandler(this.Ans_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Ans4 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\GameWindow.xaml"
            this.Ans4.Click += new System.Windows.RoutedEventHandler(this.Ans_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Score = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.Counter = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Username = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.Exit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\GameWindow.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

