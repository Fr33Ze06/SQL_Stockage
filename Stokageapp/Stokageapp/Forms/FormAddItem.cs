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


namespace Stokageapp.Forms
{
    public partial class FormAddItem : Form
    {
        private MySqlConnection connect;
        private MySqlCommand command;
        private string connectionString = "Server=127.0.0.1;User ID=root;Password=;Database=stockage";
        public FormAddItem()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            buttonAdditemtostock.BackColor = Themecolor.PrimaryColor;
            buttonAdditemtostock.ForeColor = Color.White;
        }
    }
}
