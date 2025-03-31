using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegogato
{
    public partial class tie : Form
    {
        private Form1 _form1;
        private WaveOutEvent tie_sound;
        private WaveOutEvent button;    
        public tie(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            TieSound();
        }

        private void TieSound()
        {
            // Configuración de la música de fondo en loop
            tie_sound = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/tie.wav");
            // Inicializa el dispositivo de reproducción con el lector de audio
            tie_sound.Init(audioFileReader);
            tie_sound.Play();
            /*
            // Espera 3 segundos (3000 milisegundos)
            Thread.Sleep(3000);
            tie_sound.Stop(); // Detiene la reproducción después de 3 segundos
            */
        }

        private void ButtonsSound()
        {
            // Configuración de la música de fondo en loop
            button = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/menu_button.wav");
            // Inicializa el dispositivo de reproducción con el lector de audio
            button.Init(audioFileReader);
            button.Play();
        }

        private void btn_continuetie_Click(object sender, EventArgs e)
        {
            ButtonsSound();
            this.Hide();
            _form1.continuar();
        }
    }
}
