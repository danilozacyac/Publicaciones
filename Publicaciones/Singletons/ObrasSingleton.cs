using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Publicaciones.Dao;
using Publicaciones.Models;

namespace Publicaciones.Singletons
{
    public class ObrasSingleton
    {
        private static ObservableCollection<Obras> obras;
        public static bool isObrasComplete = false;

        private ObrasSingleton()
        {
        }

        public static ObservableCollection<Obras> Obras
        {
            get
            {
                if (obras == null)
                {
                    obras = new ObservableCollection<Obras>();
                    DoBackgroundWork();
                    
                }

                return obras;
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
            new ObrasModel().GetObras(obras);

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
            isObrasComplete = true;
            //_backgroundButton.IsEnabled = true;
            //pbLoad.Visibility = Visibility.Collapsed;
        }
    }
}
