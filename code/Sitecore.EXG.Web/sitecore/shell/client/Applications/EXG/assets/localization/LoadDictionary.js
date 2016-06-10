const url = window.location.href;
const languageSelector = 'sc_lang';
const dictionaryPath= '/sitecore/shell/client/Applications/EXG/assets/localization/dictionaries/';
var language = getParameterByName(languageSelector, url) || "en";

if (!window.EXG) {
    window.EXG = {};
}

var fileUrl = dictionaryPath + language + '.json';
var jqxhr = $.getJSON(fileUrl, function (result) {
        window.EXG.Dictionary = result;
    })
    .fail(function () {
        fileUrl = dictionaryPath + 'en.json';
        jqxhr = $.getJSON(fileUrl, function (result) {
            window.EXG.Dictionary = result;
        })
        .fail(function () {})
        console.log("No english defined.");
        }); 

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}