VAT Calculator API (.NET 8)

Overview

This is a REST API built using .NET 8 that calculates Net, Gross, and VAT amounts based on Austrian VAT rates.

The API accepts one of the values (Net, Gross, or VAT) along with a valid VAT rate (10%, 13%, 20%) and calculates the remaining values.

Features

* Calculate Net, Gross, VAT
* Supports Austrian VAT rates: 10%, 13%, 20%
* Input validation with meaningful error messages
* RESTful API using ASP.NET Core
* Swagger UI for testing
* Unit tests included (xUnit)

Technologies used

* .NET 8
* ASP.NET Core Web API
* Swagger
* xUnit

Run the project

1. Clone the repository:
     https://github.com/PrabhashaniMohotti/VatCalculatorApi
2. Navigate to the project
3. Run the application
4. Open Swagger UI

Note

Swagger UI may show the default value 0 for numeric fields due to HTML limitations.
The API works correctly when fields are omitted in the JSON request.
