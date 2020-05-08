# Purpose
* This project demonstrates how to add react to existing asp.net core MVC page.
The asp.net core React project template doesn't work because it only supports single page application - SPA. 
* Also, every time save a change in csthml, html, react source code, the browser can automatically refresh.

# Example scenario 

![](DocImages/selectCountry.JPG?raw=true)

1. When index.cshtml page is loading,  the server renders a country list, an input, and a <div> elements.
2. when the page is loaded in a browser, the React script renders the <div> as a autocomplete component.
3. When a user selects a country, the react script set the selected country id to the input
4. when index.cshtml is submitted, the asp.net controller received the selected country id

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

# Add a React Type script app to the asp.net core MVC project
## create a react app 
https://create-react-app.dev/docs/adding-typescript/
````
npx create-react-app my-app --template typescript
````
## Changes in package.json
* add a package cra-build-watch  https://www.npmjs.com/package/cra-build-watch
add it for 3 reasons:
1. we can get a development build
2. we can set the output directory
3. every time we save a change in react, it generate \*.js file in wwwroot, then Browser link detects the change and refresh the browser.
````
 "devDependencies": {
    "cra-build-watch": "^3.2.0"
  },
````
add watch to scripts
````
    "watch": "cra-build-watch -b ../wwwroot"
````

## Copy react file to the asp.net core MVC project
1. create a folder ReactApp in the project root folder
2. copy public, src, package.json tsconfig.json from the react app directory to the ReactApp directory

# Reference react in the asp.net core MVC Project
## build react app
open a terminal,go to \[the project directory]\\ReactApp, run command
````
npm run watch
````
it will generate the javascripts in wwwroot

## add refrence to \_layout.cshtml
add react java script refrence to layout file, so you don't need to refrence react in every page. Here asp-append-version tells browser to re-downlaod the js file.
```
    <script src="js/bundle.js" asp-append-version="true"></script>
    <script src="js/0.chunk.js" asp-append-version="true"></script>
    <script src="js/1.chunk.js" asp-append-version="true"></script>
    <script src="js/main.chunk.js" asp-append-version="true"></script>
```
# Finally interact react in Index.cshtml
## pass in parameter to react
* In the asp.net core controller, put contry list to ViewBag.CountryJson
* in the cshtml, use data-option to pass parameter to react
* the other directive data-bind, is the html element id of a hidden form input
````
    <div class="auto-complete"
         data-bind="countryId"
         data-options='@ViewBag.CountryJson'>
    </div>
    <input type="hidden" id="countryId" name="id" />
````
## in index.tsx Parse json string as object, then pass it to react
````
    const ds = (x as any).dataset;
    const options = JSON.parse(ds.options);
    const bind:string = ds.bind;
    ReactDOM.render(<Combobox bind={bind} options={options} />, x);
````
## in MyAutoComplete.tsx, get result from react
* in react, when data change, it save the change to the form input
````
    const ele = document.getElementById(bind) as any;
    ele.value= val? val.id: val;
````
