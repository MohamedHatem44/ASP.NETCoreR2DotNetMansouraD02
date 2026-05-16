# ASP.NETCoreR2DotNetMansouraD02

# 🔷 ASP.NET Core MVC – Day 2 (CRUD & ViewModel) (.NET 9)

This project builds on Day 1 and introduces:

- CRUD Operations (Create, Read, Update, Delete)
- ViewModel Usage
- ViewData & ViewBag
- Model Binding (Advanced)
- RedirectToAction
- Forms Handling
- Bootstrap Modal for Delete Confirmation

---

# 📁 Project Overview

This project manages Employees using:

- Employee Model
- EmployeeReadVM (ViewModel)
- Static List<Employee> as Fake Database
- MVC Pattern

---

# 🚀 Features

✔ Display all employees  
✔ View employee details  
✔ Create new employee  
✔ Edit employee  
✔ Delete employee  
✔ Use ViewModel for Details page  
✔ Use ViewData & ViewBag  
✔ Bootstrap modal confirmation  

---

# 📌 EmployeeController

Uses:

```csharp
static List<Employee> employees
```

As an in-memory database.

---

# 📌 Read (Get Data)

## 🔹 Index()

```csharp
public IActionResult Index()
{
    return View(employees);
}
```

Displays all employees in a table with:

- Details
- Edit
- Delete
- Create New

---

## 🔹 GetById()

```csharp
public IActionResult GetById(int Id)
```

- Finds employee
- If not found → RedirectToAction("Index")
- Maps Employee → EmployeeReadVM
- Returns Details View

### ViewModel Example

```csharp
public class EmployeeReadVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string PageTitle { get; set; }
    public string UnName { get; set; }
}
```

✔ Separates View from Model  
✔ Prevents exposing full entity  

---

# 📌 Create

## 🔹 Step 1 – Show Form

```csharp
public IActionResult Create()
{
    return View();
}
```

---

## 🔹 Step 2 – Receive Data

```csharp
public IActionResult ActualCreate(Employee employee)
{
    employees.Add(employee);
    return RedirectToAction("Index");
}
```

✔ Uses Model Binding  
✔ Adds employee to list  
✔ Redirects to Index  

---

# 📌 Edit

## 🔹 Load Employee

```csharp
public IActionResult Edit(int id)
```

Returns employee to Edit view.

---

## 🔹 Save Changes

```csharp
public IActionResult ActualEdit(Employee employee)
```

✔ Finds employee  
✔ Updates properties  
✔ Redirects to Index  

---

# 📌 Delete

```csharp
public IActionResult Delete(int id)
```

✔ Finds employee  
✔ Removes from list  
✔ Redirects to Index  

---

# 📌 ViewData & ViewBag

Used to pass extra data from Controller to View.

```csharp
ViewData["PageTitle"] = "Employees List";
ViewBag.Hamada = "Hamada";
```

✔ ViewData → Dictionary  
✔ ViewBag → Dynamic object  

---

# 📌 Razor Forms Example

```html
<form action="~/Employee/ActualCreate">
```

Inputs use:

```
name="Id"
name="Name"
name="Age"
name="Salary"
```

Model Binding automatically maps them to Employee object.

---

# 📌 Delete Confirmation Modal

Uses Bootstrap modal:

- Passes employee id & name
- JavaScript handles delete redirection

```javascript
window.location.href = `/Employee/Delete/${employeeId}`;
```

✔ Better UX  
✔ Prevents accidental deletion  

---

# 🎯 Learning Goals (Day 2)

This project teaches:

- Full CRUD in MVC
- ViewModel concept
- Model Binding with complex objects
- RedirectToAction
- Form handling
- Basic client-side scripting
- Clean MVC structure

---

# 🛠 Requirements

- .NET 9 SDK  
- Visual Studio 2022+  
- Bootstrap (for styling & modal)

---

# ▶ Run Project

```
dotnet run
```

Or press **F5** in Visual Studio.

---

# 📌 Key Takeaway

Day 2 moves from:

Displaying data ➜ To Full CRUD operations.

It introduces:

- ViewModels
- Forms
- Data manipulation
- Better separation between Model and View

This is the foundation before working with real databases (EF Core).

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer  

---