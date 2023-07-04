
$(document).ready(function () {
    $('#addBookSaveBtn').click(function () {

        var title = $('#titleInput').val();
        var author = $('#authorInput').val();
        var description = $('#descriptionInput').val();
        var genre = $('#genreInput').val();
        var bookType = $('#bookTypeInput').val();
        var isAvailable = true;




        const url = 'http://localhost:5055/api/book';

        var jsonData = {
            "Title": title,
            "Author": author,
            "Description": description,
            "Genre": genre,
            "BookType": bookType,
            "IsAvailable": isAvailable
        };

        addBook(jsonData);
    });
});

function addBook(jsonData) {
    $.ajax({
        url: 'http://localhost:5055/api/book',
        type: 'POST',
        crossDomain: true,
        contentType: 'application/json',
        processData: false,
        data: JSON.stringify(jsonData),
        success: function (data) {
            alert('Book added successfully:' + jsonData.title);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error: Failed to add the book.' + textStatus + errorThrown);
        }
    });
}