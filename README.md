# Cipher Strategy Pattern Project

This project demonstrates the use of classic encryption algorithms implemented with various **design patterns** in C#. It's designed for educational purposes, helping understand both cryptography and software architecture patterns.

## Features

- **Playfair Cipher**  
- **Winston Cipher**  
- **Vigenère Cipher**  

## Design Patterns Used

| Pattern     | Description |
|-------------|-------------|
| **Strategy** | All ciphers implement a common `ICipherStrategy` interface to support interchangeable algorithms. |
| **Factory Method** | `CipherFactoryMethod` dynamically creates cipher instances based on type. |
| **Command** | Each cipher can be wrapped in a command and executed via an invoker. |
| **Singleton** | `ConsoleLogger` ensures a single logging instance across the app. |
| **Decorator** | `DebugCipherDecorator` adds logging around encryption/decryption steps. |

## Project Structure

```
/Core
    ICipherStrategy.cs
    CipherContext.cs
    ConsoleLogger.cs
    CommandInvoker.cs
    ...
/Ciphers
    PlayfairCipherStrategy.cs
    VigenereCipherStrategy.cs
    WinstonCipherStrategy.cs
    CaesarCipherStrategy.cs
/Factory
    CipherFactoryMethod.cs
/Decorators
    DebugCipherDecorator.cs
```

## Example Output

```
=== Playfair Cipher ===
[INFO] Running playfair cipher...
Encrypted: LZNVKQ...
Decrypted: HELLO...
Cleaned Decrypted: HELLO WORLD

[INFO] OK
```

## Requirements

- .NET Core or .NET Framework
- C# 9.0 or higher (for target-typed `new()` and nullable reference types)

## How to Use

```bash
git clone https://github.com/yourusername/cipher-strategy-pattern.git
cd cipher-strategy-pattern
dotnet build
dotnet run
```

## Purpose

This project was developed to **explore and understand design patterns** in the context of cryptographic algorithms. Great for students or developers practicing clean architecture in C#.
