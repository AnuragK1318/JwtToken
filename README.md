# 🔐 JWT Authentication API - ASP.NET Core

A secure Web API built using **ASP.NET Core** that implements **JWT (JSON Web Token) authentication** with **role-based authorization**.

---

## 🚀 Features

- ✅ User Registration
- ✅ User Login with JWT Token Generation
- ✅ Secure Password Hashing (PasswordHasher)
- ✅ Role-Based Authorization (User / Admin)
- ✅ Protected Endpoints using `[Authorize]`
- ✅ Swagger Integration with JWT Authentication
- ✅ Entity Framework Core with SQL Server

---

## 🛠️ Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- JWT (JSON Web Tokens)
- Swagger (Swashbuckle)

---

---

## 🔑 Authentication Flow

1. User registers with username & password
2. Password is securely hashed and stored
3. User logs in → receives JWT token
4. Token is used to access protected APIs
5. Role-based access controls endpoints

---

## 🔐 JWT Configuration

JWT is configured using:

- Issuer
- Audience
- Secret Key

Example (`appsettings.json`):

```json
"appSettings": {
  "Key": "your-secret-key",
  "Issuer": "https://localhost:7093",
  "Audience": "https://localhost:7093"
}
📌 API Endpoints
🔓 Public Endpoints
Method	Endpoint	Description
POST	/api/Auth/register	Register new user
POST	/api/Auth/login	Login & get token
🔒 Protected Endpoints
Method	Endpoint	Access
GET	/api/Auth/auth-check	Any authenticated user
GET	/api/Auth/admin-check	Admin only
🧪 Testing with Swagger
Run the application
Open Swagger UI
Call /login to get JWT token
Click Authorize 🔒
Enter token (without "Bearer")
Access protected endpoints
📸 Sample Response
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
📚 What I Learned
Implementing JWT authentication in ASP.NET Core
Securing APIs using tokens instead of sessions
Role-based authorization using claims
Handling real-world issues like token validation errors
Integrating Swagger with authentication
🔗 Future Improvements
Refresh Tokens
Global Exception Handling
Logging (Serilog)
Clean Architecture (Layered design)
Input Validation (FluentValidation)
🤝 Contributing

Feel free to fork and improve the project!

📧 Contact

If you’d like to connect or discuss backend development:

LinkedIn: (add your profile link)
GitHub: https://github.com/AnuragK1318

---

# 🔥 What this does for you

This README:
- Makes your project look **structured & professional**
- Shows **understanding, not just coding**
- Helps recruiters quickly scan your skills

---

# 💡 Small Customization (do this)

Before pushing:
- Add your **LinkedIn link**
- Add **actual DB name if needed**
- Optional: add screenshots (Swagger)

---

# 🚀 Next Step

After adding this:
1. Push to GitHub  
2. Post on LinkedIn (use the post I gave earlier)  
3. Add repo link in post  

---

If you want, I can:
- Make your repo look like a **production-level project**
- Or help you build **one more feature to stand out**

Just tell me 👍
