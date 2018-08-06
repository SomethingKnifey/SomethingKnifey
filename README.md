# Please regrade the following:
	-Added a readme
	-Added more CSS. Also note with the CSS, we have been using bootstrap, so there are inline styles and bootstrap classes used throughout the document rather than in the base css style file.

# SomethingKnifey


## About this project

This project is an ecommerce store, designed to sell cutlery. The styles of knives range from every day kitchenware, to police and military-style tactical knives.

##Technologies

The site and databases are hosted on Azure. The product and identity databases are hosted on separate sites, and connected through User Secrets connection strings stored securely on Azure. The products database is seeded with 10 entries, and a user with an Admin role can perform CRUD to change the contents of the products database.

## How to use
The deployed URL is located at:

http://somethingknifey.azurewebsites.net/

Once on the site, the user can click on the hyperlinks to register a new account, login to an existing account

## How to use: landing page

The first screen the user is welcomed to is the landing page, as shown below:

![Site screenshot](/KnifeStore/Assets/LandingScreen.jpg)

The user then has the options to browse the site products, register for the site, or login if they are currently registered. If the user is an Admin, they are redirected to the Admin portal where they can perform CRUD operations on the products list.

## How to use: Registration

A new user can register for the site. To do so, they click the registration link, and are taken to the form as shown below:

![Site screenshot 2](/KnifeStore/Assets/Register.jpg)

Once all the form information has been filled out, the user is created and saved in the database, then returned to the home screen to shop.

## How to use: Login

Only existing users are able to login. Once a user is logged in, they must manually choose to logout, or will be allowed to skip subsequent logins, via their user info being retreived each time they access the site. If they log out after their initial registration and choose to log back in, they are taken to the form shown below:

![Site screenshot 3](/KnifeStore/Assets/Login.jpg)

An email claim is established when the user registers, and that information serves as the username on login. For many people it is easier to remember which email they signed into a site with, rather than remembering which username they established for a particular site. The password is the password they used on user creation.

## How to use: Shopping

Once a user is logged in, they are able to browse the list of products and shop. If a user is not logged in, they will not be presented with the option of adding items to a shopping cart, but can still browse the inventory. The one exception to this are products that are labeled as military or law enforcement only, through a claims-based restriction policy. A user who is not logged in, or is not military or law enforcement cannot view the details or add restricted items to their cart. An example of the shopping list is shown below:

![Site screenshot 4](/KnifeStore/Assets/Browse.jpg)

## Claims

This site captures a military or law enforcement claim, along with a user email address. The purpose of the military and law enforcement claim is to limit certain products to professionals in that line of work. Since we had to use a claims-based policy, we chose that. It functions similar to Oakley, which sells glasses, but has an entire line of ballistic eyewear only available to military, law enforcement, fire department, or emergency medical services personnel. Our claim is captured via a checkbox, which is not quite as robust as requiring government-issue ID verification.

The other claim is an email claim. This is just used to access the user database for the rest of our site functionality, including login, as well as user roles.

## Policies

This site enforces an admin-only policy. The reason behind it is that while users are able to add items to their shopping cart and browse the inventory, we wanted users with an Admin role to be the only ones able to update, create, or delete items.

## OAUTH

This site uses both Microsoft and Google 3rd party authentication and login services.

## DB Schema

![DataBase Schema](/KnifeStore/Assets/DbSchema.jpg)

The database schema contains two separate databases. The knife product database is separate as indicated in the visual. The basket and order tables are a subset of the Identity database. This allows us to link the individual user to a basket and order. The basket table is simply a table of each individual shopping entry. In order to find an individual users basket items, the user table is simply parsed for all the entries containing the user ID and and the knife model type.

## Vulnerability Report
Link and reference to your vulnerability report (should be a separate file in your repo)

## Contributors

Paul Ritzman and Jesse Atay

## Licensing
This program is used with a MIT license.
