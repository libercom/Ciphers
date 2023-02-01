# Symmetric ciphers

### Course: Cryptography & Security

### Author: Vasile Ignat

---

## Theory

which the same secret key is used for both encryption and decryption. The security of symmetric ciphers relies on the secrecy of the shared key. If the key is known to an attacker, the attacker can easily decrypt the ciphertext.

Some common examples of symmetric ciphers include the Advanced Encryption Standard (AES), Blowfish, Data Encryption Standard (DES), and the International Data Encryption Algorithm (IDEA). Symmetric ciphers are generally faster and more efficient than asymmetric ciphers, but they require the secure exchange of the shared key between the communicating parties, which can be a challenge in practice.

In symmetric cryptography, encryption and decryption algorithms use the same key to transform plaintext into ciphertext and vice versa. The key is used as input for both algorithms and the encryption and decryption process is reciprocal. This means that the decryption process is just the reverse of the encryption process.

There are two main types of symmetric ciphers: block ciphers and stream ciphers. Block ciphers encrypt data in fixed-sized blocks while stream ciphers encrypt data one bit or byte at a time. Symmetric ciphers are widely used in many applications, including secure communication, data storage, and digital signatures.

## Objectives:

1. Get familiar with the symmetric cryptography, stream and block ciphers.

2. Implement an example of a stream cipher.

3. Implement an example of a block cipher.

4. The implementation should, ideally follow the abstraction/contract/interface used in the previous laboratory work.

5. Please use packages/directories to logically split the files that you will have.

6. As in the previous task, please use a client class or test classes to showcase the execution of your programs.

## Implementation description

The constructor initializes the algorithm by generating the \_s and \_t arrays. The \_s array is a sequence of numbers from 0 to 255, and the \_t array is a sequence of bytes obtained from the key argument. The \_s and \_t arrays are then used to initialize the state of the algorithm, which is an array state of 256 bytes.

```c#
public RC4(string key)
{
    var keyBytes = Encoding.UTF8.GetBytes(key);

    for (int i = 0; i < 256; i++)
    {
        _s[i] = (byte)i;
    }

    for (int i = 0; i < 256; i++)
    {
        _t[i] = keyBytes[i % 4];
    }

    int j = 0;

    for (int i = 0; i < 256; i++)
    {
        j = (j + _s[i] + _t[i]) % 256;

        byte temp = _s[i];

        _s[i] = _s[j];
        _s[j] = temp;
    }
}
```

The Encrypt method takes a message as a string argument and returns the encrypted message as a string. The encryption process uses the state array, which is updated for each character in the message, to generate the encrypted message by applying xor on each character with a value obtained from the state array.

```c#
public string Encrypt(string message)
{
    int i = 0;
    int j = 0;

    string encryptedMessage = "";
    byte[] state = new byte[256];

    for (int x = 0; x < 256; x++)
    {
        state[x] = _s[x];
    }

    for (int x = 0; x < message.Length; x++)
    {
        i = (i + 1) % 256;
        j = (j + state[i]) % 256;

        byte temp1 = state[i];

        state[i] = state[j];
        state[j] = temp1;

        int temp2 = (state[i] + state[j]) % 256;
        int encryptedCharacter = ((int)message[x] ^ state[temp2]);

        encryptedMessage += (char)encryptedCharacter;
    }

    return encryptedMessage;
}
```

The Decrypt method returns the result of calling the Encrypt method on the given encrypted message.

```c#
public string Decrypt(string message)
{
    return Encrypt(message);
}
```
