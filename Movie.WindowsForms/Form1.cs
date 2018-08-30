using ConsoleApp1;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace Movie.WindowsForms
{

    public partial class Form1 : Form
    {
        public Form1()
        {
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
            groupBox3.Text = "Series";

            #endregion

            var client = new HttpClient();
            var response = await client.GetAsync("http://moviedatabase.gear.host/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                var test = await response.Content.ReadAsAsync<List<MovieCreator>>();
                foreach (var item in test)
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

        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region Initialization

            groupBox3.Visible = false;
            textBox2.Visible = true;
            label1.Visible = true;
            ChageVisible(true);
            button4.BringToFront();
            MessageBox.Show("Enter informations.");
            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
            button2.BringToFront();
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);


        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var mov = new MovieCreator
            {
                Title = textBox2.Text,
                Year = int.Parse(textBox3.Text),
                Genre = textBox5.Text,
                Type = textBox4.Text,
                Rating = int.Parse(textBox6.Text),
                Name = textBox7.Text
            };

            await client.PostAsJsonAsync("http://moviedatabase.gear.host/api/Movies", mov);
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

        private async void button5_Click(object sender, EventArgs e)
        {
            var repo = new MovieRepository();
            var client = new HttpClient();
            var x = listBox1.SelectedItem.ToString().Split('\t');
            await client.DeleteAsync($"http://moviedatabase.gear.host/api/Movies/{x[0]}/Delete");
            listBox1.Items.Clear();
            button1_Click(sender, e);
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var mov = new MovieCreator();
            var x = listBox1.SelectedItem.ToString().Split('\t');
            var i = x[1] == "" ? 2 : 1;
            mov.Title = x[0];
            mov.Year = textBox3.Text == "" ? int.Parse(x[i]) : int.Parse(textBox3.Text);
            mov.Genre = textBox5.Text == "" ? x[i + 1] : textBox5.Text;
            mov.Type = textBox4.Text == "" ? x[i + 2] : textBox4.Text;
            mov.Rating = textBox6.Text == "" ? int.Parse(x[i + 3]) : int.Parse(textBox6.Text);
            mov.Name = textBox7.Text == "" ? x[i + 4] : textBox7.Text;
            await client.PutAsJsonAsync($"http://moviedatabase.gear.host/api/Movies/{mov.Title}", mov);
            button1_Click(sender, e);
            button5.Visible = false;
            button6.Visible = false;
            textBox2.Visible = false;
            label1.Visible = false;
            ChageVisible(false);
        }

        private void ChageVisible(Boolean x)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
