# Protecting Hyped Sales on E-commerce Websites from Bad Bots in 2022 <img src="https://github.com/samleeatl/cs6727/blob/main/bot.png" width=5% height=5%> 


## Description
In 1997, CAPTCHA was invented by Eran Reshef, Gili Raanan and Eilon Solan to protect websites from bad bot actors. Unfortunately in 2022, using captcha or using just one protection method to protect against shopping bots no longer work. The solution is to utilize a combination of the best bot protection techniques. Based on the Forrester report citing the best Bot management tools available today, some of the best techniues used are fingerprinting, IP reputationm, behavior techniques. This project provides the implemenation of the aformentioned techniques, as well as a custom devloped technique for limiting purchase quantity and checking of jigged addresses.
## Features
- Demo of limiting purchase quantity and checking of jigged addresses
- Datadome API implementation
- Google reCaptcha v3 implementation

## Prerequisites
- Microsoft Windows 10 or higher
- Visual Studio 2022 or higher

## Installation
Simply clone this project down to your local repository and open the project using Visual Studio 2022 or higher. 

### License Key Setup
You must add your own license keys in the appsettings.json file for the application to work.

**You will need to add a key for Datadome:**

**You will need to add a key for Google reCaptcha**
```
{
  "DataDomeConfiguration": {
    "ApiDomain": "api.datadome.co",
    "LicenseKey": "",
    "ApiProtocol": "https"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "GoogleRecaptchaV3Config": {
    "SiteKey": "",
    "SecretKey": "",
    "VerifyURL": "https://www.google.com/recaptcha/api/siteverify"
  },
  "ConnectionStrings": {
    "ShoppingContext": "Server=(localdb)\\mssqllocaldb;Database=Shopping.Data;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
### Libraries referenced
![Nuget packages](https://github.com/samleeatl/cs6727/blob/main/nuget.PNG)

**Steps to setup Datadome:** https://docs.datadome.co/docs

**Steps to setup Datadome using ASP.net Core:** https://docs.datadome.co/docs/aspnet-core <br/>
This project already has the Asp.net Core code sample setup. All you need to do is setup your key located in appsettings.json

**Steps to setup Google reCaptcha v3:** https://developers.google.com/recaptcha/docs/v3
This project already has the Asp.net Core code sample setup. All you need to do is setup your key located in appsettings.json

## Disclaimer
This is an academic project created as part of the CS 6727 Information Security Practicum course at the Georgia Institute of Technology. This project is developed with the intention of using this tool only for educational purpose.
