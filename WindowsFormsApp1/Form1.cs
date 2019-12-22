using System;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recognization = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
            Choices cmd = new Choices();
            //input phrases
            cmd.Add(new string[] { "Enemy top flash", "Enemy jungle flash", "Enemy middle flash", "Enemy bottom flash", "Enemy support flash" });
            GrammarBuilder builder = new GrammarBuilder();
            builder.Append(cmd);
            Grammar grammar = new Grammar(builder);

            recognization.LoadGrammarAsync(grammar);
            recognization.SetInputToDefaultAudioDevice();
            recognization.SpeechRecognized += recognized_voice;
        }

        private void recognized_voice(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Enemy top flash":
                    //set image to not available
                    pictureBox1.Image = Image.FromFile("c:\\images\\unavailableImage.png");
                    timer1.Enabled = true;
                    //set timer to 10s less than 5m (assumes user delays input by 10s)
                    richTextBox1.Text = "4";
                    richTextBox11.Text = "50";
                    break;
                case "Enemy jungle flash":
                    pictureBox2.Image = Image.FromFile("c:\\images\\unavailableImage.png");
                    timer2.Enabled = true;
                    richTextBox2.Text = "4";
                    richTextBox12.Text = "50";
                    break;
                case "Enemy middle flash":
                    pictureBox3.Image = Image.FromFile("c:\\images\\unavailableImage.png");
                    timer3.Enabled = true;
                    richTextBox3.Text = "4";
                    richTextBox13.Text = "50";
                    break;
                case "Enemy bottom flash":
                    pictureBox4.Image = Image.FromFile("c:\\images\\unavailableImage.png");
                    timer4.Enabled = true;
                    richTextBox4.Text = "4";
                    richTextBox14.Text = "50";
                    break;
                case "Enemy support flash":
                    pictureBox5.Image = Image.FromFile("c:\\images\\unavailableImage.png");
                    timer5.Enabled = true;
                    richTextBox5.Text = "4";
                    richTextBox15.Text = "50";
                    break;
            }
        }

        //start listening button
        private void button1_Click(object sender, EventArgs e)
        {
            recognization.RecognizeAsync(RecognizeMode.Multiple);
            //enable stop listening button
            button2.Enabled = true;
            //disable start listening button
            button1.Enabled = false;
        }

        //stop listening button
        private void button2_Click(object sender, EventArgs e)
        {
            recognization.RecognizeAsyncStop();
            //enable start listening button
            button1.Enabled = true;
            //disable stop listening button
            button2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if second timer 0= 0
            if(richTextBox11.Text == "0")
            {
                //if minute timer == 0 reset timer and set image to available
                if(richTextBox1.Text == "0")
                {
                    richTextBox1.Text = "5";
                    richTextBox11.Text = "00";
                    pictureBox1.Image = Image.FromFile("c:\\images\\readyImage.png");
                    timer1.Enabled = false;
                }
                else
                {
                    //set minute timer to minute timer - 1
                    richTextBox1.Text = (Int32.Parse(richTextBox1.Text) - 1).ToString();
                    //reset seconds timer to 59
                    richTextBox11.Text = "59";
                }
            }
            else
            {
                //seconds = seconds - 1
                richTextBox11.Text = (Int32.Parse(richTextBox11.Text) - 1).ToString();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (richTextBox12.Text == "0")
            {
                if (richTextBox2.Text == "0")
                {
                    richTextBox2.Text = "5";
                    richTextBox12.Text = "00";
                    pictureBox2.Image = Image.FromFile("c:\\images\\readyImage.png");
                    timer2.Enabled = false;
                }
                else
                {
                    richTextBox2.Text = (Int32.Parse(richTextBox2.Text) - 1).ToString();
                    richTextBox12.Text = "59";
                }
            }
            else
            {
                richTextBox12.Text = (Int32.Parse(richTextBox12.Text) - 1).ToString();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (richTextBox13.Text == "0")
            {
                if (richTextBox3.Text == "0")
                {
                    richTextBox3.Text = "5";
                    richTextBox13.Text = "00";
                    pictureBox3.Image = Image.FromFile("c:\\images\\readyImage.png");
                    timer3.Enabled = false;
                }
                else
                {
                    richTextBox3.Text = (Int32.Parse(richTextBox3.Text) - 1).ToString();
                    richTextBox13.Text = "59";
                }
            }
            else
            {
                richTextBox13.Text = (Int32.Parse(richTextBox13.Text) - 1).ToString();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (richTextBox14.Text == "0")
            {
                if (richTextBox4.Text == "0")
                {
                    richTextBox4.Text = "5";
                    richTextBox14.Text = "00";
                    pictureBox4.Image = Image.FromFile("c:\\images\\readyImage.png");
                    timer4.Enabled = false;
                }
                else
                {
                    richTextBox4.Text = (Int32.Parse(richTextBox4.Text) - 1).ToString();
                    richTextBox14.Text = "59";
                }
            }
            else
            {
                richTextBox14.Text = (Int32.Parse(richTextBox14.Text) - 1).ToString();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (richTextBox15.Text == "0")
            {
                if (richTextBox5.Text == "0")
                {
                    richTextBox5.Text = "5";
                    richTextBox15.Text = "00";
                    pictureBox5.Image = Image.FromFile("c:\\images\\readyImage.png");
                    timer5.Enabled = false;
                }
                else
                {
                    richTextBox5.Text = (Int32.Parse(richTextBox5.Text) - 1).ToString();
                    richTextBox15.Text = "59";
                }
            }
            else
            {
                richTextBox15.Text = (Int32.Parse(richTextBox15.Text) - 1).ToString();
            }
        }
    }
}