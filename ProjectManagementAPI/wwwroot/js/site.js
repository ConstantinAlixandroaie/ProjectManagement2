const uri = 'api/Clients';
let clients = [];

fetch(uri)
    .then(function (response) {
        return response.json();
    })
    .then(function (clients) {
        var totalColumns = Object.keys(clients[0]).length;
        var columnNames = [];
        columnNames = Object.keys(clients[0]);

        //Create a HTML Table element.
        var table = document.createElement("TABLE");
        table.border = "1";

        //Add the header row.
        var row = table.insertRow(-1);
        for (var i = 0; i < totalColumns; i++) {
            var headerCell = document.createElement("TH");
            headerCell.innerHTML = columnNames[i];
            row.appendChild(headerCell);
        }

        // Add the data rows.
        for (var i = 0; i < clients.length; i++) {
            row = table.insertRow(-1);
            columnNames.forEach(function (columnName) {
                var cell = row.insertCell(-1);
                cell.innerHTML = clients[i][columnName];
            });
        }

        var dvTable = document.getElementById("Clients");
        dvTable.innerHTML = "";
        dvTable.appendChild(table);
    })
    .catch(function (error) {
        console.log("Error: " + error);
    });