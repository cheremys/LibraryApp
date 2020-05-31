onmessage = function (e) {
    let result = workWithData(e.data);
    postMessage(result);
};

function workWithData(data) {

    let books = data[0].map(k => JSON.parse(k.value));

    let booksToDelete = [];
    let booksToCreate = [];

    for (let book of books) {

        if (book.status === "delete") {
            booksToDelete.push(book.title);
        }
        else if (book.status === "create") {
            booksToCreate.push(book);
        }
    }

    if (booksToCreate.length > 0) {
        fetch(data[1] + "/Home/CreateBook", {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            body: JSON.stringify(booksToCreate)
        }).then(function (response) {
            console.log(response);
        }).catch(function (error) {
            console.error(error);
        });
    }

    if (booksToDelete.length > 0) {

        fetch(data[1] +"/Home/DeleteBook", {
            method: "POST",
            headers: {
                "Content-Type": "application/json; charset=utf-8"
            },
            body: JSON.stringify(booksToDelete)
        }).then(function (response) {
            console.log(response);
        }).catch(function (error) {
            console.error(error);
        });
    }

    return data[0].map(k => k.key);
};