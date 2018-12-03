# Homework 7 Blog  
## The Assignment  

The goal of the assignment was to create a single page MVC web application that employs AJAX and JSON to build responsive views in combination with the use of an existing external API to acquire data, serverside and finally creating custom routing URLs.  

NOTE: due to time restrictions (end of the term) this lab isn't fully complete. Also I was having issues with gifs to display on the web app page.  

We start off with creating an empty MVC web application (but make sure MVC is checked). Then we created a single controller and view for a page that displays the input textbox.  

Here is a part of the Index view that will show the textbox. Followed by some css to format the page.  
```
<h2>The Internet Language Translator</h2>

@*the input box for users to type into*@
<form action="/Home/Index" method="get">
    <div class="row">
        <div class="col-sm-12">
            <input name="text" id="textbox" placeholder="Begin typing in your message here..." />
        </div>
    </div>
</form>

```  
```
#textbox {
    margin-top: 20px;
    width: 100%;
}
```  
Next we were required to create an account on Giphy to then create an app to recieve an API key. Below is the AppSettingSecrets.config file that is used to gain access to the API key to craft GET requests.  
```
<appSettings>
    <add key="AdminKey" value="**this is where the key goes**">
</appSettings>
```