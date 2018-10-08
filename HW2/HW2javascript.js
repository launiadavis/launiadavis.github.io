//this is my javascript file for Homework 2


function main()
{
    $(".submitBtn").on("click", function() {
        submitAssignment();
        $("#addAssign")[0].reset();
    })
}


function submitAssignment() 
{
    var x = document.getElementById("className").innerHTML = x;
    var y = document.getElementById("assignName").value;
    var z = document.getElementById("dueDate").value;

    if (x.length === 0 || y.length === 0 || z.length === 0) {
        alert("Invalid input");
        return;
    }
}

$(document).ready(main);