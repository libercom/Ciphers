# Web Authentication & Authorisation

### Course: Cryptography & Security

### Author: Vasile Ignat

---

## Theory

Web Authentication and Authorization are two important concepts in web security that help control access to protected resources on a website.

Authentication is the process of verifying the identity of a user who attempts to access a protected resource. This is usually done by asking the user to provide their credentials, such as a username and password, and checking these credentials against the values stored in a database. If the credentials match, the user is granted access to the protected resource. If the credentials are incorrect, access is denied.

Authorization, on the other hand, is the process of determining whether a user who has been authenticated should be granted access to a protected resource. This is usually done by checking the user's permissions or roles, which are usually stored in a database along with the user's profile. For example, a user with the role of "administrator" may be granted access to all protected resources, while a user with the role of "user" may be granted access to only a limited set of resources.

Web Authentication and Authorization are important for maintaining the security and privacy of sensitive information. They help prevent unauthorized access to protected resources and ensure that only users with the appropriate permissions are able to access these resources. Web Authentication and Authorization are typically implemented using server-side technologies such as PHP, Python, Ruby on Rails, or ASP.NET, but there are also several JavaScript-based solutions available for client-side authentication and authorization.

## Objectives:

1. Take what you have at the moment from previous laboratory works and put it in a web service / serveral web services.
2. Your services should have implemented basic authentication and MFA (the authentication factors of your choice).
3. Your web app needs to simulate user authorization and the way you authorise user is also a choice that needs to be done by you.
4. As services that your application could provide, you could use the classical ciphers. Basically the user would like to get access and use the classical ciphers, but they need to authenticate and be authorized.

## Implementation description

In my previous laboratory work report, I covered nearly all the elements I utilized, but there are still a few classes that went unmentioned. They are:

The JwtService class can be used to securely encode user information into a JWT. The JWT is used to store information about the user's role and name, which can be used to control access to protected resources on the server.

The class has a method named GenerateToken which takes a UserViewModel object as an argument. The method generates a JWT by creating a JwtSecurityToken and configuring it with the issuer, audience, signing credentials, expiration time, and claims. The expiration time of the token is set to three hours.

```c#
public string GenerateToken(UserViewModel user)
{
    var claims = GenerateClaims(user);
    var token = new JwtSecurityToken(
        _jwtSettings.Issuer,
        _jwtSettings.Audience,
        signingCredentials: new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SigningKey)),
            SecurityAlgorithms.HmacSha256),
        expires: DateTime.Now.AddHours(3),
        claims: claims
    );

    var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
    return encodedToken;
}
```

The Login method in the UserController class utilizes the JwtService to generate a JWT token if the password entered matches the one stored in the database.

```c#
if (result != null)
{
    var token = _jwtService.GenerateToken(result);

    return Ok(token);
}
```

Authentication and authorization is enabled in the Program.cs file through the following code lines:

```c#
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SigningKey)),
            ValidateIssuerSigningKey = true
        };
    });
```

and

```c#
app.UseAuthentication();
app.UseAuthorization();
```

We can restrict access to a specific controller or controller method using the Role claim by utilizing the Authorize attribute. Like this:

```c#
[Authorize(Roles = "Admin")]
[HttpGet]
public async Task<IActionResult> GetAll()
{
    var result = await _userService.GetAll();

    return Ok(result);
}
```
