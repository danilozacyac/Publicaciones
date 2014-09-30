using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using Publicaciones.Dao;

namespace Publicaciones.Models
{
    public class ObrasModel
    {
        public static int isLoadFinish = 0;
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Obras> GetObras(ObservableCollection<Obras> listadoObras)
        {

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT C.*, T.Desc FROM CatObras C  INNER JOIN Tipo_Publicacion T ON C.TipoPublicacion = T.Id " +
                               " WHERE C.Activo = 1 AND (C.Id Not Between 1 and 3) AND  " +
                               " C.Id <> 425  ORDER BY C.MedioPublicacion,C.TipoPublicacion, C.TituloTxt ";

            //String sqlCadena = "SELECT C.* FROM CatObras C   " +
            //                   " WHERE C.Activo = 1 AND (C.Id Not Between 1 and 3) AND  " +
            //                   " C.Id <> 425  ORDER BY C.MedioPublicacion,C.TipoPublicacion, C.TituloTxt ";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Obras obra = new Obras();
                        obra.IdObra = reader["Id"] as Int16? ?? -1;
                        obra.Orden = reader["Orden"] as int? ?? -1;
                        obra.Titulo = reader["Titulo"].ToString();
                        obra.TituloStr = reader["TituloTxt"].ToString();
                        obra.Sintesis = reader["Sintesis"].ToString();
                        obra.SintesisStr = reader["SintesisTxt"].ToString();
                        obra.NumeroMaterial = reader["NumeroMaterial"].ToString();
                        obra.AnioPublicacion = reader["AnioPublicacion"] as int? ?? -1;
                        obra.Edicion = reader["Edicion"].ToString();
                        obra.Isbn = reader["ISBN"].ToString();
                        obra.Pais = reader["Pais"] as Int16? ?? -1;
                        obra.Idioma = reader["Idioma"] as Int16? ?? -1;
                        obra.Paginas = reader["Paginas"] as Int16? ?? -1;
                        obra.Clasificacion = reader["Clasificacion"].ToString();
                        obra.TipoPublicacion = reader["TipoPublicacion"] as Int16? ?? -1;
                        obra.MedioPublicacion = reader["MedioPublicacion"] as Int16? ?? -1;
                        obra.Materia = reader["Materia"] as int? ?? -1;
                        obra.Descripcion = reader["Descripcion"].ToString();
                        obra.DescripcionStr = reader["DescMay"].ToString();
                        obra.Consec = reader["Consec"] as int? ?? -1;
                        obra.Precio = reader["Precio"].ToString();
                        obra.Imagen = reader["ArchivoImagen"].ToString();
                        obra.ConMay = reader["ConMay"] as int? ?? -1;
                        obra.TipoPublicacionStr = reader["Desc"].ToString();
                        obra.LAutores = new AutoresModel().GetAutores(obra.IdObra);

                        listadoObras.Add(obra);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException sql)
            {
                MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
            }
            finally
            {

                oleConne.Close();
            }

            ObrasModel.isLoadFinish = 1;
            return listadoObras;
        }


        public ObservableCollection<Obras> GetObras(int idAutor)
        {
            ObservableCollection<Obras> listadoObras = new ObservableCollection<Obras>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT C.*, R.IdTipoAutor " +
                               " FROM CatObras C INNER JOIN RelObrasAutores R ON C.Id = R.IdObra " +
                               " WHERE R.IdAutor = @IdAutor AND C.Activo = 1 ORDER BY R.IdTipoAutor";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdAutor", idAutor);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Obras obra = new Obras();
                        obra.IdObra = reader["Id"] as Int16? ?? -1;
                        obra.Orden = reader["Orden"] as int? ?? -1;
                        obra.Titulo = reader["Titulo"].ToString();
                        obra.TituloStr = reader["TituloTxt"].ToString();
                        obra.Sintesis = reader["Sintesis"].ToString();
                        obra.SintesisStr = reader["SintesisTxt"].ToString();
                        obra.NumeroMaterial = reader["NumeroMaterial"].ToString();
                        obra.AnioPublicacion = reader["AnioPublicacion"] as int? ?? -1;
                        obra.Edicion = reader["Edicion"].ToString();
                        obra.Isbn = reader["ISBN"].ToString();
                        obra.Pais = reader["Pais"] as Int16? ?? -1;
                        obra.Idioma = reader["Idioma"] as Int16? ?? -1;
                        obra.Paginas = reader["Paginas"] as Int16? ?? -1;
                        obra.Clasificacion = reader["Clasificacion"].ToString();
                        obra.TipoPublicacion = reader["TipoPublicacion"] as Int16? ?? -1;
                        obra.MedioPublicacion = reader["MedioPublicacion"] as Int16? ?? -1;
                        obra.Materia = reader["Materia"] as int? ?? -1;
                        obra.Descripcion = reader["Descripcion"].ToString();
                        obra.DescripcionStr = reader["DescMay"].ToString();
                        obra.Consec = reader["Consec"] as int? ?? -1;
                        obra.Precio = reader["Precio"].ToString();
                        obra.Imagen = reader["ArchivoImagen"].ToString();
                        obra.ConMay = reader["ConMay"] as int? ?? -1;
                        obra.IdTipoAutor = reader["IdTipoAutor"] as Int16? ?? -1;

                        listadoObras.Add(obra);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException sql)
            {
                MessageBox.Show("Error ({0}) : {1}" + sql.Source + sql.Message, "Error Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, "Error Interno");
            }
            finally
            {

                oleConne.Close();
            }

            return listadoObras;
        }

    }
}
