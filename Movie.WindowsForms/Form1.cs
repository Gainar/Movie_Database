using System;
using System.Windows.Forms;
using Movie.Core.Models;
using Movie.Proxy.Proxy;
using Ninject;

namespace Movie.WindowsForms
{

    public partial class Form1 : Form
    {
        private readonly IDesktop desktopRepo;

        public Form1()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDesktop>().To<Desktop>();
            desktopRepo = kernel.Get<IDesktop>();

            InitializeComponent();
            #region Initialization

            groupBox3.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
            listBox1.Items.Clear();
            #endregion

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            #region Initialization    
            listBox1.Items.Clear();
            groupBox3.Visible = true;
            groupBox3.Text = @"Series";

            #endregion
            var x = await desktopRepo.View();
            foreach (var item in x)
            {
                if (item.Title.Trim().Length > 8)
                {
                    listBox1.Items.Add(item.Title.Trim() + "\t" + item.Year + "\t" + item.Genre.Trim() + "\t" + item.Type.Trim() + "\t" + item.Rating + "\t" + item.Name.Trim());
                }
                else
                {
                    listBox1.Items.Add(item.Title.Trim() + "\t\t" + item.Year + "\t" + item.Genre.Trim() + "\t" + item.Type.Trim() + "\t" + item.Rating + "\t" + item.Name.Trim());
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

            #region Initialization

            groupBox3.Visible = false;
            textBox2.Visible = true;
            label1.Visible = true;
            ChageVisible(true);
            button4.BringToFront();
            MessageBox.Show(@"Enter informations.");
            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            button2.BringToFront();
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mov = new MovieCreator
            {
                Title = textBox2.Text,
                Year = int.Parse(textBox3.Text),
                Genre = textBox5.Text,
                Type = textBox4.Text,
                Rating = int.Parse(textBox6.Text),
                Name = textBox7.Text
            };
            desktopRepo.Add(mov);
            button2.BringToFront();
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
            listBox1.Items.Clear();
            button1_Click(sender, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Visible = true;
            button6.Visible = true;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var x = listBox1.SelectedItem.ToString().Split('\t');
            desktopRepo.Delete(x[0]);
            listBox1.Items.Clear();
            button1_Click(sender, e);
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var mov = new MovieCreator();
            var x = listBox1.SelectedItem.ToString().Split('\t');
            var i = x[1] == "" ? 2 : 1;
            mov.Title = x[0];
            mov.Year = textBox3.Text == "" ? int.Parse(x[i]) : int.Parse(textBox3.Text);
            mov.Genre = textBox5.Text == "" ? x[i + 1] : textBox5.Text;
            mov.Type = textBox4.Text == "" ? x[i + 2] : textBox4.Text;
            mov.Rating = textBox6.Text == "" ? int.Parse(x[i + 3]) : int.Parse(textBox6.Text);
            mov.Name = textBox7.Text == "" ? x[i + 4] : textBox7.Text;
            desktopRepo.Edit(mov);
            button1_Click(sender, e);
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
        }

        internal void ChageVisible(bool x)
        {
            textBox3.Visible = x;
            textBox4.Visible = x;
            textBox5.Visible = x;
            textBox6.Visible = x;
            textBox7.Visible = x;
            label2.Visible = x;
            label3.Visible = x;
            label4.Visible = x;
            label5.Visible = x;
            label6.Visible = x;
            if (x)
            {
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
            }
        }
    }
}
