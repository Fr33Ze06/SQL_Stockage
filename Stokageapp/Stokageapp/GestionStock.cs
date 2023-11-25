using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Stokageapp.Forms;

public class GestionStock
{
    private MySqlConnection connect;

    public GestionStock(string connectionString)
    {
        connect = new MySqlConnection(connectionString);
        connect.Open();
    }

    public static GestionStock gestionStock { get; internal set; }

    public void SupprimerObjet(int id, string nom, int quantite)
    {

        try
        {
            // Vérifier s'il y a suffisamment d'objets dans l'entrepôt
            string verifQuantiteQuery = "SELECT quantity, id_entrepot FROM Stock " +
                            "JOIN Liste_objets ON Stock.id_objet = Liste_objets.id " +
                            "WHERE Stock.id_entrepot = @Id AND Liste_objets.name = @Nom";

            using (MySqlCommand cmdVerifQuantite = new MySqlCommand(verifQuantiteQuery, connect))
            {
                cmdVerifQuantite.Parameters.AddWithValue("@Id", id);
                cmdVerifQuantite.Parameters.AddWithValue("@Nom", nom);
                Console.WriteLine($"ID: {id}, Nom: {nom}");

                using (MySqlDataReader reader = cmdVerifQuantite.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int quantiteActuelle = Convert.ToInt32(reader["quantity"]);
                        int idEntrepot = Convert.ToInt32(reader["id_entrepot"]);

                        if (quantiteActuelle < quantite)
                        {
                            // Gérer le cas où la quantité à supprimer est supérieure à la quantité disponible
                            Console.WriteLine("Quantité insuffisante dans l'entrepôt.");
                            return;
                        }

                        // Mettre à jour la quantité dans la base de données
                        int nouvelleQuantite = quantiteActuelle - quantite;

                        if (nouvelleQuantite > 0)
                        {
                            string updateQuantiteQuery = "UPDATE Stock SET quantity = @Quantite " +
                                                         "WHERE id_entrepot = @IdEntrepot AND id_objet = @IdObjet";

                            using (MySqlCommand cmdUpdateQuantite = new MySqlCommand(updateQuantiteQuery, connect))
                            {
                                cmdUpdateQuantite.Parameters.AddWithValue("@Quantite", nouvelleQuantite);
                                cmdUpdateQuantite.Parameters.AddWithValue("@IdEntrepot", idEntrepot);
                                cmdUpdateQuantite.Parameters.AddWithValue("@IdObjet", id);
                                cmdUpdateQuantite.ExecuteNonQuery();
                                Console.WriteLine("Quantité mise à jour dans l'entrepôt.");
                            }
                        }
                        else
                        {
                            // Supprimer l'objet s'il n'y a plus de stock
                            string deleteObjetQuery = "DELETE FROM Stock " +
                                                      "WHERE id_entrepot = @IdEntrepot AND id_objet = @IdObjet";

                            using (MySqlCommand cmdDeleteObjet = new MySqlCommand(deleteObjetQuery, connect))
                            {
                                cmdDeleteObjet.Parameters.AddWithValue("@IdEntrepot", idEntrepot);
                                cmdDeleteObjet.Parameters.AddWithValue("@IdObjet", id);
                                cmdDeleteObjet.ExecuteNonQuery();
                                Console.WriteLine("Objet supprimé de l'entrepôt.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Objet non trouvé dans l'entrepôt.");
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            // Gérez les exceptions, par exemple en affichant un message d'erreur
            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
        }
    }
}