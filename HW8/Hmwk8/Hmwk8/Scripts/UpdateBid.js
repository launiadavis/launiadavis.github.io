/*Make a request to BidRequest() in BidController*/
function bidRequest() {
    var input = document.getElementById("listing-id").value; //retrieve listing ID from HTML attributes
    var id = parseInt(input); //parse the input as an int
    var source = "/Items/BidRequest/" + id; //appends to the URI string: source looks to controllers

    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: showBids,
        error: ajaxError
    });
}

/*Append list of bids to view
 @ param {any} bidList JSON recieved from BidRequest()*/
function showBids(bidList) {
    if (bidList.length == 0) { //empty response display message
        $("message").empty(); //clear message
        $("message").append("There are no bids on this item. Be the first to place a bid on this item!");
    }
    else {
        $("message").empty(); //clear message
        $(".bid-info").remove(); //clears any old bidding data
        //display row-by-row bidding data
        for (var i = 0; i < bidList.length; i++) {
            $(".table").append("<tr class=\"bid-info\"><td>" + bidList[i].Buyer + "</td><td>$" + Number(bidList[i].Amount).toLocaleString('en-US', { minimumFractionDigits: 2 }) + "</td></tr>");
        }
    }
}

/* Display pop-up message*/
function ajaxError() {
    alert("Unable to reach the server. Please try again later. Thank you.");
}

/*The main method that "drives" the script*/
function main() {
    bidRequest(); 

    var interval = 1000 * 5; //time interval 

    window.setInterval(bidRequest, interval); // refreshes the bid list every five seconds
}

$(document).ready(main()); //call main function