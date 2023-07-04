
export function addBookToReader(object) {
    $("#dialog").show();
    $("#saveButton").click(function () {

        var email = $("#email").val();
        $.get("http://localhost:5055/api/reader/" + email + "/email", function (response) {
            if (response != null) {
                addBookToReaderAsTaken(response.id, object)
            }
        });
    });
}

function addBookToReaderAsTaken(readerId, object) {
    var url = 'http://localhost:5055/api/reader/' + readerId + '/takenbooks';
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
                    alert('Читатель ' + firstName + ' ' + lastName + ' взял эту книгу')
                });
            });
        }
    });
        
}

export function getReaderById(id) {
    return $.getJSON("http://localhost:5055/api/reader/" + id);
}

 
