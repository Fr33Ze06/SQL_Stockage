package main

import (
	"database/sql"
	"fmt"
	"net/http"
	"sort"
	"strconv"
	"time"

	"github.com/gin-gonic/gin"
	_ "github.com/go-sql-driver/mysql"
)

var db *sql.DB
var err error

type User struct {
	ID     int            `json:"id"`
	Pseudo string         `json:"pseudo"`
	Mdp    string         `json:"password"`
	Email  sql.NullString `json:"email"`
}

type Topic struct {
	ID         int      `json:"id"`
	Title      string   `json:"title"`
	Author     string   `json:"author"`
	TagName    []string `json:"tag_name"`
	UpdateDate string   `json:"creation_date"`
}

type Tag struct {
	ID       int    `json:"id"`
	Tag_name string `json:"tag_name"`
}

type Post struct {
	ID         int    `json:"id"`
	Author     User   `json:"id_user"`
	ID_topic   int    `json:"id_topic"`
	Content    string `json:"content"`
	UpdateDate string `json:"creation_date"`
}

func ReadallUsers() []User {
	//requête sur la table User
	var allUser []User
	rows, err := db.Query("SELECT *FROM Users  ")
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	// Parcourt les lignes retournées
	for rows.Next() {
		recupUser := User{}
		err = rows.Scan(&recupUser.ID, &recupUser.Pseudo, &recupUser.Mdp, &recupUser.Email)
		if err != nil {
			panic(err.Error())
		}
		allUser = append(allUser, recupUser) //ajoute les données des artistes dans le tableau allArtist

	}
	return allUser
}

func ReadallTopics() []Topic {

	//requête sur la table Topic
	var allTopic []Topic
	rows, err := db.Query("SELECT tp.id, tp.title, tp.author, ta.tag_name, p.creation_date FROM tags ta INNER JOIN topics_tags tt ON tt.id_tag = ta.id INNER JOIN topics tp ON tp.id = tt.id_topic JOIN posts p ON p.id_topic = tp.id WHERE p.creation_date = ( SELECT MAX(p2.creation_date) FROM posts p2 WHERE p2.id_topic = p.id_topic)  ")
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	// Parcourt les lignes retournées
	for rows.Next() {
		recupTopic := Topic{}
		var Tag_Topic string
		err = rows.Scan(&recupTopic.ID, &recupTopic.Title, &recupTopic.Author, &Tag_Topic, &recupTopic.UpdateDate)
		recupTopic.TagName = append(recupTopic.TagName, Tag_Topic)
		if err != nil {
			panic(err.Error())
		}

		conca := false
		for i := 0; i < len(allTopic); i++ {
			if allTopic[i].ID == recupTopic.ID {
				allTopic[i].TagName = append(allTopic[i].TagName, Tag_Topic)
				conca = true
			}
		}
		if !conca {
			allTopic = append(allTopic, recupTopic) //ajoute les données des artistes dans le tableau allArtist
		}

	}
	type TopicTime struct {
		ID         int       `json:"id"`
		Title      string    `json:"title"`
		Author     string    `json:"author"`
		TagName    []string  `json:"tag_name"`
		UpdateDate time.Time `json:"creation_date"`
	}

	// Créer une nouvelle liste de topics
	sortedTopics := make([]TopicTime, len(allTopic))
	// Parcourir les topics et les convertir en format time.Time
	for i, topic := range allTopic {
		date, _ := time.Parse("2006-01-02 15:04:05", topic.UpdateDate)
		topicTime := TopicTime{}
		topicTime.ID = topic.ID
		topicTime.Title = topic.Title
		topicTime.Author = topic.Author
		topicTime.TagName = topic.TagName
		topicTime.UpdateDate = date
		sortedTopics[i] = topicTime
	}

	// Trier la liste de topics selon la date
	sort.Slice(sortedTopics, func(i, j int) bool {
		return sortedTopics[i].UpdateDate.After(sortedTopics[j].UpdateDate)
	})

	allTopic = make([]Topic, len(allTopic))
	for i, topic := range sortedTopics {
		date := topic.UpdateDate.Format("2006-01-02 15:04:05")
		Topic := Topic{}
		Topic.ID = topic.ID
		Topic.Title = topic.Title
		Topic.Author = topic.Author
		Topic.TagName = topic.TagName
		Topic.UpdateDate = date
		allTopic[i] = Topic
	}

	return allTopic
}

