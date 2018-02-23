# <u>Finance App</u>
This project is a **C#** desktop application for managing personal and professional finances.

It is designed with ease of use in mind, while still providing a powerful tool for monitoring ones own finances.
<br><br>

### <u>Program Structure</u>
The application functions using **three** key classes.<br>
The **User Account**, the **Funding Profile**, and the **Cash Flow**.
<br><br>

#### <u>User Accounts </u>
The **User Account** is the users primary point of access to the application.<br>
The account contains the credentials the user uses to access the application, and for all intents and purposes; it defines and uniquely identifies the user.

i.e. A user "Bob", would have a single account associated with him.<br>
He would log into this account when he starts the application.
<br><br>

#### <u>Funding Profile</u>
The **Funding Profile** is a "container" for **Cash Flows** within an account.

**Each profile is associated with an Account**, and is used to logically refer to a collection of **Cash Flows**.

An account can have **more than one** profile associated with it.

i.e. Our user "Bob" may have *three* profiles on his account. One titled "Food Budget", one titled "Utilities", and one titled "Savings".
<br><br>

#### <u>Cash Flow</u>
The **Cash Flow** is where the money is. Each **Cash Flow** identifies a transaction, and holds all of its corresponding details (i.e. name, amount, date of payment, due date, etc...).

Each **Cash Flow** is associated with **one** profile on an account.
<br><br>

### <u>Testing</u>
The **automated unit tests** reside in the **testing.cs** file.<br>
This file should contain the **entire** suite of test cases to be run before each check-in.<br><br>

Each function should test a **single method**, and should be formatted similar to the below sample:

```csharp
/// <summary>
/// Description of TEST
/// </summary>
[TestMethod]
public void nameOfTestMethod()
{
    Assert.IsTrue(true);
}
```

### <u>Code Style Guide</u>
To ensure consistency in formatting and readability, please adhere to the following rules.
<br><br>

<u>**Variables**, **Methods**, and **Class** names should be **Camel Case**</u>
If a name would require a space, the space should be **omitted**.

```csharp
int someInteger;
string firstName;
```
<br><br>

<u>**Constants** should be entirely in **Uppercase**</u>
If the name needs a space, an **underscore** should be used

```csharp
const int ONE_HUNDRED = 100;
```
<br><br>

<u>Each method should have a **summary** above it, detailing what it does</u>

```csharp
/// <summary>
/// Does a thing
/// </summary>
public int doSomething(string thing)
{
    return thing.ToCharArray().Count();
}
```
