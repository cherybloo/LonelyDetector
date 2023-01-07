using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;

namespace idiota
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer sz = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine se = new SpeechRecognitionEngine();
        Choices clist= new Choices();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start to record audio (button click)
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            clist.Add(new string[] { "hello", "how are you?","lonely", "thank you", "shut up" });
            Grammar gr = new Grammar(clist);


            try
            {
                se.RequestRecognizerUpdate();
                se.LoadGrammar(gr);
                se.SpeechRecognized += se_SpeechRecognized;
                se.SetInputToDefaultAudioDevice();
                se.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Nigga what u doin");
                MessageBox.Show(ex.Message, "Nigga what u doin");
            }
        }

        private void se_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //throw new NotImplementedException();
            switch (e.Result.Text.ToString())
            {
                case "hello":
                    sz.SpeakAsync("Hello too Digga");
                    break;
                case "how are you?":
                    sz.SpeakAsync("I'm fine bitch. Not like you lonely depressed boy!");
                    break;
                case "lonely":
                        
                    break;
                case "thank you":
                    Application.Exit();
                    break;
                case "shut up":
                    sz.SpeakAsync("You shut the fuck up!");
                    break;
            }
            txtContent.Text += e.Result.Text.ToString() + Environment.NewLine;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            se.RecognizeAsyncStop();
            btnStart.Enabled = true;
            btnStop.Enabled= false;
        }
    }
}
