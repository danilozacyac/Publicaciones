using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using Publicaciones.Dao;
using Publicaciones.Singletons;
using ScjnUtilities;

namespace Publicaciones.Models
{
    public class AutoresModel
    {

        readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        readonly string connectionStringComp = ConfigurationManager.ConnectionStrings["Comp"].ConnectionString;


        public ObservableCollection<Autores> GetAutores(ObservableCollection<Autores> listaAutores)
        {

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT * FROM Autores ORDER BY DescMay";

            try
            {
                oleConne.Open();

                cmd = new OleDbCommand(sqlCadena, oleConne);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Autores autor = new Autores();
                        autor.IdAutor = Convert.ToInt32(reader["Id"]);// as int? ?? -1;
                        autor.Nombre = reader["Desc"].ToString();
                        autor.NombreDesc = reader["DescMay"].ToString();

                        listaAutores.Add(autor);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {

                oleConne.Close();
            }

            return listaAutores;
        }

        
        public ObservableCollection<Autores> GetAutores(int idObra)
        {
            ObservableCollection<Autores> listaAutores = new ObservableCollection<Autores>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT A.*,R.IdTipoAutor FROM Autores A INNER JOIN RelObrasAutores  R ON A.Id = R.IdAutor " + 
                               " WHERE R.IdObra = @IdObra ORDER BY R.IdTipoAutor,A.DescMay";

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
                        Autores autor = new Autores();
                        autor.IdAutor = Convert.ToInt32(reader["Id"]);// as int? ?? -1;
                        autor.Nombre = reader["Desc"].ToString();
                        autor.NombreDesc = reader["DescMay"].ToString();
                        autor.IdTipoAutor = reader["IdTipoAutor"] as Int16? ?? -1;

                        switch (autor.IdTipoAutor)
                        {
                            case 1: autor.IsAutor = true;
                                break;
                            case 2: autor.IsCompilador = true;
                                break;
                            case 3: autor.IsTraductor = true;
                                break;
                            case 4: autor.IsCoordinador = true;
                                break;
                            case 5: autor.IsComentarista = true;
                                break;
                            default:
                                break;
                        }


                        listaAutores.Add(autor);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {

                oleConne.Close();
            }

            return listaAutores;
        }


        public ObservableCollection<Autores> GetAutoresForRelation(int idObra)
        {
            ObservableCollection<Autores> listaAutores = new ObservableCollection<Autores>();

            OleDbConnection oleConne = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            String sqlCadena = "SELECT A.*,R.IdTipoAutor FROM Autores A LEFT JOIN RelObrasAutores  R ON A.Id = R.IdAutor " +
                               "  ORDER BY R.IdTipoAutor,A.DescMay";

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
                        Autores autor = new Autores();
                        autor.IdAutor = Convert.ToInt32(reader["Id"]);// as int? ?? -1;
                        autor.Nombre = reader["Desc"].ToString();
                        autor.NombreDesc = reader["DescMay"].ToString();
                        autor.IdTipoAutor = reader["IdTipoAutor"] as Int16? ?? -1;

                        


                        listaAutores.Add(autor);
                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {

                oleConne.Close();
            }

            return listaAutores;
        }


        public void SetNewRelation(Autores autor, int idObra)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            string sSql;
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            try
            {
                string sqlCadena = "SELECT * FROM RelObrasAutores WHERE IdAutor = " + autor.IdAutor + " AND IdObra = " + idObra;

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "RelObrasAutores");

                dr = dataSet.Tables["RelObrasAutores"].NewRow();
                dr["Id"] = this.GetNextIdForUse("RelObrasAutores", "Id");
                dr["IdObra"] = idObra;
                dr["IdAutor"] = autor.IdAutor;

                if (autor.IsAutor == true)
                    dr["IdTipoAutor"] = 1;
                if (autor.IsCompilador == true)
                    dr["IdTipoAutor"] = 2;
                if (autor.IsTraductor == true)
                    dr["IdTipoAutor"] = 3;
                if (autor.IsCoordinador == true)
                    dr["IdTipoAutor"] = 4;
                if (autor.IsComentarista == true)
                    dr["IdTipoAutor"] = 5;


                dataSet.Tables["RelObrasAutores"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                sSql = "INSERT INTO RelObrasAutores (Id,IdObra,IdAutor,IdTipoAutor) VALUES (@Id,@IdObra,@IdAutor,@IdTipoAutor)";

                dataAdapter.InsertCommand.CommandText = sSql;
                dataAdapter.InsertCommand.Parameters.Add("@Id", OleDbType.Numeric, 0, "Id");
                dataAdapter.InsertCommand.Parameters.Add("@IdObra", OleDbType.Numeric, 0, "IdObra");
                dataAdapter.InsertCommand.Parameters.Add("@IdAutor", OleDbType.Numeric, 0, "IdAutor");
                dataAdapter.InsertCommand.Parameters.Add("@IdTipoAutor", OleDbType.Numeric, 0, "IdTipoAutor");

                dataAdapter.Update(dataSet, "RelObrasAutores");
                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {
                connection.Close();
            }

            
        }

        public void DeleteRelacion(Autores autor, int idObra)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd;

            cmd = connection.CreateCommand();
            cmd.Connection = connection;

            try
            {
                connection.Open();

                cmd.CommandText = "DELETE FROM RelObrasAutores WHERE idObra = " + idObra + " AND idAutor = " + autor.IdAutor;
                cmd.ExecuteNonQuery();
                
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        public void SetNewAutor(string nombreAutor,int idTitulo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            string sSql;
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            Autores autor = new Autores();
            autor.IdAutor = this.GetNextIdForUse("Autores", "Id");
            autor.Nombre = nombreAutor;
            autor.NombreDesc = StringUtilities.ConvMayEne(nombreAutor.ToUpper());
            autor.IdTitulo = idTitulo;


            try
            {
                string sqlCadena = "SELECT * FROM Autores WHERE Id = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "Autores");

                dr = dataSet.Tables["Autores"].NewRow();
                dr["Id"] = autor.IdAutor;
                dr["Desc"] = autor.Nombre;
                dr["DescMay"] = autor.NombreDesc;

                dataSet.Tables["Autores"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                sSql = "INSERT INTO Autores(Id,[Desc],DescMay) VALUES(@Id,@Desc,@DescMay)";

                dataAdapter.InsertCommand.CommandText = sSql;
                dataAdapter.InsertCommand.Parameters.Add("@Id", OleDbType.Numeric, 0, "Id");
                dataAdapter.InsertCommand.Parameters.Add("@Desc", OleDbType.VarChar, 0, "Desc");
                dataAdapter.InsertCommand.Parameters.Add("@DescMay", OleDbType.VarChar, 0, "DescMay");

                dataAdapter.Update(dataSet, "Autores");
                dataSet.Dispose();
                dataAdapter.Dispose();

                this.SetNewAutorTitulo(autor.IdAutor, autor.IdTitulo);

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {
                connection.Close();
            }

            AutoresSingleton.Autores.Add(autor);
        }

        public void SetNewAutorTitulo(int idAutor, int idTitulo)
        {
            OleDbConnection connection = new OleDbConnection(connectionStringComp);

            string sSql;
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

           
            try
            {
                string sqlCadena = "SELECT * FROM RTituAutor WHERE Id = 0";

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand(sqlCadena, connection);

                dataAdapter.Fill(dataSet, "RTituAutor");

                dr = dataSet.Tables["RTituAutor"].NewRow();
                dr["IdAutor"] = idAutor;
                dr["IdTitulo"] = idTitulo;

                dataSet.Tables["RTituAutor"].Rows.Add(dr);

                dataAdapter.InsertCommand = connection.CreateCommand();

                sSql = "INSERT INTO RTituAutor(IdAutor,IdTitulo) VALUES(@IdAutor,@IdTitulo)";

                dataAdapter.InsertCommand.CommandText = sSql;
                dataAdapter.InsertCommand.Parameters.Add("@IdAutor", OleDbType.Numeric, 0, "IdAutor");
                dataAdapter.InsertCommand.Parameters.Add("@IdTitulo", OleDbType.Numeric, 0, "IdTitulo");

                dataAdapter.Update(dataSet, "RTituAutor");
                dataSet.Dispose();
                dataAdapter.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {
                connection.Close();
            }

        }

        private int GetNextIdForUse(string nombreTabla,string nombreCampo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd;
            OleDbDataReader reader = null;

            int idSignatario = 0;

            try
            {
                connection.Open();

                string sqlCadena = "SELECT MAX("+ nombreCampo + ") + 1 AS Id FROM " +  nombreTabla;

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    idSignatario = reader[nombreCampo] as int? ?? -1;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutoresModel", "Publicaciones");
            }
            finally
            {
                reader.Close();
                connection.Close();
            }

            return idSignatario;
        }

    }
}
