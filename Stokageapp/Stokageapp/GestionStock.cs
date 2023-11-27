using System;
using System.Collections.Generic;
using System.Data;
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

    public void Dispose()
    {
        if (connect != null && connect.State == ConnectionState.Open)
        {
            connect.Close();
        }
    }

    public static GestionStock gestionStock { get; internal set; }

    public void SupprimerObjet(int idEntrepot, string nom, int quantite)
    {
        try
        {
            Console.WriteLine($"SupprimerObjet: Start. ID Entrepot: {idEntrepot}, Nom: {nom}, Quantité: {quantite}");

            // Vérifier s'il y a suffisamment d'objets dans l'entrepôt
            string verifQuantiteQuery = "SELECT quantity FROM Stock " +
                            "JOIN Liste_objets ON Stock.id_objet = Liste_objets.id " +
                            "WHERE Stock.id_entrepot = @Id AND Liste_objets.name = @Nom";


            using (MySqlCommand cmdVerifQuantite = new MySqlCommand(verifQuantiteQuery, connect))
            {
                cmdVerifQuantite.Parameters.AddWithValue("@Id", idEntrepot);
                cmdVerifQuantite.Parameters.AddWithValue("@Nom", nom);

                using (MySqlDataReader readerSupp = cmdVerifQuantite.ExecuteReader())
                {

                    if (readerSupp.Read())
                    {
                        int quantiteActuelle = Convert.ToInt32(readerSupp["quantity"]);

                        Console.WriteLine($"SupprimerObjet: Quantité actuelle: {quantiteActuelle}, ID Entrepot: {idEntrepot}");

                        if (quantiteActuelle < quantite)
                        {
                            // Gérer le cas où la quantité à supprimer est supérieure à la quantité disponible
                            Console.WriteLine("SupprimerObjet: Quantité insuffisante dans l'entrepôt.");
                            return;
                        }

                        readerSupp.Close();
                        // Mettre à jour la quantité dans la base de données
                        int nouvelleQuantite = quantiteActuelle - quantite;
                        Console.WriteLine($"NOUVELLE Q: {nouvelleQuantite} ID ENTREPOT: {idEntrepot}"); //ID OBJET: {idObjet}");

                        if (nouvelleQuantite > 0)
                        {
                            using (MySqlTransaction transaction = connect.BeginTransaction())
                            {
                                try
                                {
                                    string updateQuantiteQuery = "UPDATE Stock SET quantity = @Quantite " +
                                                                 "WHERE id_entrepot = @IdEntrepot AND id_objet = (SELECT id FROM Liste_objets WHERE name = @Nom)";

                                    using (MySqlCommand cmdUpdateQuantite = new MySqlCommand(updateQuantiteQuery, connect))
                                    {
                                        cmdUpdateQuantite.Parameters.AddWithValue("@Quantite", nouvelleQuantite);
                                        cmdUpdateQuantite.Parameters.AddWithValue("@IdEntrepot", idEntrepot);
                                        cmdUpdateQuantite.Parameters.AddWithValue("@Nom", nom);
                                        cmdUpdateQuantite.ExecuteNonQuery();
                                        Console.WriteLine("SupprimerObjet: Quantité mise à jour dans l'entrepôt.");
                                    }

                                    transaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Erreur : {ex.Message}");
                                    transaction.Rollback();
                                }
                            }
                        }
                        else
                        {
                            // Supprimer l'objet s'il n'y a plus de stock
                            string deleteObjetQuery = "DELETE FROM Stock " +
                                                      "WHERE id_entrepot = @IdEntrepot AND id_objet = (SELECT id FROM Liste_objets WHERE name = @Nom)";

                            using (MySqlCommand cmdDeleteObjet = new MySqlCommand(deleteObjetQuery, connect))
                            {
                                cmdDeleteObjet.Parameters.AddWithValue("@IdEntrepot", idEntrepot);
                                cmdDeleteObjet.Parameters.AddWithValue("@Nom", nom);
                                cmdDeleteObjet.ExecuteNonQuery();
                                Console.WriteLine("SupprimerObjet: Objet supprimé de l'entrepôt.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("SupprimerObjet: Objet non trouvé dans l'entrepôt.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SupprimerObjet: Une erreur s'est produite dans la gestionstock.cs : {ex.Message}");
        }
    }





    public void AjouterObjet(int id, string nom, int quantite, string type)
    {
        try
        {
            // Vérifier si l'objet existe déjà dans la base de données
            string verifObjetQuery = "SELECT id FROM Liste_objets WHERE name = @Nom";

            using (MySqlCommand cmdVerifObjet = new MySqlCommand(verifObjetQuery, connect))
            {
                cmdVerifObjet.Parameters.AddWithValue("@Nom", nom);

                using (MySqlDataReader readerVerifObjet = cmdVerifObjet.ExecuteReader())
                {
                    try
                    {
                        if (readerVerifObjet.Read())
                        {
                            Console.WriteLine("L'objet existe déjà dans la base de données. Vous pouvez mettre à jour la quantité si nécessaire.");
                            return;
                        }
                    }
                    finally
                    {
                        readerVerifObjet.Close();
                    }
                }
            }

            // Récupérer l'ID de type
            string getTypeQuery = "SELECT id FROM types WHERE type = @Type";

            int idType = -1; // Valeur par défaut au cas où le type n'existe pas
            using (MySqlCommand cmdGetType = new MySqlCommand(getTypeQuery, connect))
            {
                cmdGetType.Parameters.AddWithValue("@Type", type);

                using (MySqlDataReader readerGetType = cmdGetType.ExecuteReader())
                {
                    try
                    {
                        if (readerGetType.Read())
                        {
                            idType = readerGetType.GetInt32("id");
                        }
                    }
                    finally { readerGetType.Close(); }
                }
            }

            // Ajouter l'objet dans la base de données
            string ajoutObjetQuery = "INSERT INTO Liste_objets (name, id_type) VALUES (@Nom, @IdType)";

            using (MySqlCommand cmdAjoutObjet = new MySqlCommand(ajoutObjetQuery, connect))
            {
                cmdAjoutObjet.Parameters.AddWithValue("@Nom", nom);
                cmdAjoutObjet.Parameters.AddWithValue("@IdType", idType);
                cmdAjoutObjet.ExecuteNonQuery();
                Console.WriteLine("Objet ajouté à la base de données.");
            }

            // Ajouter la quantité dans la table Stock
            string ajoutStockQuery = "INSERT INTO Stock (id_entrepot, id_objet, quantity) " +
                                     "VALUES (@IdEntrepot, (SELECT id FROM Liste_objets WHERE name = @Nom), @Quantite)";

            using (MySqlCommand cmdAjoutStock = new MySqlCommand(ajoutStockQuery, connect))
            {
                cmdAjoutStock.Parameters.AddWithValue("@IdEntrepot", id);
                cmdAjoutStock.Parameters.AddWithValue("@Nom", nom);
                cmdAjoutStock.Parameters.AddWithValue("@Quantite", quantite);
                cmdAjoutStock.ExecuteNonQuery();
                Console.WriteLine("Quantité ajoutée à la table Stock.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
        }
    }



}