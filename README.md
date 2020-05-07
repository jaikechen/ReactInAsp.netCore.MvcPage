# Purpose
This project demonstrates how to add react to existing asp.net core MVC page.
The asp.net core React project template doesn't work because it only supports single page application - SPA. 

# example scenario 


![](DocImages/selectCountry.JPG?raw=true)

When index.cshtml page is loading,  the server renders a country list, an input, and a <div> elements.
when the page is loaded in a browser, the React script renders the <div> as a autocomplete component.
When a user selects a country, the react script set the selected country id to the input
when index.cshtml is submitted, the asp.net controller received the selected country id
