# Protecting Hyped Sales on E-commerce Websites from Bad Bots in 2022 <img src="https://github.com/samleeatl/cs6727/blob/main/bot.png" width=5% height=5%> 


## Description

## Features

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
