using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    

    public class Descargador
    {
        private string html;
        private Uri direccion;
        private WebClient cliente;

        // Delegado del evento
        public delegate void EventCompletado(string html);
        public delegate void EventProgreso(int prog);
        // Evento del tipo del delegado
        public event EventCompletado EventoCompletado;//evento con el que carga la web
        public event EventProgreso EventoProgreso;//evento del progreso del tiempo

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.EventoProgreso(e.ProgressPercentage);
        }


        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.EventoCompletado(this.html = e.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
