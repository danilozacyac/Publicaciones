using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Publicaciones.Ayudas;
using Publicaciones.Dao;
using Publicaciones.Mantenimiento;
using Publicaciones.Singletons;

namespace Publicaciones
{
    /// <summary>
    /// Lógica de interacción para PorObra.xaml
    /// </summary>
    public partial class PorObra : UserControl
    {
        public Obras ObraSeleccionada;

        public PorObra()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GObras.DataContext = ObrasSingleton.Obras;
        }

        private void GObras_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if(GObras.SelectedItem != null)
            ObraSeleccionada = GObras.SelectedItem as Obras;
            //if(
            //ObraSeleccionada = (from n in ObrasSingleton.Obras
            //                    where n == (GObras.SelectedItem as Obras)
            //                    select n).ToList()[0];
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            GObras.DataContext = (from n in ObrasSingleton.Obras
                                  where n.TituloStr.ToUpper().Contains(tempString)  || n.Sintesis.ToUpper().Contains(tempString)
                                  select n).ToList();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
                GObras.DataContext = ObrasSingleton.Obras;
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorObras color = new ColorObras();
            color.ShowDialog();
        }

        private void GObras_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RelacionObraAutor rel = new RelacionObraAutor(ObraSeleccionada);
            rel.ShowDialog();
        }
    }
}