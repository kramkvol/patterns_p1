# Cipher Strategy Pattern Project

This project demonstrates the use of classic encryption algorithms implemented with various **design patterns** in C#. It's designed for educational purposes, helping understand both cryptography and software architecture patterns.

## Features

- **Playfair Cipher**  
- **Winston Cipher**  
- **Vigenère Cipher**  

## Design Patterns Used

| Pattern         | Description |
|------------------|-------------|
| **Strategy**     | Implemented via the `ICipherStrategy` interface, which all cipher classes (`PlayfairCipherStrategy`, `VigenereCipherStrategy`, `WinstonCipherStrategy`, `CaesarCipherStrategy`) implement. This allows flexible switching between encryption algorithms. |
| **Factory Method** | The `CipherFactoryMethod` class dynamically creates cipher instances based on a provided string type (`"playfair"`, `"winston"`, `"vigenere"`, `"caesar"`), encapsulating object creation. |
| **Command**       | Commands are implemented through `ICipherCommand` and executed using the `CommandInvoker`. Each encryption/decryption task can be wrapped as a command for better task management and flexibility. |
| **Singleton**     | The `ConsoleLogger` class ensures only one instance of the logger is used throughout the application using the Singleton pattern. |
| **Decorator**     | The `DebugCipherDecorator` wraps any `ICipherStrategy` and adds logging functionality before and after encryption or decryption, without modifying the original logic. |

## Project Structure

```
/Command
    CommandInvoker.cs
    ICipherCommand.cs
    RunCipherCommand.cs
/Decorator
    DebugCipherDecorator.cs
/FactoryMethod
    CipherFactoryMethod.cs
/Singleton
    ConsoleLogger.cs
    ILogger.cs
/Strategy
    /Context
            CipherContext.cs
    /Interfaces
            ICipherStrategy.cs
    /Utils
        CipherTextPreprocessor.cs
        CipherTableBuilder.cs
    PlayfairCipherStrategy.cs
    VigenereCipherStrategy.cs
    WinstonCipherStrategy.cs
/App.config
/Program.cs
```

## Example Input

```
static void Main(string[] args)
{
    string abc = "abcdefghijklmnopqrstuvwxyz";
    int rows = 5, cols = 5;
    string message = "hello world!";
    var logger = ConsoleLogger.Instance;

    var invoker = new CommandInvoker();
    invoker.AddCommand(new RunCipherCommand("Playfair", abc, rows, cols, message, "strong", null, logger));
    invoker.AddCommand(new RunCipherCommand("Winston", abc, rows, cols, message, "strong", "cipher", logger));
    invoker.AddCommand(new RunCipherCommand("Vigenere", abc, 0, 0, message, "key", null, logger));

    invoker.RunAll();
    Console.ReadKey();
}
```

## Example Output

```
[INFO] Running Playfair cipher...
[CHARPTER] Cipher Debug Info:
Alphabet      : abcdefghijklmnopqrstuvwxyz
Table size    : 5 x 5
Original Msg  : hello world!
Key 1         : strong
Cleankey1     : strongabcdefhiklmpquvwxyz
[CHARPTER] Bigrams:
h e | l x | l o | w o | r l | d z |
[CHARPTER] Table for key 'strong':
s t r o n
g a b c d
e f h i k
l m p q u
v w x y z
[RESULT] Encrypted: ifpvqsytspkn
[RESULT] Decrypted: helxloworldz
[RESULT] Cleaned Decrypted: helloworld
[SUCCESS] Playfair cipher completed successfully.

[INFO] Running Winston cipher...
[CHARPTER] Cipher Debug Info:
Alphabet      : abcdefghijklmnopqrstuvwxyz
Table size    : 5 x 5
Original Msg  : hello world!
Key 1         : strong
Key 2         : cipher
Cleankey1     : strongabcdefhiklmpquvwxyz
Cleankey2     : cipherabdfgklmnoqstuvwxyz
[CHARPTER] Bigrams:
h e | l x | l o | w o | r l | d z |
[CHARPTER] Table for key 'strong':
s t r o n
g a b c d
e f h i k
l m p q u
v w x y z
[CHARPTER] Table for key 'cipher':
c i p h e
r a b d f
g k l m n
o q s t u
v w x y z
[RESULT] Encrypted: hcuxuuyurlgv
[RESULT] Decrypted: helxloworldz
[RESULT] Cleaned Decrypted: helloworld
[SUCCESS] Winston cipher completed successfully.

[INFO] Running Vigenere cipher...
[CHARPTER] Cipher Debug Info:
Alphabet      : abcdefghijklmnopqrstuvwxyz
Table size    : 26 x 26
Original Msg  : hello world!
Key 1         : key
Cleankey1     : keykeykeyk
[CHARPTER] Table for key 'key':
a b c d e f g h i j k l m n o p q r s t u v w x y z
b c d e f g h i j k l m n o p q r s t u v w x y z a
c d e f g h i j k l m n o p q r s t u v w x y z a b
d e f g h i j k l m n o p q r s t u v w x y z a b c
e f g h i j k l m n o p q r s t u v w x y z a b c d
f g h i j k l m n o p q r s t u v w x y z a b c d e
g h i j k l m n o p q r s t u v w x y z a b c d e f
h i j k l m n o p q r s t u v w x y z a b c d e f g
i j k l m n o p q r s t u v w x y z a b c d e f g h
j k l m n o p q r s t u v w x y z a b c d e f g h i
k l m n o p q r s t u v w x y z a b c d e f g h i j
l m n o p q r s t u v w x y z a b c d e f g h i j k
m n o p q r s t u v w x y z a b c d e f g h i j k l
n o p q r s t u v w x y z a b c d e f g h i j k l m
o p q r s t u v w x y z a b c d e f g h i j k l m n
p q r s t u v w x y z a b c d e f g h i j k l m n o
q r s t u v w x y z a b c d e f g h i j k l m n o p
r s t u v w x y z a b c d e f g h i j k l m n o p q
s t u v w x y z a b c d e f g h i j k l m n o p q r
t u v w x y z a b c d e f g h i j k l m n o p q r s
u v w x y z a b c d e f g h i j k l m n o p q r s t
v w x y z a b c d e f g h i j k l m n o p q r s t u
w x y z a b c d e f g h i j k l m n o p q r s t u v
x y z a b c d e f g h i j k l m n o p q r s t u v w
y z a b c d e f g h i j k l m n o p q r s t u v w x
z a b c d e f g h i j k l m n o p q r s t u v w x y
[RESULT] Encrypted: rijvsuyvjn
[RESULT] Decrypted: helloworld
[RESULT] Cleaned Decrypted: helloworld
[SUCCESS] Vigenere cipher completed successfully.
```

## How to Use

```
git clone https://github.com/kramkvol/CiphersWithPatterns.git
cd cipher-strategy-pattern
dotnet build
dotnet run
```
