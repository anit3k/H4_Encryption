<a name="readme-top"></a>

# Encryption on 4th School period

Encryption symmetric and asymmetric, and encoding. 


## Description

This solution contains all the assignment we did in the encryption course on ZBC Ringsted DK.
The concept is to create cSharp libraries for each domain logic, to reuse or the quickly remember how the
specific encryption/encoding works. 

<hr>

### Encryption.Hashing Library

In this project you will find 3 types of encoding.
    * Simple Hashing
    * Hashing with salt (and pepper)
    * Hashing with key (HMAC)


### Key Generator Library

This class library is pretty simple, it contains a RandomNumberGenerator used to generate keys in specific size (byte size)


### Ceaser Cipher Library

Fun little assignment that uses the idea of how the romans encrypted there messages


### Symmetric Encryption Library

In the libraries we de two different types of symmetric algorithms, TripleDES and AES encryption.
    * TripleDES (used by visa card etc.)
    * AES


### Asymmetric Encryption Library

This project uses the RSA Algorithm.
    * Generate Keysets
    * Encrypt
    * Decrypt

<hr>

### Console Application

The primary ide is to quickly test code, and debug. This is used as a "playground"

### ASP.NET Core 6 MVC

This project is used as the UI

### Webserver and Webclient - WebSocket

This project is a PoC on hybrid encryption, this is the combination of asymmetric and symmetric encryption, and will simulate a real world example on
how hybrid encryption wokrs. 