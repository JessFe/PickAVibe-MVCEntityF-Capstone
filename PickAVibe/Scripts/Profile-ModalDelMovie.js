// Script per la gestione del modale di conferma eliminazione di un film dalla Watchlist o dai film visti

$(document).ready(function () {
    // Gestisce il click sul bottone di conferma dell'eliminazione nel modale
    $('#delete-confirm').click(function () {
        // Recupera l'ID del film memorizzato nel modale
        var movieId = $('#deleteModal').data('id');
        // Recupera l'azione dal modale, per distinguere tra Watchlist e Watched
        var actionUrl = $('#deleteModal').data('action-url');

        // Invia la richiesta al server per eliminare il film
        $.post(actionUrl, { id: movieId }, function (result) {
            // Chiudi il modale
            $('#deleteModal').modal('hide');
            // Ricarica la pagina per visualizzare la lista aggiornata
            location.reload();
        }).fail(function () {
            alert("Error while deleting movie");
        });
    });

    // Quando un bottone di eliminazione viene cliccato, mostra il modale
    $('.delete-button').click(function () {
        // Memorizza l'ID del film e l'URL dell'azione nel modale
        var movieId = $(this).data('id');
        var actionUrl = $(this).data('action-url');
        $('#deleteModal').data('id', movieId);
        $('#deleteModal').data('action-url', actionUrl);
        // Mostra il modale
        $('#deleteModal').modal('show');
    });
});
