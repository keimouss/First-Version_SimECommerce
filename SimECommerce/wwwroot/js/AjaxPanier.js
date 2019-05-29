var panierEncours;
function addproductTopanier_catalog(productID) {
    var Idproduct = productID;
    if (Idproduct!=null) {
        console.log(Idproduct);
        //var quantite = data.currentTarget.dataset.quantite;
        $.ajax({
            type: "Post",
            dataType: 'text',
            url: "https://localhost:44329/Catalog/AjoutPanier/" + Idproduct,
            async: true,
            contentType: "application/json",
            success: (msg) => {

                //renseigner les elements du div "flyout-panier" et "qteProduits"
                var lpanier = $.parseJSON(msg);
                panierEncours = lpanier;
                //Modifie la qté de produits du panier
                var $qteproducts = $("#qteproducts");
                $qteproducts.empty();
                $qteproducts.append(lpanier.qteProduits);

                //*renseigne le mini-panier//

                $("#countPanier").empty();
                $("#countPanier").append("Vous avez : " + lpanier.qteProduits + "article(s).");

                $("#itemsPanier").empty();
                for (var i = 0; i < lpanier.lignes.length; i++) {
                    //console.log("lignes:" + lpanier.lignes[i].nomProduit);
                    $("#itemsPanier").append('<div><img class="panier-picture"  src="ImageProducts/ViewImage/' + lpanier.lignes[i].idProduit + '" ></div>',
                        '<div><span style:"font-size:3px;">' + lpanier.lignes[i].nomProduit + '</span></div>', '<div>P.U : $ <span id="pproduitprix">' + lpanier.lignes[i].prix + '</span></div>',
                        '<div>Qté : <span id="pproduitquantite">' + lpanier.lignes[i].quantite +'</span></div>');
                }


                $("#totalpanier").empty();
                $("#totalpanier").append("Sous-Total : $" + lpanier.totalPanier);
                console.log(lpanier);
                console.log("quantité " + lpanier.qteProduits);
                for (var i = 0; i < lpanier.lignes.length; i++) {
                    console.log("lignes:" + lpanier.lignes[i].nomProduit);
                }

                
            },
            error:
                (error) => {
                    console.log("error", error);
                    console.log(Idproduct);
                }
        });

    }
    
}

function envoieLePanier() {
    var lignepanier = panierEncours;
    console.log(lignepanier);

}