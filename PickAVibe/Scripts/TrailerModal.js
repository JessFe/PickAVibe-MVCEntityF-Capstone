// Script per la gestione del modale di visualizzazione del trailer di un film

$(document).ready(function () {
    // Gestisce il click sul bottone di visualizzazione del trailer
    $('body').on('click', '.watch-trailer', function () {
        // Recupera l'URL del trailer
        var trailerUrl = $(this).data('trailer-url');
        // Crea l'iframe per visualizzare il trailer
        var iframeHtml = `<iframe width="100%" height="480" src="${trailerUrl}" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>`;
        $('#trailerModal .modal-body').html(iframeHtml);
    });

    // Quando il modale viene chiuso, svuota il contenuto
    $('#trailerModal').on('hidden.bs.modal', function () {
        $('#trailerModal .modal-body').empty();
    });
});
