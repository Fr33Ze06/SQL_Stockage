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

                    // Utilisez une liste pour stocker les résultats de la requête
                    List<int> ids = new List<int>();

                    // Utilisez un objet MySqlCommand pour exécuter la requête SQL
                    using (MySqlCommand cmd = new MySqlCommand(query, connect))
                    {
                        // Utilisez un objet MySqlDataReader pour lire les résultats de la requête
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Parcourez les résultats et ajoutez chaque ID à la liste
                            while (reader.Read())
                            {
                                int idEntrepot = reader.GetInt32("id");
                                ids.Add(idEntrepot);
                            }
                        } // Le using se charge automatiquement de fermer le reader ici
                    }

                    // Après avoir fermé le reader, ajoutez les éléments à la listBox
                    listBoxEntrepot.Items.Clear();
                    foreach (int id in ids)
                    {
                        listBoxEntrepot.Items.Add(id);
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
                int quantite = 0;
                if (int.TryParse(textBoxQuantityD.Text, out int quantiteValue))
                {
                    quantite = quantiteValue;
                }
                else
                {
                    Console.WriteLine("La quantité n'est pas un nombre entier valide.");
                    return;
                }

                Console.WriteLine($"Supprimer item | ID: {id}, Nom: {nom}, Quantité: {quantite}");

                gestionStock.SupprimerObjet(id, nom, quantite);
            }
            catch (Exception ex)
            {
                // Gérez les exceptions, par exemple en affichant un message d'erreur
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }

}