const btnDbSave = document.getElementById("btn-db-save");
btnDbSave.addEventListener('click', () => {
    fetch('home/DbSave', {
        method: 'POST'
    })
        .then((response) => response.json())
        .then((data) => {
            alert("Success")
            console.log(data);
        })
        .catch((error) => {
            alert("Error")
            console.log(error);
        });
})