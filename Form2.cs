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
    public partial class config : Form
    {
        private Form1 _form1;
        private WaveOutEvent button;

        public config(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
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

        private void Ejecutarbtn_continueDeForm1()
        {
            _form1.continuar(); // Simulamos el evento de clic de button1 en Form1
        }

        private void ReiniciarPuntajeDeForm1()
        {
            if (_form1 != null)
            {
                _form1.ReiniciarPuntaje(); // Simulamos el evento de clic de button1 en Form1
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonsSound();

            // Obtener referencia a Form1
            Form1 formulario1 = Application.OpenForms["Form1"] as Form1;

            // Detener el sonido de fondo en Form1 antes de cerrarlo
            if (formulario1 != null)
            {
                formulario1.StopBackgroundSound(); // Llamar al método para detener el sonido
            }

            formulario1.Close();

            // Crear y mostrar pantallainicio
            pantallainicio inicio = new pantallainicio();
            inicio.Show();

            // Cerrar Form2
            this.Close();
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            ButtonsSound();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonsSound();
            Ejecutarbtn_continueDeForm1();
            ReiniciarPuntajeDeForm1();
            this.Hide();
        }
    }
}
