
$(document).ready(function () {
    $('#search_btn').click(function () {
        var inputValue = $('#search_input').val(); 

        var radioValue = $("input[name='search_type']:checked").val();
        
        var url = 'http://localhost:5055/api/book/' + encodeURIComponent(inputValue) + '/' + radioValue;

        
        $.getJSON(url, function (data) {
            $('#table-container').empty();      
            $.each(data, function (index, object) {
        
                var card = $('<div>').addClass('card');
                var title = $('<h3>').text(object.title);
                var author = $('<p>').text('Автор: ' + object.author);
                var description = $('<p>').text('Описание: ' + object.description);
                var genre = $('<p>').text('Жанр: ' + object.genre);
                var bookType = $('<p>').text('Тип издания: ' + object.bookType);
               

                if (object.isAvailable) {
                    var isAvailable = $('<p>').text('В наличии');
                }
                else {
                    var isAvailable = $('<p>').text('На руках');
                }
                if (object.readerId != null) {
                    $.getJSON('http://localhost:5055/api/reader/' + object.readerId, function (readerJson) {
                        var reader = $('<p>').text('На руках у ' + readerJson.firstName + ' ' + readerJson.lastName);
                        card.append(reader);
                    });
                }
                


           
                card.append(title, author, description, genre, bookType, isAvailable);

                $('#table-container').append(card);
            });
        });
    });
});


