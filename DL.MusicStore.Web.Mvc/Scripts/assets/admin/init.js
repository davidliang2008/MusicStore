// When the DOM loads
$(function () {
    // Setup event bindings
    $('#sidebar-toggler').click(function () {
        $('body').toggleClass('sidebar-open');
        return false;
    });
});