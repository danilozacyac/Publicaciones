using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Publicaciones.Dao;
using Publicaciones.Singletons;

namespace Publicaciones.Splash
{
    /// <summary>
    /// Lógica de interacción para SplashWin.xaml
    /// </summary>
    public partial class SplashWin : Window
    {
        public SplashWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
