import { getReaderById } from './TakenBookFunc.js';


export function removeBookFromReader(object) {
    $("#dialog").show();
    $("#saveButton").click(function () {

        var email = $("#email").val();
        $.get("http://localhost:5055/api/reader/" + email + "/email", function (response) {
            if (response != null) {
                removeBookFromTaken(response.id, object);
            }
        });
    });

    function removeBookFromTaken(readerId, object) {
        var url = 'http://localhost:5055/api/reader/' + readerId + '/takenBooks/remove';
        var addList = [];
        addList.push(object.id);

        $.ajax({
            url: url,
            type: "PATCH",
            data: JSON.stringify(addList),
            contentType: "application/json",
            success: function (data, status) {
                $(document).ready(function () {
                    getReaderById(readerId).done(function (data) {
                        var firstName = data.firstName;
                        var lastName = data.lastName;
                        alert('Читатель ' + firstName + ' ' + lastName + ' вернул книгу')
                    });
                });
            }
        });

    }
}