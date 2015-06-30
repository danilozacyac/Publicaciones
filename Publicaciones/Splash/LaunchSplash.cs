using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Publicaciones.Dao;
using Publicaciones.Singletons;

namespace Publicaciones.Splash
{
    public class LaunchSplash
    {
        public LaunchSplash()
        {
            SplashWin splasher = new SplashWin();
            splasher.Show();

            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here
            
            var temp2 = ObrasSingleton.Obras;
            var temp = AutoresSingleton.Autores;

            for (int i = 0; i < 1000; i++)
            {
                MessageListener.Instance.ReceiveMessage(string.Format("Cargando módulos {0}", i));
                Thread.Sleep(2);
            }

            foreach (Autores autor in AutoresSingleton.Autores)
            {
                MessageListener.Instance.ReceiveMessage(string.Format("Autores: {0}", autor.Nombre));
                Thread.Sleep(20);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            splasher.Close();
        }

        /// <summary>
        /// Creates a BackgroundWorker class to do work
        /// on a background thread.
        /// </summary>
        private void DoBackgroundWork()
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
        void DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        /// <summary>
        /// Occurs when the BackgroundWorker reports a progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //pbLoad.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Occurs when the BackgroundWorker has completed its work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_backgroundButton.IsEnabled = true;
            //pbLoad.Visibility = Visibility.Collapsed;
        }
    }
}
