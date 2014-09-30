using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using Publicaciones.Dao;

namespace Publicaciones.Models
{
    public class OtrosDatosModel
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        readonly string connectionStringComp = ConfigurationManager.ConnectionStrings["Comp"].ConnectionString;

        public ObservableCollection<OtrosDatos> GetTipoAutor()
        {
            ObservableCollection<OtrosDatos> listaAutores = new ObservableCollection<OtrosDatos>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Tipo_Autor ORDER BY Id";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OtrosDatos autor = new OtrosDatos();
                        autor.IdDato = reader["Id"] as Int16? ?? -1;
                        autor.Descripcion = reader["Desc"].ToString();

                        listaAutores.Add(autor);
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

            return listaAutores;
        }


        public ObservableCollection<OtrosDatos> GetTitulos()
        {
            ObservableCollection<OtrosDatos> listaTitulos = new ObservableCollection<OtrosDatos>();

            OleDbConnection oleConne = new OleDbConnection(connectionStringComp);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM CTitulos ORDER BY IdTitulo";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OtrosDatos dato = new OtrosDatos();
                        dato.IdDato = reader["IdTitulo"] as int? ?? -1;
                        dato.Descripcion = reader["DescTitulo"].ToString();
                        dato.Abrev = reader["Abrev"].ToString();

                        listaTitulos.Add(dato);
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

            return listaTitulos;
        }

    }
}
