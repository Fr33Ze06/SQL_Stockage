const express = require('express');
const path = require('path');
const app = express();
const port = 8000; // Port sur lequel le serveur écoutera

const dir = path.join(__dirname, '/');
app.use(express.static('static'));

app.get('/', (req, res) => {
    res.sendFile(path.join(dir, 'tmpl/page.html'));
});

app.get('/JSON', (req, res) => {
    res.sendFile(path.join(dir, 'tmpl/json.html'));
});











app.listen(port, () => {
    console.log(`Serveur Express: http://localhost:${port}`);
});