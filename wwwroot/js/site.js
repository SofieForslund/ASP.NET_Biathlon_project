// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function googleTranslateElementInit() {
    new google.translate.TranslateElement({ pageLanguage: 'sv' },
    'google_translate_element');
}

(function () {
    var button = document.querySelector("#cookieConsent button[data-cookie-string]");
    button.addEventListener("click", function (event) {
        document.cookie = button.dataset.cookieString;
        var cookieContainer = document.querySelector("#cookieConsent");
        cookieContainer.remove();
    }, false);
})();