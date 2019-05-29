// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

///*Sur hover et click  des éléments du head-menu Categories*//
$(".ui-btns").hover(
    function (data) {
        var idparentcateg = data.currentTarget.dataset.idparentcategorie;
        var togdiv = $('#dropdown-' + idparentcateg);
        //var mondiv = $(data.currentTarget).children(".table-hover")[0];
        var mondiv = togdiv.children(".table-hover")[0];
        $.ajax({
            type: "GET",
            dataType: 'html',
            url: "https://localhost:44329/Catalog/GetCategorie/" + idparentcateg,
            async: true,
            contentType: "application/x-www-form-urlencoded",
            success: (msg) => {
                $(togdiv).empty();
                if ($(msg).length > 0) {
                    $(togdiv).append(msg);
                    //$(mondiv).append(msg);
                    //console.log(togdiv);
                }
            },
            error:
                (error) => {
                    console.log("error", error);
                }
        });

        $('#dropdown-' + idparentcateg).show();

    },
    function (data) {
        var idparentcateg = data.currentTarget.dataset.idparentcategorie;
        $('#dropdown-' + idparentcateg).hide();
    });

$('.ui-btns').click(function (data) {
    var idparentcateg = data.currentTarget.dataset.idparentcategorie;
    $.ajax({
        type: "GET",
        dataType: 'html',
        url: "https://localhost:44329/Catalog/GetCategorie2/" + idparentcateg,
        async: true,
        contentType: "application/x-www-form-urlencoded",
        success: (msg) => {
            $('#affichageProduct').empty();
            if ($(msg).length > 0) {
                $('#affichageProduct').append(msg);
                //$(mondiv).append(msg);
                //console.log(togdiv);
            }
        },
        error:
            (error) => {
                console.log("error", error);
            }
    });
    //console.log(idparentcateg);
});
///**********************************************//

///*Sur click des élements du dropdownlist du head-menu:Categories*/
//$(".ui-btn").click(function (data) {
//    // console.log(data);
//    var idcateg = data.currentTarget.dataset.idcategorie;

//    $.ajax({
//        type: "GET",
//        dataType: 'html',
//        url: "https://localhost:44329/Catalog/Products/" + idcateg,
//        async: true,
//        contentType: "application/x-www-form-urlencoded",
//        success: (msg) => {
//            // console.log(msg);
//            var $affichproducts = $("#affichageProduct");
//            $affichproducts.empty();
//            $affichproducts.append(msg);
//        },
//        error:
//            (error) => {
//                console.log("error", error);
//                console.log(idcateg);
//            }
//    });

//});
//******************************************************************//

//*Affichage du contenu du panier sur l'entré et sortie de la sourie*/
    $("#viewlepanier").mouseenter(function () {

        //console.log("Opened")
        //$("#flyout-panier").attr("hidden", false);
        $('.modal').modal('show');
    })
        .mouseleave(function () {
            $('.modal').modal('hide');
            //$("#flyout-panier").attr("hidden", true);
        });
//***********************//

    //$("#viewlepanier").click(function (data) {

    //    console.log(data);
    //    $.ajax({
    //        type: "Get",
    //        dataType: 'text',
    //        url: "https://localhost:44329/Catalog/LePanier",
    //        async: true,
    //        contentType: "application/json",
    //        success: (msg) => {
    //            console.log(msg);
    //            //var $affichage = $("#affichageProduct");
    //            //$affichage.empty();
    //            //$affichage.append(msg);

    //        },
    //        error:
    //            (error) => {
    //                console.log("error", error);
    //            }
    //    });
    //});




    $('.category-item').on('click', function (event) {
        event.stopPropagation();
        event.stopImmediatePropagation();
        var _div = event.currentTarget;
        var categoryId = _div.id;
        onClick_hpCategoryItem(categoryId);
        //console.log(categoryId);

    });

        function onClick_hpCategoryItem(hpCategoryId) {

          $.ajax({
            type: "GET",
            dataType: 'html',
            url: "https://localhost:44329/home/GethpCategoryById/" + hpCategoryId,
            async: true,
            contentType: "application/x-www-form-urlencoded",
            success: (msg) => {
                $('#affichageProduct').empty();
                if ($(msg).length > 0) {
                    $('#affichageProduct').append(msg);
                    //$(mondiv).append(msg);
                    console.log(msg);
                }
            },
            error:
                (error) => {
                    console.log("error", error);
                }
          });

        }







