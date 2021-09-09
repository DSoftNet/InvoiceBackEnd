// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#expirationCreate").on("change", function () {
    let status = $(this).val();

    if (status==="true")
        $('#ExpirationAtCreate').show();
    else
        $('#ExpirationAtCreate').hide();
});