using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Drawing2D;


namespace Stokageapp
{
    public partial class FormItems : Form
    {
        private MySqlConnection connect;
        private MySqlCommand command;
        private string connectionString = "Server=127.0.0.1;User ID=root;Password=;Database=stockage";
        public FormItems()
        {
            InitConnection();
            InitializeComponent();
            Getstockage();
        }
        
        private void InitConnection()
        {
            try
            {
                connect = new MySqlConnection(connectionString);
                connect.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }

        private void Getstockage()
        {
            string query = "SELECT liste_objets.*, stock.quantity, types.type AS type_name FROM stock JOIN liste_objets ON stock.id_objet = liste_objets.id JOIN types ON liste_objets.id_type = types.id";
            command = new MySqlCommand(query, connect);
            MySqlDataAdapter data = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in table.Rows)
            {
                Panel panel = new Panel();

                Label quantity = new Label();
                Label nomobj = new Label();
                PictureBox image = new PictureBox();
                // 
                // label2
                // 
                quantity.Dock = DockStyle.Bottom;
                quantity.Location = new Point(0, 200);
                quantity.Name = "label2";
                quantity.Size = new Size(270, 56);
                quantity.TabIndex = 1;
                quantity.TextAlign = ContentAlignment.MiddleCenter;
                quantity.Text = row["quantity"].ToString();
                // 
                // pictureBox1
                // 
                image.Location = new Point(3, 39);
                image.Name = "pictureBox1";
                image.Size = new Size(267, 158);
                image.TabIndex = 2;
                image.TabStop = false;
                // Charger l'image depuis l'URL
                string imageUrl = row["image"].ToString();
                pictureBox1.Image = LoadImageFromUrl(imageUrl);
                // 
                // label1
                // 
                nomobj.Dock = DockStyle.Top;
                nomobj.Location = new Point(0, 0);
                nomobj.Name = "label1";
                nomobj.Size = new Size(270, 36);
                nomobj.TabIndex = 0;
                nomobj.TextAlign = ContentAlignment.MiddleCenter;
                nomobj.Text = row["name"].ToString();
                //Panel
                panel.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(18)))));
                panel.Location = new Point(3, 3);
                panel.Name = row["id"].ToString();
                panel.Size = new Size(270, 256);
                panel.TabIndex = 0;
                panel.Controls.Add(quantity);
                panel.Controls.Add(image);
                panel.Controls.Add(nomobj);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Console.WriteLine(panel.Name);
        }

        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    byte[] data = webClient.DownloadData(url);
                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        return Image.FromStream(mem);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement de l'image depuis l'URL : " + ex.ToString());
                return null; // Ou une image par défaut, selon vos besoins
            }

        }

    }
}
