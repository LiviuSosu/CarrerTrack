function goBack() {
    window.history.back();
}

$('footer').each(function (i, v) {
    if (i > 0) {
        $(v).hide();
    }
});