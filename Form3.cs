using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juegogato
{
    public partial class Ganador : Form
    {
        private Form1 _form1;
        private WaveOutEvent victory_sound;
        private WaveOutEvent button;

        public Ganador(Form1 form1, string mensaje)
        {
            InitializeComponent();
            _form1 = form1;
            lblGanador.Text = mensaje;
            VictorySound();
        }

        private void VictorySound()
        {
            // Configuración de la música de fondo en loop
            victory_sound = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/victory.wav");
            // Inicializa el dispositivo de reproducción con el lector de audio
            victory_sound.Init(audioFileReader);
            victory_sound.Play();
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
        public string Mensaje
        {
            set { lblGanador.Text = value; }
        }

        public void lblGanador_Click(object sender, EventArgs e)
        {

        }

        public void btn_continue_Click(object sender, EventArgs e)
        {
            ButtonsSound();
            this.Hide();
            _form1.continuar();
        }

        private void Ganador_Load(object sender, EventArgs e)
        {

        }
    }
}
