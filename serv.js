const express = require('express');
const app = express();
const port = 8080; // Port sur lequel le serveur écoutera

app.get('/', (req,res) => {
    res.redirect('./tmpl/page.html');
});













app.listen(port, () => {
    console.log(`Serveur Express: http://localhost:${port}`);
});