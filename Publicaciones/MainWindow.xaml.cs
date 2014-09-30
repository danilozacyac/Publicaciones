using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Publicaciones.Reportes;
using Publicaciones.Singletons;

namespace Publicaciones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool isAutoresVisible = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CPorObras_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;

            while (!ObrasSingleton.isObrasComplete)
            {
                Thread.Sleep(10);
            }

            isAutoresVisible = false;
            CAutores.Visibility = Visibility.Collapsed;
            CObras.Visibility = Visibility.Visible;

            this.Cursor = Cursors.Arrow;
        }

        private void CPorAutor_Click(object sender, RoutedEventArgs e)
        {
            isAutoresVisible = true;
            CAutores.Visibility = Visibility.Visible;
            CObras.Visibility = Visibility.Collapsed;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GeneraWord word = new GeneraWord();

            if (isAutoresVisible)
                word.AutoresObras(CAutores.AutorSelect, CAutores.ObrasAutor);
            else if(!isAutoresVisible && CObras.ObraSeleccionada != null)
                word.ObrasAutores(CObras.ObraSeleccionada);
        }
    }
}
