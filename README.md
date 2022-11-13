<a name="readme-top"></a>

# Encryption on 4th School period

Encryption symmetric, asymmetric, and encoding. 


## Description

This solution contains all the assignment we did in the encryption course on ZBC Ringsted DK.
The concept is to create cSharp libraries for each domain logic, to reuse or the quickly remember how the
specific encryption/encoding works. 

## Assignments

<!-- TABLE OF CONTENTS -->
<details>
  <ol>
    <li>
      <a href="#Encoding-Decoding-Hashing-Library">Hashing, simple, salty and secret!</a>
      <ul>
        <li><a href="#Key-Generator-Library">Key Generator Library</a></li>
        <li><a href="#-ASP.NET-Core-6-MVC">MVC as UI for Hashing</a></li>
      </ul>
    </li>
    <li>
      <a href="#Ceaser-Cipher-Library">Caeser, only a true roman can read it!</a>
      <ul>
        <li><a href="#ASP.NET-Core-6-MVC">MVC as UI for Hashing</a></li>
      </ul>
    </li>
    <li>
      <a href="#ASP.NET-Core-6-MVC">Secure Password uses hashing lib, data lib and MVC as UI</a>
      <ul>
        <li><a href="#Encoding/Decoding-Hashing-Library">Hashing</a></li>
        <li><a href="#Key-Generator-Library">Key Generator Library</a></li>
        <li><a href="#Entity-Framework-Core-Data-Project">EF Core MSSQL</a></li>
        <li><a href="#ASP.NET-Core-6-MVC">MVC as UI for Hashing</a></li>
      </ul>
    </li>
    <li>
      <a href="#Symmetric-Encryption-Library">Symmetric Algorithm</a>
      <ul>
        <li><a href="#Key-Generator-Library">Key Generator Library</a></li>
      </ul>
    </li>
    <li>
      <a href="#Asymmetric-Encryption-Library">Asymmetric Algorithm</a>      
    </li>
    <li>
      <a href="#-Asymmetric-Encryption-Library">Hybrid Encryption</a>
      <ul>
        <li><a href="#WebSocket-Server/Client-PoC">Websocket hybrid PoC</a></li>
        <li><a href="#.NET-6-Core-Web-Project-SignalR-/server">SignalR Hub</a></li>
        <li><a href="#.NET-6-Maui-Project-SignalR-/client">SignalR Client</a></li>
      </ul>    
    </li>
  </ol>
</details>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<hr>

### Encoding Decoding Hashing Library

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Hashing">Hashing Repo</a> <br>
In this project you will find 3 types of encoding.
    * Simple Hashing
    * Hashing with salt (and pepper)
    * Hashing with key (HMAC)


### Key Generator Library

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.KeyGenerator">Random Key Repo</a> <br>
This class library is pretty simple, it contains a RandomNumberGenerator used to generate keys in specific size (byte size)


### Ceaser Cipher Library

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.CaesarCipher">Caesar Repo</a> <br>
Fun little assignment that uses the idea of how the romans encrypted there messages


### Symmetric Encryption Library

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Symmetric">Summetric Repo</a> <br>
In the libraries we de two different types of symmetric algorithms, TripleDES and AES encryption.
    * TripleDES (used by visa card etc.)
    * AES

Currently no UI for this, look in console Application and Unit tests


### Asymmetric Encryption Library

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Symmetric">Summetric Repo</a> <br>
This project uses the RSA Algorithm.
    * Generate Keysets
    * Encrypt
    * Decrypt

Currently no UI for this, look in console Application and Unit tests

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<hr>

### Unit Test

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Test">Test Repo</a> <br>
Doing more test, needs to be practice, was fun to play with for testing the domain libraries
* Hashing
* Key Gen
* Symmetric
* Asymmetric
* Caeser

### Console Application

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Console">Console Repo</a> <br>
The primary ide is to quickly test code, and debug. This is used as a "playground"
Here are some examples of symmetric and asymmetric libraries in use.

### ASP.NET Core 6 MVC

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.MVC">MVC Repo</a> <br>
This project is used as the UI, currently Hash Encoding, Caeser and login site(secure login) is implemented.
Sadly I didn't have time to implement symmetric and asymmetric encryption.


### Entity Framework Core Data Project

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.Data">EF Core Repo</a> <br>
This project is used for login/user information in the Secure Password Assignment


### Hybrid Encryption

This project shows how hybrid encryption works en real, this is a mix of to project .NET 6 Webproject running SignalR Hub, and a .NET 6 MAUI running as client.
You can also find a PoC done in simple websocket running client/server from 2 .NET 6 Webproject. The combination of Asymmetric and symmetric encryption is top of the pop.

#### WebSocket Server/Client PoC

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.WebServer">Server PoC</a> <br>
* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.WebClient">Client PoC</a> <br>
This project is a PoC on hybrid encryption, this is the combination of asymmetric and symmetric encryption, and will simulate a real world example on
how hybrid encryption wokrs. Uses symmetric and asymmetric encryption.


#### .NET 6 Core Web Project SignalR /server

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.SignalRHub">Server SignalR Repo</a> <br>
Server running signalR, look in chathub. It would have been nice to implement a login function using hashing, like the login site in .NET MVC project
Uses symmetric and asymmetric encryption


#### .NET 6 Maui Project SignalR /client

* <a href="https://github.com/anit3k/H4_Encryption/tree/main/Encryption.MauiSecureChatApp">Client Maui SignalR Repo</a> <br>
Client running signal. First time looking at .NET Maui, surely not the last, fun project. Would have like to play a lot more on this one, but had no time.
Uses symmetric and asymmetric encryption

<p align="right">(<a href="#readme-top">back to top</a>)</p>
