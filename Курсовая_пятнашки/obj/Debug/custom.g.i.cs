// Updated by XamlIntelliSenseFileGenerator 27.05.2023 19:10:03
#pragma checksum "..\..\custom.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97292EC3EABC76EED6F7D1259A3EDB9FF8045A50CFB4538A7F51E0A5580372A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Курсовая_пятнашки;


namespace Курсовая_пятнашки
{


    /// <summary>
    /// custom
    /// </summary>
    public partial class custom : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 28 "..\..\custom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid brid;

#line default
#line hidden


#line 29 "..\..\custom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nazad;

#line default
#line hidden


#line 39 "..\..\custom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label close;

#line default
#line hidden


#line 40 "..\..\custom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_img;

#line default
#line hidden


#line 41 "..\..\custom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insert;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Курсовая_пятнашки;component/custom.xaml", System.UriKind.Relative);

#line 1 "..\..\custom.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.brid = ((System.Windows.Controls.Grid)(target));
                    return;
                case 2:
                    this.nazad = ((System.Windows.Controls.Label)(target));

#line 29 "..\..\custom.xaml"
                    this.nazad.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.nazad_MouseLeftButtonUp);

#line default
#line hidden
                    return;
                case 3:
                    this.close = ((System.Windows.Controls.Label)(target));

#line 39 "..\..\custom.xaml"
                    this.close.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.close_MouseLeftButtonUp);

#line default
#line hidden
                    return;
                case 4:
                    this.label_img = ((System.Windows.Controls.Label)(target));
                    return;
                case 5:
                    this.insert = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\custom.xaml"
                    this.insert.Click += new System.Windows.RoutedEventHandler(this.dobavlenie);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Label label_img_Copy;
        internal System.Windows.Controls.RadioButton theme1;
        internal System.Windows.Controls.RadioButton theme2;
        internal System.Windows.Controls.RadioButton theme3;
        internal System.Windows.Controls.Label label_3;
        internal System.Windows.Controls.Label label_4;
        internal System.Windows.Controls.Label label_5;
        internal System.Windows.Controls.Button startgame;
    }
}

