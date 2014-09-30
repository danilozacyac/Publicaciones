using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Interop.Word;
using Publicaciones.Dao;
using Publicaciones.Singletons;

namespace Publicaciones.Reportes
{
    public class GeneraWord
    {

        readonly string filepath = Path.GetTempFileName() + ".docx";

        int fila = 1;

        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";


        public void AutoresObras(Autores autor,ObservableCollection<Obras> obras)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
           

            
            try
            {

                oPara1.Range.Text = autor.Nombre;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 14;
                oPara1.Range.InsertParagraphAfter();

                int senuelo = 0;
                foreach (Obras obra in obras)
                {

                    if (obra.IdTipoAutor != senuelo)
                    {
                        oPara1.Range.Text = (from n in OtrosDatosSingleton.TipoAutor
                                             where n.IdDato == obra.IdTipoAutor
                                             select n.Descripcion).ToList()[0];
                        oPara1.Range.Font.Bold = 1;
                        oPara1.Range.Font.Size = 13;
                        oPara1.Range.InsertParagraphAfter();
                        senuelo = obra.IdTipoAutor;
                    }


                    oPara1.Range.Text = obra.Titulo;
                    oPara1.Range.Font.Bold = 0;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.InsertParagraphAfter();
                }


            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

               // MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                oWord.Visible = true;
                
                
            }
        }


        public void ObrasAutores(Obras obra)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;

            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);



            try
            {

                oPara1.Range.Text = obra.Titulo;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 14;
                oPara1.Range.InsertParagraphAfter();


                int senuelo = 0;
                foreach (Autores autor in obra.LAutores)
                {
                    if (autor.IdTipoAutor != senuelo)
                    {
                        oPara1.Range.Text = (from n in OtrosDatosSingleton.TipoAutor
                                             where n.IdDato == autor.IdTipoAutor
                                             select n.Descripcion).ToList()[0];
                        oPara1.Range.Font.Bold = 1;
                        oPara1.Range.Font.Size = 13;
                        oPara1.Range.InsertParagraphAfter();
                        senuelo = autor.IdTipoAutor;
                    }

                    oPara1.Range.Text = autor.Nombre;
                    oPara1.Range.Font.Bold = 0;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.InsertParagraphAfter();
                }


            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

                // MessageBox.Show("Error ({0}) : {1}" + ex.Source + ex.Message, methodName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                oWord.Visible = true;


            }
        }

    }
}