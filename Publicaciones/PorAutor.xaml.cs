using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Publicaciones.Ayudas;
using Publicaciones.Dao;
using Publicaciones.Models;
using Publicaciones.Singletons;
using ScjnUtilities;

namespace Publicaciones
{
    /// <summary>
    /// Lógica de interacción para PorAutor.xaml
    /// </summary>
    public partial class PorAutor : UserControl
    {
        public Autores AutorSelect;
        public ObservableCollection<Obras> ObrasAutor;
        
        public PorAutor()
        {
            InitializeComponent();
        }

        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LstAutores.DataContext = AutoresSingleton.Autores;
        }

        private void LstAutores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AutorSelect = LstAutores.SelectedItem as Autores;
                ObrasAutor = new ObrasModel().GetObras(AutorSelect.IdAutor);
                GObrasAutor.DataContext = ObrasAutor;
            }
            catch (NullReferenceException) { }
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
                LstAutores.DataContext = (from n in AutoresSingleton.Autores
                                          where n.NombreDesc.ToUpper().Contains(StringUtilities.ConvMayEne(tempString))
                                          select n).ToList();
            else
                LstAutores.DataContext = AutoresSingleton.Autores;
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ColorAutor color = new ColorAutor();
            color.ShowDialog();
        }
    }
}
