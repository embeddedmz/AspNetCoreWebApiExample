var url = "http://localhost:5459/Salles?Size=3";

var sallesList = document.getElementById("list-salles");
if (sallesList) {
    fetch(url)
        .then(response => response.json())
        .then(data => showSalles(data))
        .catch(ex => {
            alert("Oops... !");
            console.log(ex);
        });
}

function showSalles(salles) {
    salles.forEach(salle => {
        let li = document.createElement("li");
        let text = `${salle.libelle} : Identifiant ${salle.id} - ${salle.nombre_De_Places} places.`;
        li.appendChild(document.createTextNode(text));
        sallesList.appendChild(li);
    })
}