func ReadallTags() []Tag {
	//requête sur la table Tags
	var allTag []Tag
	rows, err := db.Query("SELECT ta.id, ta.tag_name FROM tags ta")
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	// Parcourt les lignes retournées
	for rows.Next() {
		recupTag := Tag{}
		err = rows.Scan(&recupTag.ID, &recupTag.Tag_name)
		if err != nil {
			panic(err.Error())
		}
		allTag = append(allTag, recupTag) //ajoute les données des artistes dans le tableau allArtist

	}
	return allTag
}

func ReadallPosts_By_ID_Topic(id int) []Post {
	rows, err := db.Query("SELECT * FROM posts WHERE id_topic=(?);", id)
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	// Parcourt les lignes retournées

	var allPosts []Post

	for rows.Next() {
		recupPost := Post{}
		id_author := -1
		err = rows.Scan(&recupPost.ID, &id_author, &recupPost.ID_topic, &recupPost.Content, &recupPost.UpdateDate)
		if err != nil {
			panic(err.Error())
		}
		recupPost.Author = Search_User_By_ID(id_author)
		allPosts = append(allPosts, recupPost) //ajoute les données des artistes dans le tableau allArtist

	}
	return allPosts
}

func Search_User_By_Pseudo(pseudo string) User {
	//requête sur la table users d'un pseudo donné
	rows, err := db.Query("SELECT * FROM users WHERE pseudo=(?);", pseudo)
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	recupUser := User{}
	for rows.Next() {
		err = rows.Scan(&recupUser.ID, &recupUser.Pseudo, &recupUser.Mdp, &recupUser.Email)
		if err != nil {
			panic(err.Error())
		}
	}
	return recupUser
}

func Search_User_By_ID(id int) User {
	//requête sur la table users d'un pseudo donné
	rows, err := db.Query("SELECT * FROM users WHERE id=(?);", id)
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	recupUser := User{}
	for rows.Next() {
		err = rows.Scan(&recupUser.ID, &recupUser.Pseudo, &recupUser.Mdp, &recupUser.Email)
		if err != nil {
			panic(err.Error())
		}
	}
	return recupUser
}

func Search_ID_Tag_By_TagName(tagname string) int {
	rows, err := db.Query("SELECT id FROM tags WHERE tag_name=(?);", tagname)
	if err != nil {
		panic(err.Error())
	}
	defer rows.Close()
	var id_tag int
	for rows.Next() {
		err = rows.Scan(&id_tag)
		if err != nil {
			panic(err.Error())
		}
	}
	return id_tag
}

func Search_Topic_By_ID(id int) Topic {
	topics := ReadallTopics()
	for i := 0; i < len(topics); i++ {
		if topics[i].ID == id {
			return topics[i]
		}
	}
	return Topic{}
}

func openBase() {
	//Ouvre la connexion à la base de données
	db, err = sql.Open("mysql", "root:@tcp(127.0.0.1:3306)/forum")
	if err != nil {
		fmt.Println(err)
	}
}

var logUser User

