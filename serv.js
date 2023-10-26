const express = require('express');
const mysql = require('mysql');
const path = require('path');
const app = express();
const port = 8080;

/* EJS */ 

app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));

/* Base de données SQL*/

const dbConfig = {
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'stockage'
};

const connection = mysql.createConnection(dbConfig);

connection.connect((err) => {
    if (err) {
      console.error('Erreur de connexion à la base de données : ' + err.message);
    } else {
      console.log('Connecté à la base de données MySQL');
    }
});

/* Routes */

const dir = path.join(__dirname, '/');
app.use(express.static('static'));

app.get('/', (req, res) => {
    connection.query('SELECT entrepots.*, lieux.image AS lieux_image FROM entrepots JOIN lieux ON entrepots.id_lieu = lieux.id', (error, results) => {
        if (error) {
            console.error('Erreur lors de la récupération des entrepôts : ' + error.message);
            return;
        }
        
        res.render('accueil', { entrepots: results });
    });
});



/* Page JSON */

app.get('/JSON', (req, res) => {
    res.sendFile(path.join(dir, 'tmpl/json.html'));
});

app.get('/JSON/:jsonName', (req, res) => {
    // Exécutez la requête SQL
    const jsonName = req.params.jsonName;
    select_query = 'SELECT * FROM ??';
    tableName = jsonName;

    connection.query(select_query, tableName, (error, results, fields) => {
        if (error) {
            console.error('Erreur lors de l\'exécution de la requête : ' + error.message);
            return;
        }

        const jsonResponse = {
            title: `Table de ${jsonName}`,
            data: results
          };
        // Renvoie JSON
        res.json(jsonResponse);
    });
});











app.listen(port, () => {
    console.log(`Serveur Express: http://localhost:${port}`);
});