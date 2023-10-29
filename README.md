# Cloud Databases End Assignment 2023
##### Created in C# .NET 6.0 LTS
## Description
This application is for "BuyMyHouse", a website that lists various houses.

It uses a **MS SQL Server** database **locally hosted** in a **Docker Container**, has a **N-Tier** architecture and makes use of **2 Azure Functions**.
<br>
An attempt was made to integrate **CosmosDB** for **scalability** (see dev/cosmos-db), but due to a lack of time it was not implemented.
<br> An **Azure Storage Queue** was also considered, but for the same reason not implemented. <br>
The application is made with **testability** in mind, using **interfaces** and **repositories**.

The **Azure Functions** are used to:
<br>
1. Process mortgage applications for houses and **create new mortgage offers** in the database.
2. **"Email"** the created **mortgage offers** to the buyers at the **end of each day**.

