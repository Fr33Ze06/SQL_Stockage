package main

import (
	"database/sql"
	"fmt"
	"net/http"

	"github.com/gin-gonic/gin"
	_ "github.com/go-sql-driver/mysql"
)

var db *sql.DB
var err error

type Entrepot struct {
	ID            int    `json:"id"`
	Name          string `json:"name"`
	Cap_max       string `json:"cap_max"`
	Date_creation string `json:"date_creation"`
	ID_lieu       int    `json:"id_lieu"`
}

type Lieu struct {
	ID    int    `json:"id"`
	Pays  string `json:"title"`
	Ville string `json:"author"`
}

type Stock struct {
	ID_entrepot int `json:"id_entrepot"`
	ID_type     int `json:"id_type"`
	ID_objet    int `json:"id_objet"`
	Quantity    int `json:"quantity"`
}

type Liste_Objet struct {
	ID      int    `json:"id"`
	Name    string `json:"name"`
	Image   string `json:"image"`
	ID_type int    `json:"id_type"`
}

type Type struct {
	ID   int    `json:"id"`
	Type string `json:"type"`
}

func openBase() {
	//Ouvre la connexion à la base de données
	db, err = sql.Open("mysql", "root:@tcp(127.0.0.1:3306)/stockage")
	if err != nil {
		fmt.Println(err)
	}
}