func main() {
	router := gin.Default()
	// Démarre le serveur
	openBase()
	// Ouvre le Database

	router.Static("/static", "./static") // charge le css et le script js
	router.LoadHTMLGlob("tmpl/*.html")   // charge les pages HTML

	router.GET("/", func(c *gin.Context) {
		c.HTML(http.StatusOK, "inscription.html", gin.H{})
	})

	router.GET("/Topics", func(c *gin.Context) {
		c.JSON(http.StatusOK, gin.H{"Topics": ReadallTopics()})
	})

	router.GET("/LogIn", func(c *gin.Context) {
		c.HTML(http.StatusOK, "login.html", gin.H{})
	})

	router.GET("/Accueil", func(c *gin.Context) {
		topics := ReadallTopics()
		fmt.Println(topics)
		c.HTML(http.StatusOK, "topics.html", gin.H{"Topics": topics, "logUser": logUser})
	})

	router.GET("/New_Topic", func(c *gin.Context) {
		tags := ReadallTags()
		c.HTML(http.StatusOK, "creationtopic.html", gin.H{"Tags": tags, "logUser": logUser})
	})

	router.GET("/topic", func(c *gin.Context) {
		topicID, err := strconv.Atoi(c.Query("id")) // récupère l'id du topic dans l'URL
		if err != nil {
			panic(err)
		}

		c.HTML(http.StatusOK, "infoTopic.html", gin.H{"topicInfo": Search_Topic_By_ID(topicID), "allPosts": ReadallPosts_By_ID_Topic(topicID)})
	})

	router.GET("/catindex", func(c *gin.Context) {
		topics := ReadallTopics()
		c.HTML(http.StatusOK, "catindex.html", gin.H{"Topics": topics, "logUser": logUser})
	})

	//---------------------Réponse de l'API----------------------//

	// Route POST pour l'inscription d'un utilisateur
	router.POST("/API/inscription", func(c *gin.Context) {
		fmt.Println("Début Inscription...")

		recupUser := User{}

		//Recuperation des données de la requête envoyé en méthode POST
		pseudo := c.PostForm("pseudo")
		mdp := c.PostForm("mdp")
		email := c.PostForm("email")

		//Assignation de la variable email de type string à sql.NullString.
		if email == "" {
			recupUser.Email = sql.NullString{String: "", Valid: false}
		} else {
			recupUser.Email = sql.NullString{String: email, Valid: true}
		}

		recupUser.Pseudo = pseudo
		recupUser.Mdp = mdp

		// Affichage du USER envoyé
		fmt.Println("USER envoyé : ", recupUser)

		//Test pour la redondance d'utilisateur du pseudo
		allusers := ReadallUsers()
		var IsPseudo string = "no"
		for i := 0; i < len(allusers); i++ {
			if allusers[i].Pseudo == recupUser.Pseudo {
				fmt.Println("Not done: 'Pseudo' already use in DB")
				IsPseudo = "yes"
			}
		}

		//Test pour la redondance d'utilisateur de l'email
		var IsEmail string = "no"
		for i := 0; i < len(allusers); i++ {
			if allusers[i].Email.Valid {
				if allusers[i].Email.String == recupUser.Email.String {
					fmt.Println("Not done: 'Email' already use in DB")
					IsEmail = "yes"
				}
			}
		}

		if IsEmail == "yes" || IsPseudo == "yes" {
			c.Redirect(http.StatusFound, "/?Pseudo="+IsPseudo+"&Email="+IsEmail)
			return
		}

		// Génère un hash bcrypt du mot de passe (hachage aléatoire pour renforcer la sécurité)
		hashed, err := bcrypt.GenerateFromPassword([]byte(recupUser.Mdp), 14)
		if err != nil {
			fmt.Println(err)
			return
		}

		// Convertit le hash en chaîne hexadécimale pour faciliter le stockage
		hashedMdp := string(hashed)

		fmt.Println("Enregistrement...")
		fmt.Println("Length hashed password : ", len(hashedMdp), " ( ", hashedMdp, " )")
		// Enregistrement de l'utilisateur dans la base de données
		// Exécute une requête INSERT INTO pour insérer des données dans la table "users"
		_, err = db.Exec("INSERT INTO `users`(`pseudo`, `password`, `email`) VALUES (?,?,?)", recupUser.Pseudo, hashedMdp, recupUser.Email)
		if err != nil {
			panic(err.Error())
		}

		fmt.Println("Utilisateur inséré avec succès dans la table users.")
		// Réponse de succès à l'utilisateur
		logUser = Search_User_By_Pseudo(recupUser.Pseudo)

		c.Redirect(http.StatusFound, "/catindex")
	})

	// Route POST pour la connexion d'un utilisateur
	router.POST("/API/login", func(c *gin.Context) {
		fmt.Println("Début Connexion...")

		recupUser := User{}

		//Recuperation des données de la requête envoyé en méthode POST
		pseudo := c.PostForm("pseudo")
		mdp := c.PostForm("mdp")

		recupUser.Pseudo = pseudo
		recupUser.Mdp = mdp

		// Affichage du USER envoyé
		fmt.Println("USER requête : ", recupUser)

		//Test pour la redondance d'utilisateur du pseudo
		allusers := ReadallUsers()
		var Retry string = "no"
		var foundUser User = User{}
		var found bool = false
		for i := 0; i < len(allusers); i++ {
			if allusers[i].Pseudo == recupUser.Pseudo {
				foundUser = allusers[i]
				found = true
				break
			}
		}
		if found {
			fmt.Println("'Pseudo': ", recupUser.Pseudo, " found in DB")
			if !CheckPassword(recupUser.Mdp, foundUser.Mdp) {
				Retry = "yes"
				fmt.Println("but MDP not match")
			}
		} else {
			fmt.Println("'Pseudo':", recupUser.Pseudo, "not found in DB")
			Retry = "yes"
		}

		if Retry == "yes" {
			c.Redirect(http.StatusFound, "/LogIn?Retry="+Retry)
			return
		}

		fmt.Println("Connexion réussie")
		// Réponse de succès à l'utilisateur
		logUser = Search_User_By_Pseudo(recupUser.Pseudo)

		fmt.Println(logUser)

		c.Redirect(http.StatusFound, "/catindex")
	})

	// Route POST pour la connexion d'un utilisateur
	router.POST("/API/Deco", func(c *gin.Context) {
		fmt.Println("Début deconnexion...")

		//Recuperation des données du logUser et on le clear

		fmt.Println(logUser)
		logUser = User{}

		//Puis on renvoie l'utilisateur sur la page de connexion

		fmt.Println("deconnexion réussie")
		// Réponse de succès à l'utilisateur

		c.Redirect(http.StatusFound, "/LogIn")
	})

	// Route POST pour la creation d'un nouveau topic
	router.POST("/API/New_Topic", func(c *gin.Context) {
		fmt.Println("Début Création Topic...")

		//Recuperation des données de la requête envoyé en méthode POST
		type NewTopic struct {
			Author User
			Titre  string
			Post   string
		}

		recupNewTopic := NewTopic{}

		recupNewTopic.Titre = c.PostForm("titre")
		recupNewTopic.Post = c.PostForm("message")

		_, err = db.Exec("INSERT INTO `topics`( `title`, `author`) VALUES (?,?)", recupNewTopic.Titre, logUser.Pseudo)
		if err != nil {
			panic(err.Error())
		}
		//On recupere l'id du topic juste créé
		var id_new_topic int
		rows, err := db.Query("SELECT id FROM topics ORDER BY id DESC LIMIT 1")
		if err != nil {
			panic(err.Error())
		}
		defer rows.Close()
		for rows.Next() {
			rows.Scan(&id_new_topic)
		}

		fmt.Println("ID User:", logUser.ID)

		fmt.Println("ID New Topic: ", id_new_topic)

		//On recupere les tags coché en tant que checkbox
		tags_selected := c.PostFormArray("tag")
		fmt.Println("Tags: ", tags_selected)

		//Exécute une requête INSERT INTO pour que toutes les données du nouveau Topic dans toutes les tables necessitant ses informations

		for i := 0; i < len(tags_selected); i++ {
			_, err = db.Exec("INSERT INTO `topics_tags`( `id_topic`, `id_tag`) VALUES (?,?)", id_new_topic, Search_ID_Tag_By_TagName(tags_selected[i]))
			if err != nil {
				panic(err.Error())
			}
		}

		_, err = db.Exec("INSERT INTO `posts`( `id_user`, `id_topic`, `content`) VALUES (?,?,?)", logUser.ID, id_new_topic, recupNewTopic.Post)
		if err != nil {
			panic(err.Error())
		}

		// Réponse de succès à l'utilisateur
		fmt.Println("Terminée")

		c.Redirect(http.StatusFound, "/catindex")
	})

	// Route POST pour la creation d'un nouveau topic
	router.POST("/topic", func(c *gin.Context) {

		topicID := c.Query("id") // récupère l'id du topic dans l'URL

		TopicID, err := strconv.Atoi(topicID)
		if err != nil {
			panic(err)
		}

		MessageContent := c.PostForm("message")

		fmt.Println("Début Création Post... TopicID: ", topicID, " UserID: ", logUser.ID, " Message:", MessageContent)

		_, err = db.Exec("INSERT INTO `posts`( `id_user`, `id_topic`, `content`) VALUES (?,?,?)", logUser.ID, TopicID, MessageContent)
		if err != nil {
			panic(err.Error())
		}

		// Réponse de succès à l'utilisateur
		fmt.Println("Post inséré dans la base de données")

		c.Redirect(http.StatusFound, "/topic?id="+topicID)
	})

	//---------------------------Fin API-------------------------//

	fmt.Println("All's good: Listening on ( http://localhost:8000/ )")

	router.Run(":8000") // Run du Serveur
}

//Fonction SCRIPT

// CheckPassword compare un mot de passe en clair avec un hash bcrypt donné
func CheckPassword(password string, hashedPassword string) bool {
	err := bcrypt.CompareHashAndPassword([]byte(hashedPassword), []byte(password))
	return err == nil
}
