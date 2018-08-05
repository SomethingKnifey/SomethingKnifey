# Please regrade the following:
	-Added a readme
	-Added more CSS. Also note with the CSS, we have been using bootstrap, so there are inline styles and bootstrap classes used throughout the document rather than in the base css style file.

# SomethingKnifey


## About this project

This project is an ecommerce store, designed to sell cutlery.

##Technologies

The site and databases are hosted on Azure. The product and identity databases are hosted on separate sites, and connected through User Secrets connection strings stored securely on Azure. The products database is seeded with 10 entries, and a user with an Admin role can perform CRUD to change the contents of the products database.

## How to use
The deployed URL is located at:

http://somethingknifey.azurewebsites.net/

Once on the site, the user can click on the hyperlinks to register a new account, login to an existing account

## How to use: landing page

The first screen the user is welcomed to is the landing page, as shown below:

![Site screenshot](./Assets/LandingScreen.jpg)

The user then has the options to browse the site products, register for the site, or login if they are currently registered. If the user is an Admin, they are redirected to the Admin portal where they can perform CRUD operations on the products list.

## How to use: Registration

A new user can register for the site. To do so, they click the registration link, and are taken to the form as shown below:

![Site screenshot 2](Register.jpg)

Once all the form information has been filled out, the user is created and saved in the database, then returned to the home screen to shop.

## How to use: Login

Only existing users are able to login. Once a user is logged in, they must manually choose to logout, or will be allowed to skip subsequent logins, via their user info being retreived each time they access the site. If they log out after their initial registration and choose to log back in, they are taken to the form shown below:

![Site screenshot 3](Login.jpg)

An email claim is established when the user registers, and that information serves as the username on login. For many people it is easier to remember which email they signed into a site with, rather than remembering which username they established for a particular site. The password is the password they used on user creation.

## How to use: Shopping

Once a user is logged in, they are able to browse the list of products and shop. If a user is not logged in, they will not be presented with the option of adding items to a shopping cart, but can still browse the inventory. The one exception to this are products that are labeled as military or law enforcement only, through a claims-based restriction policy. A user who is not logged in, or is not military or law enforcement cannot view the details or add restricted items to their cart. An example of the shopping list is shown below:

![Site screenshot 4](Browse.jpg)

## Licensing
This program is used with a MIT license.
