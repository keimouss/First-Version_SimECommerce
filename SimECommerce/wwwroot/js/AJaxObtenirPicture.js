function GetPictures(idPicture) {

   

    $.ajax({
        type: 'Get',
        dataType: 'html',
        url: '/ImageProducts/ViewImage/' + idPicture,
        async: true,
        cache: true,
        contentType: "image/jpeg"

    })
        .done(function (result, testStatus, request) {

            //console.log("Identifiant " + idPicture);
            //console.log(request.getResponseHeader('Content-Type'));

            var mypicture = $("#img-thumb-" + idPicture);
            mypicture.attr("src", "ImageProducts/ViewImage/" + idPicture);

            console.log(testStatus);

        }).fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - '
                + xhr.statusText + ' - ' + xhr.responseText);
        });

};