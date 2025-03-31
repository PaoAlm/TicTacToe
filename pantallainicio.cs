using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using NAudio.Wave;
using System.Threading;

namespace juegogato
{
    public partial class pantallainicio : Form
    {
        private WaveOutEvent button;
        private WaveOutEvent background;

        #region LoopStream
        public class LoopStream : WaveStream
        {
            private readonly WaveStream sourceStream;

            public LoopStream(WaveStream sourceStream)
            {
                this.sourceStream = sourceStream;
                EnableLooping = true;
            }

            public bool EnableLooping { get; set; }

            public override WaveFormat WaveFormat => sourceStream.WaveFormat;

            public override long Length => sourceStream.Length;

            public override long Position
            {
                get => sourceStream.Position;
                set => sourceStream.Position = value;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int totalBytesRead = 0;

                while (totalBytesRead < count)
                {
                    int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                    if (bytesRead == 0)
                    {
                        if (sourceStream.Position == 0 || !EnableLooping)
                        {
                            break;
                        }
                        sourceStream.Position = 0;
                    }
                    totalBytesRead += bytesRead;
                }
                return totalBytesRead;
            }
        }

        #endregion

        public pantallainicio()
        {
            InitializeComponent();

            // Configuración de la música de fondo en loop
            background = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/menu_background.wav");
            var loopStream = new LoopStream(audioFileReader);
            background.Init(loopStream);
            background.Play();
        }

        private void MenuButtonsSound()
        {
            // Configuración de la música de fondo en loop
            button = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/menu_button.wav");
            // Inicializa el dispositivo de reproducción con el lector de audio
            button.Init(audioFileReader);
            button.Play();
        }

        private void controltextbox1()
        {
            if (nombre1.Text.Trim() != string.Empty && nombre1.Text.All(Char.IsLetter))
            {
                //button1.Enabled = true;
                errorProvider1.SetError(nombre1, "");
            }
            else
            {
                if (!(nombre1.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(nombre1, "Username must contain only letters.");
                }
                else
                {
                    errorProvider1.SetError(nombre1, "Username missing.");
                }

                button1.Enabled = false;
                nombre1.Focus();
            }
        }

        private void controltextbox2()
        {
            if (nombre2.Text.Trim() != string.Empty && nombre2.Text.All(Char.IsLetter))
            {
                button1.Enabled = true;
                errorProvider1.SetError(nombre2, "");
            }
            else
            {
                if (!(nombre2.Text.All(Char.IsLetter)))
                {
                    errorProvider1.SetError(nombre2, "Username must contain only letters.");
                }
                else
                {
                    errorProvider1.SetError(nombre2, "Username missing.");
                }

                button1.Enabled = false;
                nombre2.Focus();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pantallainicio_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuButtonsSound();
            background.Stop();
            this.Hide();

            Form1 partida = new Form1(null);

            // Asignar los nombres de los jugadores al segundo formulario
            partida.P1 = nombre1.Text;
            partida.P2 = nombre2.Text;

            partida.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuButtonsSound();
            Thread.Sleep(1000);
            Application.Exit();
        }

        private void nombre1_TextChanged(object sender, EventArgs e)
        {
            controltextbox1();
            
        }

        private void nombre2_TextChanged(object sender, EventArgs e)
        {
            controltextbox2();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pantallainicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Detener la música al cerrar la ventana
            background.Stop();  // Detiene la reproducción de audio
            background.Dispose();  // Libera los recursos usados por NAudio
            // Cierra todos los formularios y termina la aplicación
            Application.Exit();
        }
    }
}
