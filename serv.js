const express = require('express');
const mysql = require('mysql');
const path = require('path');
const app = express();
const port = 8080;

const dir = path.join(__dirname, '/');
app.use(express.static('static'));

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

/* Page JSON */

app.get('/JSON', (req, res) => {
    res.render('json');
});

app.get('/JSON/:jsonName', (req, res) => {
    // Exécutez la requête SQL
    const jsonName = req.params.jsonName;
    select_query = 'SELECT * FROM ??';

    connection.query(select_query, jsonName, (error, results, fields) => {
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

/* Routes */

app.get('/', (req, res) => {
    connection.query('SELECT entrepots.*, lieux.image AS lieux_image FROM entrepots JOIN lieux ON entrepots.id_lieu = lieux.id', (error, results) => {
        if (error) {
            console.error('Erreur lors de la récupération des entrepôts : ' + error.message);
            return;
        }
        res.render('accueil', { entrepots: results });
    });
});

app.get('/Entrepot/:id', (req, res) => {
    const id = req.params.id;
    
    // Récupérer les informations de l'entrepot
    connection.query(
        'SELECT entrepots.*, lieux.image AS lieux_image FROM entrepots JOIN lieux ON entrepots.id_lieu = lieux.id WHERE entrepots.id = ?',
        [id],
        (error, results) => {
            if (error) {
                console.error('Erreur lors de la récupération des informations de l\'entrepôt : ' + error.message);
                return;
            }
            
            // Récupérer les objets stockés dans l'entrepôt
            connection.query(
                'SELECT liste_objets.*, stock.quantity FROM stock ' +
                'LEFT JOIN liste_objets ON stock.id_objet = liste_objets.id ' +
                'WHERE stock.id_entrepot = ?',
                [id],
                (error, stockResults) => {
                    if (error) {
                        console.error('Erreur lors de la récupération des objets stockés : ' + error.message);
                        return;
                    }

                    var count_Q = 0;
                    stockResults.forEach(item => {
                        count_Q += item.quantity;
                    });

                    console.log(count_Q);
                    console.log(stockResults);
                    // Rendre la page 'entrepot.ejs'
                    res.render('entrepot', {entrepot_info: results[0], stock_info: stockResults, quantity_all: count_Q});
                }
            );
        }
    );
});



app.listen(port, () => {
    console.log(`Serveur Express: http://localhost:${port}`);
});