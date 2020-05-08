# Purpose
This project demonstrates how to add react to existing asp.net core MVC page.
The asp.net core React project template doesn't work because it only supports single page application - SPA. 

# Example scenario 

![](DocImages/selectCountry.JPG?raw=true)

When index.cshtml page is loading,  the server renders a country list, an input, and a <div> elements.
when the page is loaded in a browser, the React script renders the <div> as a autocomplete component.
When a user selects a country, the react script set the selected country id to the input
when index.cshtml is submitted, the asp.net controller received the selected country id

# Add Browser Link to asp.net core mvc project

You can use BrowserLink to refresh the browser every time you save a cshtml, html, or js file
https://docs.microsoft.com/en-us/aspnet/core/client-side/using-browserlink?view=aspnetcore-3.1
````c#
 if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
```` 

# Add a React Type script to the asp.net core mve project
## create a react app 
https://create-react-app.dev/docs/adding-typescript/
````
npx create-react-app my-app --template typescript
````
## Changes in package.json
add a package cra-build-watch  https://www.npmjs.com/package/cra-build-watch
````
 "devDependencies": {
    "cra-build-watch": "^3.2.0"
  },
````
add watch to scripts
````
    "watch": "cra-build-watch -b ../wwwroot"
````

# Enable Use Browser link

# Change the _layout.cshtml

# Index.cshtml
## pass in parameter to react
## get result from react
