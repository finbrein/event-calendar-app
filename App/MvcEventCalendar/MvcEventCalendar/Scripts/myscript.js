$(function() {
    $('.category').change(function() {
        var value = $(this).val();
        if (value != null && value != '') {
            window.location = 'http://localhost:' + window.location.port + $(this).data('browse-url') + '?category=' + value;
        }
    });
});
