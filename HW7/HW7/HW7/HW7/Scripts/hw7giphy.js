// words that won't be considered for being displayed as a GIF
var nonWords = ["i", "in", "on", "a", "my", "he", "his", "him", "she", "her", "so", "the", "from", "to", "you", "for", "is", "be", "just", "then", "got", "of", "onto", "into", "under", "above", "going", "an", "this", "that"];

/**
 * send request to the GIPHY servers
 * @param {any} keyword the word that we want translated into a gif
 */
function requestGiphy(keyimageword) {
    var source = "Giphy/Image/" + keyimageword;

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: showImage,
        error: ajaxError
    });
}

/**
 * display the image to a client as a gif
 * @param {any} imageDisplay json data recieved from GIPHY server
 */
function showImage(imageDisplay) {

    var image = imageDisplay.data.images.fixed_height_small.url; //uri of gif displayed

    $("#live-gif").append("<img src=\"" + image + "\"/>&nbsp;"); //appends gif for html document
}

/**
 * display a pop-up alert
 * */
function ajaxError() {
    alert("Image could not be loaded.");
}

/**
 * main method that drives the javascript
 * */
function main() {
    $("#textinput").keypress(function (x) {
        if (x.keyCode == 32) {

            var data = document.getElementById("textinput").value; //grab text from input box
            data = data.split(" "); //words are split in the array

            endingPosition = data.length - 1;
            data = data[endingPosition]; //grabbing last word in the array
            var words = data.toLowerCase(); //convert all words to lowercase to check against list of nonWords above

            if (nonWords.includes(words)) {
                $("#live-gif").append("<label>" + data + "</label>&nbsp;") //a nonWord that is found is displayed as regular text
            }
            else {
                requestGiphy(data); //request is sent to GIPHY and the word is displayed as a gif
            }
        }
    });
}

$(document).ready(main); //call to the main method is done when the page is loaded