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
using System.Windows.Shapes;
using Publicaciones.Models;
using Publicaciones.Singletons;

namespace Publicaciones.Mantenimiento
{
    /// <summary>
    /// Lógica de interacción para AddAutor.xaml
    /// </summary>
    public partial class AddAutor : Window
    {
        public AddAutor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RCbxTitulo.DataContext = OtrosDatosSingleton.Titulos;
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {

            new AutoresModel().SetNewAutor(TxtNombre.Text, Convert.ToInt16(RCbxTitulo.SelectedValue));
            this.Close();
        }
    }
}
