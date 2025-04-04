# 📌 ADO.NET & Microsoft SQL Customer Management System  

This project is a simple **Customer Management System** developed using **ADO.NET and Microsoft SQL Server**. It allows users to store, update, delete, and list customer information in a database.  

## 🚀 Project Features  

✔️ **Microsoft SQL Server** for robust and scalable database management  
✔️ **ADO.NET** for database operations (CRUD: Create, Read, Update, Delete)  
✔️ Efficient use of **DataReader, DataAdapter, Command, and Connection** in ADO.NET  
✔️ User-friendly interface for easy customer management  
✔️ Optimized SQL queries for fast data processing  

## 🛠️ Technologies Used  

🔹 **C#** - Programming language  
🔹 **ADO.NET** - For database operations  
🔹 **Microsoft SQL Server** - Database management  
🔹 **Windows Forms (WinForms)** - User interface  

## 📂 Project Structure  

📦 Customer Management System
┣ 📂 DatabaseScripts
┃ ┣ 📜 CreateDatabase.sql
┃ ┣ 📜 CreateTables.sql
┣ 📂 Forms
┃ ┣ 📜 MainForm.cs
┃ ┣ 📜 CustomerForm.cs
┣ 📂 DataAccess
┃ ┣ 📜 DatabaseHelper.cs
┃ ┣ 📜 CustomerRepository.cs
┣ 📂 Models
┃ ┣ 📜 Customer.cs
┣ 📜 Program.cs
┣ 📜 App.config
┗ 📜 README.md

## 📌 Installation & Setup  

### 1️⃣ Install Required Dependencies  
Make sure you have the following tools installed:  
- **.NET Framework / .NET Core**  
- **Microsoft SQL Server**  
- **Visual Studio (preferably 2022 or later)**  

### 2️⃣ Set Up the Database  
Run the SQL scripts in the `DatabaseScripts/CreateDatabase.sql` file to create the required database in **Microsoft SQL Server**.  

### 3️⃣ Update the Connection String  
Modify the **SQL Server connection string** in `App.config` or `DatabaseHelper.cs` according to your server configuration:  

```csharp
string connectionString = "Server=YOUR_SERVER;Database=CustomerDB;Trusted_Connection=True;";

4️⃣ Run the Project
Open CustomerManagementSystem.sln in Visual Studio and press F5 to run the project! 🚀

📌 Screenshots
🖥️ Main Screen

📊 Add Customer Form

📌 Planned Future Features
🔹 User authentication and authorization
🔹 Reporting and statistical analysis graphs
🔹 Exploring Entity Framework as an alternative approach

🤝 Contributing
If you would like to contribute to this project, follow these steps:

Fork this repository 🍴

Create a new branch: git checkout -b new-feature

Make your changes and commit: git commit -m "Added a new feature"

Push to the branch: git push origin new-feature

Submit a pull request 🚀

📄 License
This project is licensed under the MIT License. See the LICENSE file for more details.
