using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows;
using Publicaciones.Dao;
using ScjnUtilities;

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
                        obra.ForPersonal = this.GetDisponibilidad(obra.IdObra);
                        obra.Notify = true;

                        listadoObras.Add(obra);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
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



        #region Oferta al Personal 

        public bool GetDisponibilidad(int idObra)
        {

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Comp"].ConnectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM AlPersonal WHERE IdObra = @IdObra ";

            bool aDisposicion = false;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdObra", idObra);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        aDisposicion = Convert.ToBoolean(reader["Disponible"]);
                    }
                }
                
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            finally
            {

                oleConne.Close();
            }

            
            return aDisposicion;
        }


        public void WhatToDoDisponible(int idObra, bool aDisposicion)
        {
            int existence = this.GetExistencia(idObra);

            if (existence > 0)
                this.UpdateDisponibilidad(idObra, aDisposicion);
            else
                this.SetNewDisponible(idObra, aDisposicion);

        }

        private int GetExistencia(int idObra)
        {

            OleDbConnection oleConne = new OleDbConnection(ConfigurationManager.ConnectionStrings["Comp"].ConnectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM AlPersonal WHERE IdObra = @IdObra ";

            int cuantos = 0;

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                cmd.Parameters.AddWithValue("@IdObra", idObra);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       cuantos++;
                    }
                }

                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            finally
            {

                oleConne.Close();
            }


            return cuantos;
        }


        private void SetNewDisponible(int idObra, bool aDisposicion)
        {
            OleDbConnection connectionEpsSql = new OleDbConnection(ConfigurationManager.ConnectionStrings["Comp"].ConnectionString);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM AlPersonal WHERE IdObra = 0";

            try
            {
                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connectionEpsSql);

                dataAdapter.Fill(dataSet, "AlPersonal");

                dr = dataSet.Tables["AlPersonal"].NewRow();
                dr["IdObra"] = idObra;
                dr["Disponible"] = (aDisposicion ) ? 1 : 0;

                dataSet.Tables["AlPersonal"].Rows.Add(dr);

                dataAdapter.InsertCommand = connectionEpsSql.CreateCommand();
                dataAdapter.InsertCommand.CommandText = "INSERT INTO AlPersonal(IdObra,Disponible)" +
                                                        " VALUES(@IdObra,@Disponible)";

                dataAdapter.InsertCommand.Parameters.Add("@IdObra", OleDbType.Numeric, 0, "IdObra");
                dataAdapter.InsertCommand.Parameters.Add("@Disponible", OleDbType.Numeric, 0, "Disponible");

                dataAdapter.Update(dataSet, "AlPersonal");

                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            finally
            {
                connectionEpsSql.Close();
            }
        }

        private void UpdateDisponibilidad(int idObra, bool aDisposicion)
        {
            OleDbConnection connectionEpsSql = new OleDbConnection(ConfigurationManager.ConnectionStrings["Comp"].ConnectionString);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();

            DataSet dataSet = new DataSet();
            DataRow dr;

            string sqlCadena = "SELECT * FROM AlPersonal WHERE IdObra = @IdObra";

            try
            {
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connectionEpsSql);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdObra", idObra);
                dataAdapter.Fill(dataSet, "AlPersonal");

                dr = dataSet.Tables["AlPersonal"].Rows[0];
                dr.BeginEdit();
                dr["Disponible"] = (aDisposicion) ? 1 : 0;
                
                dr.EndEdit();

                dataAdapter.UpdateCommand = connectionEpsSql.CreateCommand();
                dataAdapter.UpdateCommand.CommandText = "UPDATE AlPersonal SET Disponible = @Disponible " +
                                                        "WHERE IdObra = @IdObra";

                dataAdapter.UpdateCommand.Parameters.Add("@Disponible", OleDbType.Numeric, 0, "Disponible");
                dataAdapter.UpdateCommand.Parameters.Add("@IdObra", OleDbType.Numeric, 0, "IdObra");

                dataAdapter.Update(dataSet, "AlPersonal");

                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObrasModel", "Publicaciones");
            }
            finally
            {
                connectionEpsSql.Close();
            }
        }

        #endregion
    }
}
