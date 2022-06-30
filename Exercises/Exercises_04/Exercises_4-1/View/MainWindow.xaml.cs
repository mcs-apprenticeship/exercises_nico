using Exercises_4_1.ViewModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void myListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(myListView.SelectedIndex != -1)
            {
                ((MainWindowViewModel)DataContext).CurrentContactId = myListView.SelectedIndex;
            }
        }

        private void Other_Onclick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).CurrentContact.Gender = Gender.x;
        }

        private void Male_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).CurrentContact.Gender = Gender.m;
        }

        private void Female_Onclick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).CurrentContact.Gender = Gender.f;
        }

        private void ReloadListView(object sender, RoutedEventArgs e)
        {
            myListView.ItemsSource = null;
            myListView.ItemsSource = ((MainWindowViewModel)DataContext).Contacts;
        }

        private void AddContact_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).AddContact();
            ReloadListView(sender, e);
        }

        private void RemoveContact_OnClick(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).RemoveContact();
            ReloadListView(sender, e);
        }
    }
}
