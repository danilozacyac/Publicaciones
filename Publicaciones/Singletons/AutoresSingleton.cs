using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Publicaciones.Dao;
using Publicaciones.Models;

namespace Publicaciones.Singletons
{
    public class AutoresSingleton
    {

        private static ObservableCollection<Autores> autores;

        private AutoresSingleton()
        {
        }

        public static ObservableCollection<Autores> Autores
        {
            get
            {
                if (autores == null)
                {
                    autores = new ObservableCollection<Autores>();
                    DoBackgroundWork();
                }

                return autores;
            }
        }

        /// <summary>
        /// Creates a BackgroundWorker class to do work
        /// on a background thread.
        /// </summary>
        private static void DoBackgroundWork()
        {
            BackgroundWorker worker = new BackgroundWorker();

            // Tell the worker to report progress.
            worker.WorkerReportsProgress = true;

            worker.ProgressChanged += ProgressChanged;
            worker.DoWork += DoWork;
            worker.RunWorkerCompleted += WorkerCompleted;
            worker.RunWorkerAsync();
        }


        /// <summary>
        /// The work for the BackgroundWorker to perform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        static void DoWork(object sender, DoWorkEventArgs e)
        {
            new AutoresModel().GetAutores(autores);

        }

        /// <summary>
        /// Occurs when the BackgroundWorker reports a progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //pbLoad.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Occurs when the BackgroundWorker has completed its work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_backgroundButton.IsEnabled = true;
            //pbLoad.Visibility = Visibility.Collapsed;
        }
    }
}
