// Script per la gestione del modale di valutazione dei film visti
// e gestione dello spostamento di un film dalla lista dei film visti alla Watchlist

$(document).ready(function () {
    // Gestisce il cambiamento del valore dello slider di valutazione
    $('#movieRating').on('input change', function () {
        var sliderValue = $(this).val();
        var displayValue = sliderValue / 10;
        $('#ratingValue').text(displayValue);
    });

    // Gestisce il click sul pulsante di salvataggio della valutazione
    $('#saveRating').click(function () {
        var movieId = $('#ratingModal').data('id');
        var rating = $('#movieRating').val();
        
        // Controlla se l'azione di modifica proviene dalla pagina "watched"
        var isEditFromWatchedPage = $('#ratingModal').data('edit-rating');


        // Invia la valutazione al server
        $.post('/Profile/AddToWatched', { movieId: movieId, rating: rating }, function (result) {
            $('#ratingModal').modal('hide');

            // Se l'azione proviene dalla pagina "watched", ricarica la pagina
            if (isEditFromWatchedPage) {
                location.reload();
            } else {
                // Nasconde il bottone "Add to Watched" e mostra un feedback visivo senza ricaricare la pagina
                var button = $('button.add-to-watched[data-id="' + movieId + '"]');
                button.replaceWith('<span style="color: var(--cst-1)"><i class="bi bi-check-lg"></i> Added</span>');
            }
        }).fail(function () {
            alert("Error while saving rating");
        });
    });

    // Gestisce il click sul pulsante di aggiunta alla lista dei film visti
    $('.add-to-watched').click(function () {
        var movieId = $(this).data('id');
        $('#ratingModal').data('id', movieId);
    });
});

$(document).ready(function () {
    // Gestisce il click sul pulsante di modifica valutazione
    $('.edit-rating').click(function () {
        var movieId = $(this).data('id');
        // Imposta il data attribute sul modale prima di aprirlo
        $('#ratingModal').data('edit-rating', true);
        var currentRating = $(this).data('current-rating');
        $('#ratingModal').data('id', movieId);
        $('#movieRating').val(currentRating);
        $('#ratingValue').text(currentRating / 10);
    });

    // Gestisce il click sul pulsante per spostare il film indietro alla Watchlist
    $('.move-back-to-watchlist').click(function () {
        var movieId = $(this).data('id');
        // Invia la richiesta al server per spostare il film
        $.post('/Profile/MoveBackToWatchlist', { movieId: movieId }, function (result) {
            location.reload(); // Aggiorna la pagina per visualizzare i cambiamenti
        }).fail(function () {
            alert("Error while moving movie back to Watchlist");
        });
    });
});
