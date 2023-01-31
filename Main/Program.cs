
using ClassicalCiphers;

CaesarCipher caesarCipher = new CaesarCipher(3);
AtbashCipher atbashCipher = new AtbashCipher();
CaesarCipherWithKey caesarCipherWithKey = new CaesarCipherWithKey(3, "hola");
VigenereCipher vigenereCipher = new VigenereCipher("cake");

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
