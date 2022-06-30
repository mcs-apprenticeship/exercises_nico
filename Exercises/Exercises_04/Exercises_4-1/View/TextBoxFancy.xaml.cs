using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercises_4_1.View
{
    /// <summary>
    /// Interaction logic for TextBox.xaml
    /// </summary>
    public partial class TextBoxFancy : UserControl
    {
        public TextBoxFancy()
        {
            InitializeComponent();
        }



        public string TextBoxValue
        {
            get { return (string)GetValue(TextBoxValueProperty); }
            set { SetValue(TextBoxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextBoxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBoxValueProperty =
            DependencyProperty.Register(nameof(TextBoxValue), typeof(string), typeof(TextBoxFancy), new PropertyMetadata(""));



        public string TextBoxUnit
        {
            get { return (string)GetValue(TextBoxUnitProperty); }
            set { SetValue(TextBoxUnitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextBoxUnit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBoxUnitProperty =
            DependencyProperty.Register("TextBoxUnit", typeof(string), typeof(TextBoxFancy), new PropertyMetadata(""));



    }
}
