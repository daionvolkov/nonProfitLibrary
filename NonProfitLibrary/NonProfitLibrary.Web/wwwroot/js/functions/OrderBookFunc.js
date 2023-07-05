import { getReaderById } from './TakenBookFunc.js';


export function addBookToOrder(object) {
    $("#dialog").show();
    $("#saveButton").click(function () {

        var email = $("#email").val();
        $.get("http://localhost:5055/api/reader/" + email + "/email", function (response) {
            if (response != null) {

                var jsonData = {

                    "ReaderId": response.id,
                    "Status": 1
                }


                addBookToReaderOrder(response.id, jsonData);
            }
        });




    });
}

function addBookToReaderOrder(readerId, jsonData) {
    $.ajax({
        url: 'http://localhost:5055/api/order/',
        type: 'POST',
        crossDomain: true,
        contentType: 'application/json',
        processData: false,
        data: JSON.stringify(jsonData),
        success: function (data) {
            getReaderById(readerId).done(function (data) {
                var firstName = data.firstName;
                var lastName = data.lastName;
                alert('Читатель ' + firstName + ' ' + lastName + ' заказал книгу')
            });

            alert('Order added successfully:');
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error('Error: Failed to add the order.' + textStatus + errorThrown);
        }
    });
}