func main() {
	router := gin.Default()
	// Démarre le serveur
	openBase()
	// Ouvre le Database

	router.Static("/static", "./static") // charge le css et le script js
	router.LoadHTMLGlob("tmpl/*.html")   // charge les pages HTML

	router.GET("/", func(c *gin.Context) {
		c.HTML(http.StatusOK, "page.html", gin.H{})
	})

	// router.GET("/Topics", func(c *gin.Context) {
	// 	c.JSON(http.StatusOK, gin.H{"Topics": ReadallTopics()})
	// })

	// router.GET("/Accueil", func(c *gin.Context) {
	// 	topics := ReadallTopics()
	// 	fmt.Println(topics)
	// 	c.HTML(http.StatusOK, "topics.html", gin.H{"Topics": topics, "logUser": logUser})
	// })

	// router.GET("/topic", func(c *gin.Context) {
	// 	topicID, err := strconv.Atoi(c.Query("id")) // récupère l'id du topic dans l'URL
	// 	if err != nil {
	// 		panic(err)
	// 	}

	// 	c.HTML(http.StatusOK, "infoTopic.html", gin.H{"topicInfo": Search_Topic_By_ID(topicID), "allPosts": ReadallPosts_By_ID_Topic(topicID)})
	// })

	//---------------------Réponse de l'API----------------------//

	// // Route POST pour l'inscription d'un utilisateur
	// router.POST("/API/inscription", func(c *gin.Context) {
	// 	fmt.Println("Début Inscription...")

	// 	recupUser := User{}

	// 	//Recuperation des données de la requête envoyé en méthode POST
	// 	pseudo := c.PostForm("pseudo")
	// 	mdp := c.PostForm("mdp")
	// 	email := c.PostForm("email")

	// 	//Assignation de la variable email de type string à sql.NullString.
	// 	if email == "" {
	// 		recupUser.Email = sql.NullString{String: "", Valid: false}
	// 	} else {
	// 		recupUser.Email = sql.NullString{String: email, Valid: true}
	// 	}

	// 	recupUser.Pseudo = pseudo
	// 	recupUser.Mdp = mdp

	// 	// Affichage du USER envoyé
	// 	fmt.Println("USER envoyé : ", recupUser)

	// 	//Test pour la redondance d'utilisateur du pseudo
	// 	allusers := ReadallUsers()
	// 	var IsPseudo string = "no"
	// 	for i := 0; i < len(allusers); i++ {
	// 		if allusers[i].Pseudo == recupUser.Pseudo {
	// 			fmt.Println("Not done: 'Pseudo' already use in DB")
	// 			IsPseudo = "yes"
	// 		}
	// 	}

	// 	//Test pour la redondance d'utilisateur de l'email
	// 	var IsEmail string = "no"
	// 	for i := 0; i < len(allusers); i++ {
	// 		if allusers[i].Email.Valid {
	// 			if allusers[i].Email.String == recupUser.Email.String {
	// 				fmt.Println("Not done: 'Email' already use in DB")
	// 				IsEmail = "yes"
	// 			}
	// 		}
	// 	}

	// 	if IsEmail == "yes" || IsPseudo == "yes" {
	// 		c.Redirect(http.StatusFound, "/?Pseudo="+IsPseudo+"&Email="+IsEmail)
	// 		return
	// 	}

	// 	// Génère un hash bcrypt du mot de passe (hachage aléatoire pour renforcer la sécurité)
	// 	hashed, err := bcrypt.GenerateFromPassword([]byte(recupUser.Mdp), 14)
	// 	if err != nil {
	// 		fmt.Println(err)
	// 		return
	// 	}

	// 	// Convertit le hash en chaîne hexadécimale pour faciliter le stockage
	// 	hashedMdp := string(hashed)

	// 	fmt.Println("Enregistrement...")
	// 	fmt.Println("Length hashed password : ", len(hashedMdp), " ( ", hashedMdp, " )")
	// 	// Enregistrement de l'utilisateur dans la base de données
	// 	// Exécute une requête INSERT INTO pour insérer des données dans la table "users"
	// 	_, err = db.Exec("INSERT INTO `users`(`pseudo`, `password`, `email`) VALUES (?,?,?)", recupUser.Pseudo, hashedMdp, recupUser.Email)
	// 	if err != nil {
	// 		panic(err.Error())
	// 	}

	// 	fmt.Println("Utilisateur inséré avec succès dans la table users.")
	// 	// Réponse de succès à l'utilisateur
	// 	logUser = Search_User_By_Pseudo(recupUser.Pseudo)

	// 	c.Redirect(http.StatusFound, "/catindex")
	// })

	// // Route POST pour la connexion d'un utilisateur
	// router.POST("/API/login", func(c *gin.Context) {
	// 	fmt.Println("Début Connexion...")

	// 	recupUser := User{}

	// 	//Recuperation des données de la requête envoyé en méthode POST
	// 	pseudo := c.PostForm("pseudo")
	// 	mdp := c.PostForm("mdp")

	// 	recupUser.Pseudo = pseudo
	// 	recupUser.Mdp = mdp

	// 	// Affichage du USER envoyé
	// 	fmt.Println("USER requête : ", recupUser)

	// 	//Test pour la redondance d'utilisateur du pseudo
	// 	allusers := ReadallUsers()
	// 	var Retry string = "no"
	// 	var foundUser User = User{}
	// 	var found bool = false
	// 	for i := 0; i < len(allusers); i++ {
	// 		if allusers[i].Pseudo == recupUser.Pseudo {
	// 			foundUser = allusers[i]
	// 			found = true
	// 			break
	// 		}
	// 	}
	// 	if found {
	// 		fmt.Println("'Pseudo': ", recupUser.Pseudo, " found in DB")
	// 		if !CheckPassword(recupUser.Mdp, foundUser.Mdp) {
	// 			Retry = "yes"
	// 			fmt.Println("but MDP not match")
	// 		}
	// 	} else {
	// 		fmt.Println("'Pseudo':", recupUser.Pseudo, "not found in DB")
	// 		Retry = "yes"
	// 	}

	// 	if Retry == "yes" {
	// 		c.Redirect(http.StatusFound, "/LogIn?Retry="+Retry)
	// 		return
	// 	}

	// 	fmt.Println("Connexion réussie")
	// 	// Réponse de succès à l'utilisateur
	// 	logUser = Search_User_By_Pseudo(recupUser.Pseudo)

	// 	fmt.Println(logUser)

	// 	c.Redirect(http.StatusFound, "/catindex")
	// })

	// // Route POST pour la connexion d'un utilisateur
	// router.POST("/API/Deco", func(c *gin.Context) {
	// 	fmt.Println("Début deconnexion...")

	// 	//Recuperation des données du logUser et on le clear

	// 	fmt.Println(logUser)
	// 	logUser = User{}

	// 	//Puis on renvoie l'utilisateur sur la page de connexion

	// 	fmt.Println("deconnexion réussie")
	// 	// Réponse de succès à l'utilisateur

	// 	c.Redirect(http.StatusFound, "/LogIn")
	// })

	// // Route POST pour la creation d'un nouveau topic
	// router.POST("/API/New_Topic", func(c *gin.Context) {
	// 	fmt.Println("Début Création Topic...")

	// 	//Recuperation des données de la requête envoyé en méthode POST
	// 	type NewTopic struct {
	// 		Author User
	// 		Titre  string
	// 		Post   string
	// 	}

	// 	recupNewTopic := NewTopic{}

	// 	recupNewTopic.Titre = c.PostForm("titre")
	// 	recupNewTopic.Post = c.PostForm("message")

	// 	_, err = db.Exec("INSERT INTO `topics`( `title`, `author`) VALUES (?,?)", recupNewTopic.Titre, logUser.Pseudo)
	// 	if err != nil {
	// 		panic(err.Error())
	// 	}
	// 	//On recupere l'id du topic juste créé
	// 	var id_new_topic int
	// 	rows, err := db.Query("SELECT id FROM topics ORDER BY id DESC LIMIT 1")
	// 	if err != nil {
	// 		panic(err.Error())
	// 	}
	// 	defer rows.Close()
	// 	for rows.Next() {
	// 		rows.Scan(&id_new_topic)
	// 	}

	// 	fmt.Println("ID User:", logUser.ID)

	// 	fmt.Println("ID New Topic: ", id_new_topic)

	// 	//On recupere les tags coché en tant que checkbox
	// 	tags_selected := c.PostFormArray("tag")
	// 	fmt.Println("Tags: ", tags_selected)

	// 	//Exécute une requête INSERT INTO pour que toutes les données du nouveau Topic dans toutes les tables necessitant ses informations

	// 	for i := 0; i < len(tags_selected); i++ {
	// 		_, err = db.Exec("INSERT INTO `topics_tags`( `id_topic`, `id_tag`) VALUES (?,?)", id_new_topic, Search_ID_Tag_By_TagName(tags_selected[i]))
	// 		if err != nil {
	// 			panic(err.Error())
	// 		}
	// 	}

	// 	_, err = db.Exec("INSERT INTO `posts`( `id_user`, `id_topic`, `content`) VALUES (?,?,?)", logUser.ID, id_new_topic, recupNewTopic.Post)
	// 	if err != nil {
	// 		panic(err.Error())
	// 	}

	// 	// Réponse de succès à l'utilisateur
	// 	fmt.Println("Terminée")

	// 	c.Redirect(http.StatusFound, "/catindex")
	// })

	// // Route POST pour la creation d'un nouveau topic
	// router.POST("/topic", func(c *gin.Context) {

	// 	topicID := c.Query("id") // récupère l'id du topic dans l'URL

	// 	TopicID, err := strconv.Atoi(topicID)
	// 	if err != nil {
	// 		panic(err)
	// 	}

	// 	MessageContent := c.PostForm("message")

	// 	fmt.Println("Début Création Post... TopicID: ", topicID, " UserID: ", logUser.ID, " Message:", MessageContent)

	// 	_, err = db.Exec("INSERT INTO `posts`( `id_user`, `id_topic`, `content`) VALUES (?,?,?)", logUser.ID, TopicID, MessageContent)
	// 	if err != nil {
	// 		panic(err.Error())
	// 	}

	// 	// Réponse de succès à l'utilisateur
	// 	fmt.Println("Post inséré dans la base de données")

	// 	c.Redirect(http.StatusFound, "/topic?id="+topicID)
	// })

	//---------------------------Fin API-------------------------//

	fmt.Println("All's good: Listening on ( http://localhost:8080/ )")

	router.Run(":8080") // Run du Serveur
}

//Fonction SCRIPT
