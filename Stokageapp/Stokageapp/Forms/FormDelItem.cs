using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Stokageapp.Forms
{
    public partial class FormDelItem : Form
    {
        private MySqlConnection connect;
        private MySqlCommand command;
        private string connectionString = "Server=127.0.0.1;User ID=root;Password=;Database=stockage";
        private GestionStock gestionStock;

        public FormDelItem()
        {
            InitializeComponent();
            InitConnection();
            LoadTheme();
            LoadEntrepotIds();
            gestionStock = new GestionStock(connectionString);
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

        private void LoadTheme()
        {
            buttonDelstockitem.BackColor = Themecolor.PrimaryColor;
            buttonDelstockitem.ForeColor = Color.White;
        }

        private void LoadEntrepotIds()
        {
            try
            {
                // Assurez-vous que la connexion à la base de données est ouverte
                if (connect.State == ConnectionState.Open)
                {
                    // Définissez votre commande SQL pour récupérer les IDs des entrepôts
                    string query = "SELECT id FROM entrepots";

                    // Utilisez un objet MySqlCommand pour exécuter la requête SQL
                    using (MySqlCommand cmd = new MySqlCommand(query, connect))
                    {
                        // Utilisez un objet MySqlDataReader pour lire les résultats de la requête
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Effacez la liste actuelle des IDs d'entrepôt
                            listBoxEntrepot.Items.Clear();

                            // Parcourez les résultats et ajoutez chaque ID à la liste
                            while (reader.Read())
                            {
                                int idEntrepot = reader.GetInt32("id");
                                listBoxEntrepot.Items.Add(idEntrepot);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérez les exceptions, par exemple en affichant un message d'erreur
                MessageBox.Show($"Une erreur s'est produite lors du chargement des IDs d'entrepôt : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelstockitem_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer les valeurs saisies par l'utilisateur
                int id = Convert.ToInt32(listBoxEntrepot.Text);
                string nom = textBoxItemNameD.Text;
                int quantite = Convert.ToInt32(textBoxQuantityD.Text);
                Console.WriteLine("Ceci est un message dans la console.");

                gestionStock.SupprimerObjet(id, nom, quantite);

                // Mettez à jour votre interface ou effectuez d'autres actions après la suppression réussie
            }
            catch (Exception ex)
            {
                // Gérez les exceptions, par exemple en affichant un message d'erreur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}