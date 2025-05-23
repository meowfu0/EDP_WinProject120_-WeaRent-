# WearRent: An Admin-Side Web-Based Rental Platform for Apparel

<p align="center">
  <img src="logonbg.png" alt="WearRent Logo" width="200">
</p>

---

## 📜 Description
A simple Windows Forms application developed in C# for managing the admin side of **WearRent** — an e-commerce platform for renting and purchasing clothes. This project focuses on building a functional and user-friendly graphical user interface (GUI) using C# Windows Forms.

---

## 🌲 Project Branch
### `master` branch
➤ Contains the complete Visual Studio Windows application (C#), including the GUI and core functionalities.

---

## 🧩 Database Design
The system uses 8 main relational tables:

| **Table**      | **Description**                                                                                                                                              |
|----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Renters**    | Stores information about individuals or organizations that rent out clothes. This table includes details such as Renters_Name, Email Address, Phone Number, Address, Created_At, Modified_At, and Deleted_At.  |
| **Lenders**    | Contains information about the people or companies offering clothes for rent. This table records lender-specific details like Name, Email Address, Phone Number, Address, Created_At, Modified_At, and Deleted_At. |
| **Clothes**    | Tracks clothing items available for rental or purchase. This table includes item details like Name, Size, Color, Rental_Price, Category_Name, Lender_Name, Created_At, Modified_At, and Deleted_At. |
| **Categories** | Organizes clothing items into categories such as dresses, shirts, pants, etc., making it easier to search and filter items based on type. The table contains Category_Name, Created_At, Modified_At, and Deleted_At. |
| **Orders**     | Keeps a record of customer orders for renting or purchasing clothes, including Rental_Name, Clothes_Name, Order_Date, Return_Date, Lender_Name, Quantity, Rental_Price, Total_Price, Payment_Status, Created_At, Modified_At, and Deleted_At. |
| **Users**      | Contains the login credentials and access control information for admin users. This table manages details such as Name, Birthday, Email Address, Phone Number, Password_Hash, Reset_Code, Reset_Code_Expiration, Created_At, Modified_At, and Deleted_At. |
| **Customers**  | Stores customer details such as Name, Contact Information, and Order History. This allows the platform to keep track of customer activity and preferences. The table includes fields like Customer_Name, Email, Phone Number, Address, Order_History, Created_At, Modified_At, and Deleted_At. |

---

## ⚙️ Installer
📦 **Visual Studio Installer Project**  
Built using Visual Studio Installer Projects.

**Outputs:**
- `EDPProjSetup.msi`
- `setup.exe`

**📂 Output Location:**
- `EDPProjSetup/Debug/`

---

## 🛠 Features
- **Login System**: Secure user authentication for admin users.
- **Forgot Password and Recovery**: Functionality for users to reset their password.
- **List of System Users**: Includes CRUD (Create, Read, Update, Delete) functions for managing users.
- **Primary Transactions**: Seven primary database transactions that utilize triggers, functions, procedures, and events.
- **Report Generation**: Generate reports using MS Excel with search and filtering capabilities to view data dynamically.

---

## 📊 Reports
The following folders contain the generated reports for each section of the platform:

- **CategoriesData**: Contains reports related to the categories of clothing available for rent or purchase.
- **ClothesData**: Includes reports of the clothing items available for rental or purchase, detailing item characteristics like size, color, and price.
- **LendersData**: Contains reports on the lenders offering clothes for rent, including lender details and available inventory.
- **OrdersData**: Tracks all orders made by customers, including rental dates, return dates, and payment statuses.
- **RentersData**: Contains reports on renters, including their contact details, inventory, and rental history.

---

## 👨‍💻 Developer
- **Vicente C. Bercasio II (BSIT 3B)**  
  Bachelor of Science in Information Technology  
  
---
