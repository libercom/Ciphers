using AsymmetricCiphers;
using ClassicalCiphers;
using SymmetricCiphers;
using System.Numerics;
using System.Text;

CaesarCipher caesarCipher = new CaesarCipher(3);
AtbashCipher atbashCipher = new AtbashCipher();
CaesarCipherWithKey caesarCipherWithKey = new CaesarCipherWithKey(3, "hola");
VigenereCipher vigenereCipher = new VigenereCipher("cake");
RSAEncryptorDecryptor rsa = new RSAEncryptorDecryptor();
RC4 rc4 = new RC4("rand");

string message = "Hello motherfucker";

{
    string encryptedMessage = caesarCipher.Encrypt(message);
    string decryptedMessage = caesarCipher.Decrypt(encryptedMessage);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}

{
    string encryptedMessage = atbashCipher.Encrypt(message);
    string decryptedMessage = atbashCipher.Decrypt(encryptedMessage);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}

{
    string encryptedMessage = caesarCipherWithKey.Encrypt(message);
    string decryptedMessage = caesarCipherWithKey.Decrypt(encryptedMessage);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}

{
    string encryptedMessage = vigenereCipher.Encrypt(message);
    string decryptedMessage = vigenereCipher.Decrypt(encryptedMessage);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}

{
    var rsaKeyGenerator = new RSAKeyGenerator();
    var keyPair = rsaKeyGenerator.GenerateKeyPair();
    var encryptedMessage = rsa.Encrypt(message, keyPair.PublicKey);
    var decryptedMessage = rsa.Decrypt(encryptedMessage, keyPair.PrivateKey);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}

{
    string encryptedMessage = rc4.Encrypt(message);
    string decryptedMessage = rc4.Decrypt(encryptedMessage);

    Console.WriteLine(encryptedMessage);
    Console.WriteLine(decryptedMessage);
}
