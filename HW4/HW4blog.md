# Homework 4 Blog

## The Assignment

Our primary goals in this assignment were to begin learning ASP.NET MVC 5 and to write a simple MVC web application that doesn't use a database. During this process we would also demonstrate the use of Viewbag, Request, and Razor language constructs.
As this assignment develops we shall gain an understanding of the operation of controller action methods (simple routing and parameter binding), understand the relationships between Model, View and Controller and how they worked together and finally, understand how GET and POST are used in a MVC application.  

I want to make a note at the beginning of this blog that I didn't work on different branches for this project as I was having issues with getting my project to work from my local repository (but the same code worked just fine outside of my local repository). I worked on the project outside of my local repository and once I completed the whole assignment, I then pushed the it onto my github, one time, on my master branch.  

Let's begin shall we!  

After creating a new project I rewrote sections of the code in the 'Index.cshtml' (our home page) to fit the format of the example provided in the homework description. Below is a portion of this code. It's nothing new but it was good review of using div tags and bootstrap formating for my application home page.

```cshtml
div class="row">
    <div class="col-md-6">
        <h2>Mile to Metric Converter</h2>
        <p>
            Want to know how many millimeters there are in 26.2 miles? This calculator is for you.
            Uses query strings to send form data to the server, which performs the claculation and 
            returns the answer in the requested page.
        </p>
        <p><a class="btn btn-default" href="/Home/Converter">Try it out! &raquo;</a></p>
    </div>
    <div class="col-md-6">
        <h2>Color Chooser</h2>
        <p>Typical online color choosers are way too useful. We wanted something fun and completely useless. 
            This form POST's the data to the server.
        </p>
        <p><a class="btn btn-default" href="/Color/ColorChooser">Check it out! &raquo;</a></p>
    </div>
</div>
```  

Once the home page was completed I moved on to creating my Miles to Metric Converter page. For this page we were to use raw HTML when formating. Using Bootstrap, I set my divs with a class of 'col-md-6' so that my two divs would be displayed side by side in a web browser. I went on to create the input textbox (were users would type in their desired milage number) as well as the radio buttons (for metric units to convert to) and last, a submit button.
In the code below you will see at the top the use of '@{...}'. That is Razor. For this page it will be used to display the header of the page (@ViewBag.Title) and it will also display a message that is written in my HomeController file (@ViewBag.Message).

```cshtml
@{
    ViewBag.Title = "Convert Miles to Metric";
}
<h2>@ViewBag.Title.</h2>

<div class="row">
    <form>
        <!-- creation of textbox -->
        <div class="col-md-6 form-group">
            <label for="input">Miles</label>
            <input type="number" class="layout-form" id="input" step=".01" name="miles" placeholder="What's your milage?" required />
        </div>

        <!-- creation of radio buttons -->
        <div class="col-md-6 form-group">
            <div>
                <input type="radio" name="metric" value="millimeters" />
                <label class="form-check-label">millimeters</label>
            </div>
            <div>
                <input type="radio" name="metric" value="centimeters" />
                <label class="form-check-label">centimeters</label>
            </div>
            <div>
                <input type="radio" name="metric" value="meters" />
                <label class="form-check-label">meters</label>
            </div>
            <div>
                <input type="radio" name="metric" value="kilometers" />
                <label class="form-check-label">kilometers</label>
            </div>
            <!-- created submit button to start conversion -->
            <button class="btn btn-primary" type="submit" value="Convert">Convert!</button>
        </div>

    </form>

    <!-- goes to HomeController and displays message under public ActionResult Converter() -->
    <h2>@ViewBag.Message</h2>
         
</div>
```  

When a user in on the Miles to Metric Converter page and they type in an interger input and press the convert button their input will be recieved from an Action Method Selector, 'GET' that will be in my HomeController file. When the input is recieved it will take the query string and convert it into a double. This will then go through the method's if else statement until it finds the metric unit that was selected for the conversion and compute the new result. Once that computation is complete a string message of the conversion result will be displayed to the user through the use of another ViewBag.Message.
During this phase of the coding process we also began to practice the use of the Debug.WriteLine() method. This was a helpful tool to make sure that we were recieving the right query string from our webpage. Below is the code from HomeController.cs file.

```cshtml
public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            /// takes value entered in textbox from Converter and converts to a double
            double distance = Convert.ToDouble(Request.QueryString["miles"]);
            string measurement = Request.QueryString["metric"];
            // debugging
            Debug.WriteLine(distance);
            Debug.WriteLine(measurement);

            /// if, else if statements to go through and find metric that was seleced by user
            /// then computing the corresponding metric conversion once the seleced metric is found

            double result = 0;

            if(measurement == "millimeters")
            {
                result = distance * 1609344;
            }
            else if (measurement == "centimeters")
            {
                result = distance * 160934.4;
            }
            else if (measurement == "meters")
            {
                result = distance * 1609.344;
            }
            else if (measurement == "kilometers")
            {
                result = distance * 1.609344;
            }
            else
            {
                result = distance;
            }

            string message = "Your mile(s) conversion is: " + Convert.ToString(result) + " " + measurement;
            ViewBag.Message = message;
            return View();
        }
    }
}
```

