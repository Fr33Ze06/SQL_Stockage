document.addEventListener("DOMContentLoaded", function() {
    var fleche = document.getElementById('fleche');
    var rotation = 0;

    fleche.onclick = function () {
        rotation += 180; // Pour une rotation de 90 degrés à chaque clic
        fleche.style.transform = `rotate(${rotation}deg)`; // Utilisation des backticks (`) pour interpoler la chaîne
    }
});