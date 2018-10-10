//this is my javascript file for Homework 2

//runs when the "Submit" button is pushed on html page
function main()
{
    $(".submitBtn").on("click", function() {
        submitAssignment();
        $("#addAssign")[0].reset();
    })
}

/* This function will retreive input from html page
   and check to make sure that all text imput fields
   have an input entry */
function submitAssignment() 
{
    console.log("submit button clicked on");
    var x = document.getElementById("className").value;
    console.log(x);
    var y = document.getElementById("assignName").value;
    console.log(y);
    var z = document.getElementById("dueDate").value;
    console.log(z);

    // test for any empty text input boxes
    if (x.length === 0) 
    {
        alert("Invalid input. Please enter in a class name");
        return;
    } else if (y.length === 0) 
    {
        alert("Invalid input. Please enter in an assignment name.");
        return;
    } else if (z.length === 0) 
    {
        alert("Invalid input. Please enter in a due date.");
        return;
    } else {
        createLog(x, y, z);
        return;
    }
}

/*this function will create the log of the input that was 
  entered in by the user*/
function createLog() {
    console.log("js output");
    var arg1 = arguments[0];
    console.log("element 1 = "+ arg1);
    var arg2 = arguments[1];
    console.log("element 2 = "+ arg2);
    var arg3 = arguments[2];
    console.log("element 3 = "+ arg3);
    var element = document.getElementById('topLog');
    element.innerHTML = "<strong><u>You have assignments due!</u></strong>";

    //code below was borrowed and modified from ridethatcyclone's HW2
    //will create a description list for each input entry
    $('.myAssign').append("<div class='myNewAssign'><dl>In " + arg1 + " you have " + arg2 + " due on " + arg3 + " " 
    + "<div class='editButtons btn-group'><button class='btn btn-primary delete-btn' onclick=\"if (confirm('You have finished this assignment. Is it okay to remove it?')) {$(this).closest('.myAssign').remove();} else return false;\">Assignment Complete</button></div></div>");
    
}

$(document).ready(main);