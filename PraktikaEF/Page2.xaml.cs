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

namespace PraktikaEF
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private BookStoreEntities context = new BookStoreEntities();
        public Page2()
        {
            InitializeComponent();
            BooksDataGrid.ItemsSource = context.Books.ToList();
            ComboBox.ItemsSource = context.Books.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            BooksDataGrid.ItemsSource = context.Books.ToList().Where(item => item.Author.Contains(Search_window.Text));
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            BooksDataGrid.ItemsSource = context.Books.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedItem != null)
            {
                var selected = ComboBox.SelectedItem as Books;
                BooksDataGrid.ItemsSource = context.Books.ToList().Where(item => item.Author == selected.Author);
            }
        }
    }
}
