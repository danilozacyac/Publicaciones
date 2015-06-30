using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
using Publicaciones.Dao;
using Publicaciones.Singletons;

namespace Publicaciones.Reportes
{
    public class GeneraWord
    {
        readonly string filepath = Path.GetTempFileName() + ".docx";

        int fila = 1;

        Word.Application oWord;
        Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";

        public void AutoresObras(Autores autor, ObservableCollection<Obras> obras, bool incluyeSintesis)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            
            try
            {
                oPara1.Range.Text = autor.Nombre;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 18;
                oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
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
                        oPara1.Range.Font.Size = 14;
                        oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oPara1.Range.InsertParagraphAfter();
                        senuelo = obra.IdTipoAutor;
                    }

                    oPara1.Range.Text = obra.Titulo;
                    oPara1.Range.Font.Bold = 0;
                    oPara1.Range.Font.Size = 12;
                    oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    oPara1.Range.InsertParagraphAfter();

                    if (incluyeSintesis)
                    {
                        Word.Paragraph paraSintesis = oDoc.Content.Paragraphs.Add(ref oMissing);
                        paraSintesis.Range.Text = obra.Sintesis;

                        paraSintesis.Range.Font.Bold = 0;
                        paraSintesis.Range.Font.Size = 12;
                        paraSintesis.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        //paraSintesis.Range.Paragraphs.LeftIndent = Convert.ToSingle(point);
                        paraSintesis.Range.InsertParagraphAfter();
                        //paraSintesis = null;
                    }
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
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);

            try
            {
                oPara1.Range.Text = obra.Titulo;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 16;
                oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.InsertParagraphAfter();

                oPara1.Range.Text = obra.Sintesis;
                oPara1.Range.Font.Bold = 0;
                oPara1.Range.Font.Size = 13;
                oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                oPara1.Range.InsertParagraphAfter();
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
                        oPara1.Range.Font.Size = 12;
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

        public void ListaObrasDisposicion(ObservableCollection<Obras> listaCompletaObras)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);

            try
            {
                List<Obras> obras = (from n in listaCompletaObras
                                     where n.ForPersonal == true
                                     orderby n.MedioPublicacion
                                     select n).ToList();

                int consecutivo = 1;
                int medioPublicacion = 0;

                foreach (Obras obra in obras)
                {

                    if (obra.MedioPublicacion != medioPublicacion)
                    {
                        medioPublicacion = obra.MedioPublicacion;
                        oPara1.Range.Text = (from n in OtrosDatosSingleton.MedioPublicacion
                                                 where n.IdDato == medioPublicacion
                                                 select n.Descripcion).ToList()[0];
                        oPara1.Range.Font.Name = "Arial";
                        oPara1.Range.Font.Bold = 1;
                        oPara1.Range.Font.Size = 14;
                        oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        oPara1.Range.InsertParagraphAfter();
                        oPara1.Range.InsertParagraphAfter();
                    }


                    oPara1.Range.Text = consecutivo + ".  " + obra.Titulo;
                    oPara1.Range.Font.Name = "Arial";
                    oPara1.Range.Font.Bold = 0;
                    oPara1.Range.Font.Size = 10;
                    oPara1.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara1.Range.InsertParagraphAfter();

                    consecutivo++;
                    
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