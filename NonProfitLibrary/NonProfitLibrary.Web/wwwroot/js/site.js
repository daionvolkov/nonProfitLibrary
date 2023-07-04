import { addBookToReader } from './functions/TakenBookFunc.js';
import { removeBookFromReader } from './functions/ReturnBookFunc.js';
import { addBookToOrder } from './functions/OrderBookFunc.js';





$(document).ready(function () {
    $('#search_btn').click(function () {
        var inputValue = $('#search_input').val(); 
        var radioValue = $("input[name='search_type']:checked").val();
        var url = 'http://localhost:5055/api/book/' + encodeURIComponent(inputValue) + '/' + radioValue;

        $.getJSON(url, function (data) {
            $('#table-container').empty();      
            $.each(data, function (index, object) {
                var card = $('<div>').addClass('card').addClass('card-show');;
                $('<h3>').addClass('book-title').text(object.title).appendTo(card);
                $('<p>').addClass('book-author').text('Автор: ' + object.author).appendTo(card);
                $('<p>').addClass('book-description').text('Описание: ' + object.description).appendTo(card);
                $('<p>').addClass('book-genre').text('Жанр: ' + object.genre).appendTo(card);
                $('<p>').addClass('book-type').text('Тип издания: ' + object.bookType).appendTo(card);
                if (object.isAvailable) {
                    $('<p>').addClass('book-isAvailible').text('В наличии').appendTo(card);
                }
                else {
                    $('<p>').addClass('book-isAvailible').text('На руках').appendTo(card);
                }

                if (object.readerId != null) {
                    $.getJSON('http://localhost:5055/api/reader/' + object.readerId, function (readerJson) {
                        var reader = $('.book-isAvailible').text('На руках у ' + readerJson.firstName + ' ' + readerJson.lastName).appendTo(card);
                        $('<button>').addClass('book-btn-return').text('Вернуть книгу').appendTo(card);
                        $('<button>').addClass('book-btn-order').text('Заказать книгу').appendTo(card);
                        $(document).ready(function () {
                            $('.book-btn-return').click(function () {
                                removeBookFromReader(object);
                            });
                            $('.book-btn-order').click(function () {
                                addBookToOrder(object);
                            });
                        });

                    });
                }
                else {
                    $('<button>').addClass('book-btn-take').text('Взять книгу').appendTo(card);

                    $(document).ready(function () {
                        $('.book-btn-take').click(function () {
                            addBookToReader(object);
                        });
                    });
                }
                $('#table-container').append(card);
            });           
        });
    });
});


$(document).ready(function () {
    $('.book-btn-take').click(function () {
        addBookToReader(object);
    });
});

