using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Publicaciones.Dao;
using Publicaciones.Models;
using Publicaciones.Singletons;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using ScjnUtilities;

namespace Publicaciones.Mantenimiento
{
    /// <summary>
    /// Interaction logic for RelacionObraAutor.xaml
    /// </summary>
    public partial class RelacionObraAutor
    {
        private Obras obra;

        public RelacionObraAutor(Obras obra)
        {
            InitializeComponent();
            this.obra = obra;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GAutorObra.DataContext = AutoresSingleton.Autores;// new AutoresModel().GetAutoresForRelation(obra.IdObra);

            foreach (Autores autor in obra.LAutores)
            {
                Autores copyAut = (from n in AutoresSingleton.Autores
                                   where autor.IdAutor == n.IdAutor
                                   select n).ToList()[0];

                copyAut.IdTipoAutor = autor.IdTipoAutor;

                switch (copyAut.IdTipoAutor)
                {
                    case 1:
                        copyAut.IsAutor = true;
                        break;
                    case 2:
                        copyAut.IsCompilador = true;
                        break;
                    case 3:
                        copyAut.IsTraductor = true;
                        break;
                    case 4:
                        copyAut.IsCoordinador = true;
                        break;
                    case 5:
                        copyAut.IsComentarista = true;
                        break;
                    default:
                        break;
                }
            }

            RelacionObraAutor.IdObraSelect = obra.IdObra;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RelacionObraAutor.IdObraSelect = -1;
            List<Autores> lista = (from n in AutoresSingleton.Autores
                                   where n.IsAutor == true || n.IsComentarista == true || n.IsCompilador == true ||
                                         n.IsCoordinador == true || n.IsTraductor == true
                                   select n).ToList();

            foreach (Autores autor in lista)
            {
                autor.IdTipoAutor = 0;
                autor.IsTraductor = false;
                autor.IsCoordinador = false;
                autor.IsCompilador = false;
                autor.IsComentarista = false;
                autor.IsAutor = false;
            }
            obra.LAutores = new AutoresModel().GetAutores(obra.IdObra);
            
        }

        public static int IdObraSelect = -1;
        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
                GAutorObra.DataContext = (from n in AutoresSingleton.Autores
                                          where n.NombreDesc.ToUpper().Contains(StringUtilities.ConvMayEne(tempString))
                                          select n).ToList();
            else
                GAutorObra.DataContext = AutoresSingleton.Autores;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddAutor_Click(object sender, RoutedEventArgs e)
        {
            AddAutor add = new AddAutor();
            add.ShowDialog();
        }
    }
}