Time to make some color!  

For the Color Chooser page we were to use Razor's HTML Helpers when formatting the page. This was quite a bit of a learning curve for me but I'm glad to have my fellow classmates help work me through this.
I will briefly go through each of the helpers that were used in this section of code (below).
'@Html.BeginForm' writes a beginning form tag. In this line of code this is where we specify that this page will use Http POST.
'@Html.Label' is similar to the label tag that I used in the converter page. It returns an HTML label element with a property name of the property that is represented. In this case when we look at the Color Chooser page and we see 'Color 1' above an input textbox.
'@Html.Textbox' will return an HTML text input element. This is where users will be able to type in their hexidecimal numbers.

```cshtml
@using (Html.BeginForm("ColorChooser", "Color", FormMethod.Post))
{
    <div class="form-group">
        @Html.Label("color1", "Color #1")
        @Html.TextBox("Color1", null, htmlAttributes: new { @class = "form-control", pattern = "#[0-9A-Fa-f]{3,6}", type = "text", required = "required" })
    </div>

    <div class="form-group">
        @Html.Label("color2", "Color #2")
        @Html.TextBox("Color2", null, htmlAttributes: new { @class = "form-control", pattern = "#[0-9A-Fa-f]{3,6}", type = "text", required = "required" })

    </div>

    <br />
    <button class="btn btn-primary" type="submit" value="">Mix Colors!</button>
}
```
We move on to what happens when a user types in some inputs for the Color Chooser page. Let's take a look at the ColorController.cs file. This part of the assignment was a bit tricky for me so I did collaborate with some other classmates on this section. Inside this file there are two ActionResult methods. One is a GET and the other is a POST. In our POST is where the 'magic' happens. For this method we are passing in some string value parameters (the two hexadecimal numbers). Then the hex values that were entered will go through a ColorTranslator method that takes an HTML color representation and changes it to a GDI+ Color structure. They are each assigned to a variable and then those variables go through multiple if else statements to define the rbg of the value. Once both variable have gone through this they are then mixed with the use of Color.FromArgb that creates a new Color structure. We finish out the code by creating small boxes that will display the colors (first two color inputs and the new mixed color) with the use of ViewBag.  

```cshtml
 [HttpPost]
        public ActionResult ColorChooser(string ColorNum1, string ColorNum2)
        {
            ColorNum1 = Request.Form["Color1"];
            ColorNum2 = Request.Form["Color2"];
            /// let's debug
            Debug.WriteLine(ColorNum1);
            Debug.WriteLine(ColorNum2);
            /// checking the values of object with these variables
            int colorA;
            int colorR;
            int colorB;
            int colorG;

            /// values entered by users are turned into Hex and then color object
            Color C1 = ColorTranslator.FromHtml(ColorNum1);
            Color C2 = ColorTranslator.FromHtml(ColorNum2);

            /// going through and figuring out arbg color nums
            if (C1.A + C2.A >= 255)
            {
                colorA = 255;
            }
            else
            {
                colorA = C1.A + C2.A;
            }
            if (C1.R + C2.R >= 255)
            {
                colorR = 255;
            }
            else
            {
                colorR = C1.R + C2.R;
            }
            if (C1.B + C2.B >= 255)
            {
                colorB = 255;
            }
            else
            {
                colorB = C1.B + C2.B;
            }
            if (C1.G + C2.G >= 255)
            {
                colorG = 255;
            }
            else
            {
                colorG = C1.G + C2.G;
            }

            /// take all the values above and mix the colors
            string mixedColor = ColorTranslator.ToHtml(Color.FromArgb(colorA, colorR, colorB, colorG));
            /// creating boxes to hold the 2 colors user chose and the 3rd mixed color
            if (ColorNum1 != null && ColorNum2 != null)
            {
                /// view connection to ColorChooser to display color boxes
                ViewBag.show = true;

                ViewBag.shape1 = "width: 50px; height:50px; border: 1px solid #000; background:" + ColorNum1 + ";";
                ViewBag.shape2 = "width: 50px; height:50px; border: 1px solid #000; background:" + ColorNum2 + ";";
                ViewBag.shape3 = "width: 50px; height:50px; border: 1px solid #000; background:" + mixedColor + ";";
            }

            return View();
        }
```

That is a quick overview of my process and explaination of what was learned from this assignment. Go on ahead and check out the demo of this assignment from my demo link in my portfolio!
