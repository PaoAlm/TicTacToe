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
using static juegogato.pantallainicio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace juegogato
{
    public partial class Form1 : Form
    {
        public string P1, P2, mensaje;
        private bool turno = true;
        int puntajeP1 = 0, puntajeP2 = 0;
        private Ganador _ganador;
        private tie _tie;
        private WaveOutEvent background;
        private WaveOutEvent button;



        List<Button> botonesLogica = new List<Button>();

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

        public Form1(Ganador ganador)
        {
            InitializeComponent();
            InicializarBotonesTablero(); // Llama al método para inicializar los botones del tablero

            // Configuración de la música de fondo en loop
            background = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/background.wav");
            var loopStream = new LoopStream(audioFileReader);
            background.Init(loopStream);
            background.Play();

            if (ganador != null)
            {
                _ganador = ganador;
            }
        }
        private void ButtonSound()
        {
            // Configuración de la música de fondo en loop
            button = new WaveOutEvent();
            var audioFileReader = new AudioFileReader("Resources/sound/menu_button.wav");
            // Inicializa el dispositivo de reproducción con el lector de audio
            button.Init(audioFileReader);
            button.Play();
        }

        // Método para detener el sonido de fondo
        public void StopBackgroundSound()
        {
            if (background != null)
            {
                background.Stop(); // Detiene la reproducción
            }
        }

        #region InicializarBotonesTablero
        private void InicializarBotonesTablero()
        {
            // Agrega los botones del tablero a la lista y asigna el evento Click
            botonesLogica.Add(btn1);
            botonesLogica.Add(btn2);
            botonesLogica.Add(btn3);
            botonesLogica.Add(btn4);
            botonesLogica.Add(btn5);
            botonesLogica.Add(btn6);
            botonesLogica.Add(btn7);
            botonesLogica.Add(btn8);
            botonesLogica.Add(btn9);

            foreach (Button boton in botonesLogica)
            {
                boton.Click += BotonesLogica_Click;
            }
        }
        #endregion

        #region ActualizarJugador
        private void ActualizarJugador()
        {
            if (turno)
            {
                lblTurno.Text = P1 + "'s turn.";
            }
            else
            {
                lblTurno.Text = P2 + "'s turn.";
            }
        }
        #endregion



        private void BotonesLogica_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button.Text == "") // Verifica si el botón está vacío antes de asignar el texto
            {
                if (turno)
                {
                    button.Text = "❌";
                }
                else
                {
                    button.Text = "○";
                }

                button.Enabled = false;

                turno = !turno; // Cambia el turno solo si se ha jugado en este turno
                ActualizarJugador();

                Resultados();
            }
        }

        #region DeshabilitarBotones
        private void DeshabilitarBotones()
        {
            foreach (Button button in botonesLogica)
            {
                button.Enabled = false;
            }
        }
        #endregion

        #region HabilitarBotones
        private void HabilitarBotones()
        {
            foreach (Button button in botonesLogica)
            {
                button.Enabled = true;
            }
        }
        #endregion

        #region EvaluarGanador
        private bool EvaluarGanador()
        {
            if (btn1.Text == btn2.Text && btn2.Text == btn3.Text && btn1.Text != "")
            {
                return true;
            }
            if (btn4.Text == btn5.Text && btn5.Text == btn6.Text && btn4.Text != "")
            {
                return true;
            }
            if (btn7.Text == btn8.Text && btn8.Text == btn9.Text && btn7.Text != "")
            {
                return true;
            }

            if (btn1.Text == btn4.Text && btn4.Text == btn7.Text && btn1.Text != "")
            {
                return true;
            }
            if (btn2.Text == btn5.Text && btn5.Text == btn8.Text && btn2.Text != "")
            {
                return true;
            }
            if (btn3.Text == btn6.Text && btn6.Text == btn9.Text && btn3.Text != "")
            {
                return true;
            }

            if (btn1.Text == btn5.Text && btn5.Text == btn9.Text && btn1.Text != "")
            {
                return true;
            }
            if (btn3.Text == btn5.Text && btn5.Text == btn7.Text && btn3.Text != "")
            {
                return true;
            }

            return false;
        }

        #endregion

        #region EsEmpate
        private bool EsEmpate()
        {
            // Verifica si todos los botones están llenos (es decir, tienen un texto)
            foreach (Button button in botonesLogica)
            {
                if (button.Text == "")
                {
                    return false; // Si hay al menos un botón vacío, no hay empate
                }
            }
            return true; // Si no hay botones vacíos, hay un empate
        }

        #endregion

        #region ReiniciarPuntaje
        public void ReiniciarPuntaje()
        {
            puntajeP1 = 0;
            puntajeP2 = 0;
            lblpuntajeP1.Text = puntajeP1.ToString();
            lblpuntajeP2.Text = puntajeP2.ToString();
        }

        #endregion

        public void Resultados()
        {
            if (EvaluarGanador())
            {
                DeshabilitarBotones();

                if (!turno) // Si evalúa al ganador y turno es falso, significa que P1 ganó
                {
                    string mensaje = P1;
                    Ganador resultado = new Ganador(this, mensaje);
                    resultado.TopMost = true; // Asegura que siempre esté por encima
                    resultado.Show();

                    puntajeP1 += 1;
                    lblpuntajeP1.Text = puntajeP1.ToString();
                }
                else // De lo contrario, P2 ganó
                {
                    string mensaje = P2;
                    Ganador resultado = new Ganador(this, mensaje);
                    resultado.TopMost = true; // Asegura siempre esté por encima
                    resultado.Show();

                    puntajeP2 += 1;
                    lblpuntajeP2.Text = puntajeP2.ToString();
                }
            }
            else if (EsEmpate()) // Verifica si hay un empate
            {
                tie empate = new tie(this);
                empate.TopMost = true; // Asegura que siempre esté por encima
                empate.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            puntajeP1 = 0;
            lblpuntajeP1.Text = puntajeP1.ToString();

            puntajeP2 = 0;
            lblpuntajeP2.Text = puntajeP2.ToString();

            //lbl.Visible = false;
            lblTurno.Text = P1 + "'s turn.";
            lblP1.Text = P1 + ":";
            lblP2.Text = P2 + ":";
        }

        public void continuar()
        {
            btn1.Text = ""; btn2.Text = ""; btn3.Text = "";
            btn4.Text = ""; btn5.Text = ""; btn6.Text = "";
            btn7.Text = ""; btn8.Text = ""; btn9.Text = "";

            HabilitarBotones();

        }
        private void lblWinner_Click(object sender, EventArgs e)
        {
        }

        private void lblTurno_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void config_Click(object sender, EventArgs e)
        {
            ButtonSound();
            config form2 = new config(this);
            form2.TopMost = true; // Asegura que Form2 siempre esté por encima
            form2.Show();
        }
    }
}
