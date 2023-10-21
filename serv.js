const express = require('express');
const mysql = require('mysql');
const path = require('path');
const app = express();
const port = 8080;

/* Base de données SQL*/

const dbConfig = {
    host: 'localhost',
    user: 'votre_utilisateur',
    password: 'votre_mot_de_passe',
    database: 'votre_base_de_donnees'
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
    res.sendFile(path.join(dir, 'tmpl/page.html'));
});

/* Page JSON */

app.get('/JSON', (req, res) => {
    res.sendFile(path.join(dir, 'tmpl/json.html'));
});

app.get('/JSON', (req, res) => {
    res.sendFile(path.join(dir, 'tmpl/json.html'));
});











app.listen(port, () => {
    console.log(`Serveur Express: http://localhost:${port}`);
});