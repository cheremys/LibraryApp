$(document).ready(function () {

    $("#booksContent :button").on("click", function (event) {
        buttonClik(event);
    });

    synchronizeData();
});

const status = {
    create: "create",
    delete: "delete"
}

function buttonClik(event) {
  
    let recipient = event.target.getAttribute('data-whatever');

    if (recipient === "deleteBook") {

        let title = event.target.getAttribute("data-title");
        deleteBook(title);
    }
    else if (recipient === "addBook") {
        addBook();
    };
};

function deleteBook(title) {
    $("#deleteBookModalText").empty().append(title);
    let modal = $("#deleteBookModal").modal();

    $("#deleteBookButton").on("click", function (event) {

        let deletedBook = { title: title, status: status.delete };
        try {
            window.localStorage.setItem(title, JSON.stringify(deletedBook));
            $("div[data-bookid='" + title + "']").remove();
        } catch (e) {
            console.error(e);
        }
        modal.modal('hide');
    });
};

function addBook() {
    let modal = $("#createBookModal").modal();

    let book = {};

    $("#createBookForm").submit(function (event) {

        var inputs = $(this).serializeArray();

        $.each(inputs, function (i, input) {
            book[input.name] = input.value;
        });

        book.status = status.create;

        try {
            window.localStorage.setItem(book.title, JSON.stringify(book));

            const container = $("#category" + book.categoryId);
            container.append($(".bookTemplate").html());

            const bookTemplate = container.find(".bookEmpty");
            bookTemplate.attr("data-bookid", book.title); 
            bookTemplate.removeClass("bookEmpty");
            bookTemplate.find(".card-header h5").append(book.title);
            bookTemplate.find(".card-title").append(book.autthor);
            bookTemplate.find(".card-text").append(book.description);
            bookTemplate.find(".card-footer").append(book.publicationDate);
            let button = bookTemplate.find("button");
            button.attr("data-title", book.title);
            button.on("click", function (event) {
                buttonClik(event);
            });
        } catch (e) {
            console.error(e);
        }

        event.preventDefault();
        modal.modal('hide');
    });
}

function synchronizeData() {
    let worker = new Worker("../Scripts/AppScripts/worker.js");

    worker.onmessage = function (e) {
        console.log('Message received from worker' + e.data);
        e.data.map(k => localStorage.removeItem(k));
    }
    
    setInterval(() => {
        let data = [];
        let keys = Object.keys(localStorage);
        if (keys.length > 0) {
            for (let k of Object.keys(localStorage)) {
                data.push({ key: k, value: localStorage.getItem(k) });
            }
            worker.postMessage([data, location.origin]);
        }
    }, 10000);
};