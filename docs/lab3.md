# Asymmetric ciphers

### Course: Cryptography & Security

### Author: Vasile Ignat

---

## Theory

Asymmetric ciphers, also known as public key cryptography, use two different keys for encryption and decryption. Unlike symmetric ciphers, which use the same key for both operations, the two keys in an asymmetric cipher are mathematically related, but distinct. One of the keys, called the public key, is intended to be shared publicly and can be used to encrypt messages. The other key, called the private key, is kept secret and is used to decrypt messages.

The use of two keys allows for a range of cryptographic applications, such as secure communication, digital signatures, and key exchange. In secure communication, the sender uses the recipient's public key to encrypt a message, which can only be decrypted with the recipient's private key. In digital signatures, the private key is used to sign a message, and the public key can be used to verify the signature. In key exchange, the two parties can use their public and private keys to securely agree on a shared key for use in symmetric encryption.

Some examples of asymmetric ciphers are RSA, Elliptic Curve Cryptography (ECC), and Diffie-Hellman. These ciphers are widely used for a variety of applications, including secure online transactions and secure communication over the Internet.

In summary, asymmetric ciphers offer a high degree of security and versatility compared to symmetric ciphers. They are a fundamental building block of modern cryptography and play a critical role in securing digital communications.

## Objectives:

1. Get familiar with the asymmetric cryptography mechanisms.
2. Implement an example of an asymmetric cipher.
3. As in the previous task, please use a client class or test classes to showcase the execution of your programs.

## Implementation description

The "Encrypt" method takes as input a string message and a public key and returns the encrypted message as a string. The method starts by converting the message string into a byte array. It then performs the modular exponentiation operation on each byte of the message using the public key's exponent and modulus. The encrypted bytes are then concatenated and returned as a string.

```c#
public string Encrypt(string message, RSAKey publicKey)
{
    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
    BigInteger[] encryptedBytes = Array.ConvertAll(messageBytes, b => BigInteger.ModPow(b, publicKey.Exponent, publicKey.Modulus));
    byte[] bytes = encryptedBytes.SelectMany(x => BitConverter.GetBytes((int)x)).ToArray();

    return Convert.ToBase64String(bytes);
}
```

The "Decrypt" method takes as input an encrypted message and a private key and returns the decrypted message as a string. The method first decodes the encrypted message into a byte array. The decryption is performed by performing modular exponentiation on each integer in the list using the private key's exponent and modulus. The decrypted bytes are then converted back into a string.

```c#
public string Decrypt(string message, RSAKey privateKey)
{
    byte[] bytes = Convert.FromBase64String(message);
    List<int> encryptedBytes = new List<int>();

    for (int i = 0; i < bytes.Length; i += sizeof(int))
    {
        encryptedBytes.Add(BitConverter.ToInt32(bytes, i));
    }

    BigInteger[] decryptedBytes = Array.ConvertAll(encryptedBytes.ToArray(), b => BigInteger.ModPow(b, privateKey.Exponent, privateKey.Modulus));
    byte[] decryptedMessage = decryptedBytes.SelectMany(x => x.ToByteArray()).ToArray();

    return Encoding.UTF8.GetString(decryptedMessage);
}
```

The RSAKey class, used as the input to the methods has two properties, "Exponent" and "Modulus". These two properties represent the public or private key used in the encryption or decryption process.

```c#
public class RSAKey
{
    public BigInteger Exponent { get; set; }
    public BigInteger Modulus { get; set; }
}
```

The RSAKeyGenerator class uses four constant values, p, q, e, and d, as the basis for generating the RSA key pair. The values of p and q are prime numbers and are used to calculate the modulus "n" of the key pair, which is equal to p \* q. The value of e is used as the public exponent and the value of d is used as the private exponent.

```c#
public class RSAKeyGenerator : IRSAKeyGenerator
{
    private const int p = 61;
    private const int q = 53;
    private const int e = 17;
    private const int d = 2753;

    public RSAKeyPair GenerateKeyPair()
    {
        var n = p * q;

        return new RSAKeyPair(e, d, n);
    }
}
```
