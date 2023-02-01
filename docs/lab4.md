# Hash functions and Digital Signatures

### Course: Cryptography & Security

### Author: Vasile Ignat

---

## Theory

Hash functions and digital signatures are important concepts in cryptography.

A hash function is a mathematical algorithm that takes an input of arbitrary length and returns a fixed-length output, called a hash or a message digest. The hash function has the properties of being deterministic, meaning that the same input will always produce the same output, and being infeasible to reverse, meaning that it is computationally hard to find the original input given the hash output. These properties make hash functions useful for data integrity checking, as changes to the input will result in a different output hash.

Digital signatures, on the other hand, are a way to ensure the authenticity and integrity of a digital message. A digital signature is a mathematical scheme that combines a hash of the message and the signer's private key to produce a signature. The signature is then verified using the signer's public key and the original message. If the signature is valid, the recipient can be sure that the message came from the signer and that it has not been tampered with.

In practice, digital signatures are often used in combination with public key cryptography, such as RSA or Elliptic Curve Digital Signature Algorithm (ECDSA), to ensure secure communication between parties. The signer uses their private key to generate a signature for the message, which is then transmitted along with the message to the recipient. The recipient verifies the signature using the signer's public key and the original message, ensuring that the message came from the signer and that it has not been tampered with.

In conclusion, hash functions and digital signatures are two important concepts in cryptography that are used to ensure the integrity and authenticity of digital messages. While hash functions provide a way to check the integrity of data, digital signatures provide a way to verify the authenticity of a message by combining a hash of the message and the signer's private key.

## Objectives:

1. Get familiar with the hashing techniques/algorithms.
2. Use an appropriate hashing algorithms to store passwords in a local DB.

- You can use already implemented algortihms from libraries provided for your language.
- The DB choise is up to you, but it can be something simple, like an in memory one.

3. Use an asymmetric cipher to implement a digital signature process for a user message.

- Take the user input message.
- Preprocess the message, if needed.
- Get a digest of it via hashing.
- Encrypt it with the chosen cipher.
- Perform a digital signature check by comparing the hash of the message with the decrypted one.

## Implementation description

In the fourth lab assignment, "Hash functions and Digital Signatures", I developed a REST API that enables user creation and login in the application. I utilized SQL Server as the database and created a User Service that offers the CreateUser and Login functions.

The CreateUser method of the UserService class takes in a UserViewModel object and creates a User object from it. First, it hashes the password using the ShaEncryptor method. Then it encrypts the hashed password using the RSA encryption algorithm; Finally, it creates a new User object using the encrypted password, name and role from the input UserViewModel, and stores it in the database by calling the repository method.

```c#
public async Task CreateUser(UserViewModel userModel)
{
    var password = userModel.Password;
    var rsa = new RSA();

    password = _shaEncryptor.HashPassword(password);
    password = rsa.Encrypt(password);

    var user = new User(password, userModel.Name, userModel.Role);

    await _repository.CreateUser(user);
}
```

The Login method of the UserService class takes in a username and password, hashes the password using the \_shaEncryptor.HashPassword method, then retrieves the corresponding User object from the database. It then uses the RSA decryption algorithm to decrypt the password stored in the User object. Finally, it compares the decrypted password to the hashed password from the input, and returns a UserViewModel object if the passwords match. If the passwords do not match, the method returns null.

```c#
public async Task<UserViewModel> Login(string name, string password)
{
    password = _shaEncryptor.HashPassword(password);

    var rsa = new RSA();
    var user = await _repository.GetUser(name);
    var decryptedPassword = rsa.Decrypt(user.Password);

    if (string.Equals(password, decryptedPassword, StringComparison.OrdinalIgnoreCase))
    {
        return new UserViewModel { Name = user.Name, Password = "", Role = user.Role };
    }
    else
    {
        return null;
    }
}
```

The "ShaEncryptor" class has a public method named HashPassword which takes a string argument password. The method uses the SHA256 algorithm to generate a hash of the password.

```c#
public class ShaEncryptor : IShaEncryptor
{
    public string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var secretBytes = Encoding.UTF8.GetBytes(password);
        var secretHash = sha256.ComputeHash(secretBytes);

        return Convert.ToHexString(secretHash);
    }
}
```

The UserController utilizes the UserService class, which contains the following two methods:

```c#
[HttpPost("create")]
public async Task<IActionResult> CreateUser(UserViewModel userModel)
{
    await _userService.CreateUser(userModel);

    return Ok();
}

[HttpPost("login")]
public async Task<IActionResult> Login(LoginModel loginModel)
{
    var result = await _userService.Login(loginModel.Name, loginModel.Password);

    if (result != null)
    {
        var token = _jwtService.GenerateToken(result);

        return Ok(token);
    }

    return BadRequest();
}
```
