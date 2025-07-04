# Design Patterns and Architecture – Cipher Project

This project implements several classical encryption algorithms (Playfair, Winston, Vigenère) using a modular and extensible architecture based on well-established software design patterns. Below is an overview of the patterns used, where they are applied, and why they are necessary.

1. [Design Patterns and Architecture – Cipher Project](#-design-patterns-and-architecture--cipher-project)
   - [1. Strategy Pattern](#1-strategy-pattern)
   - [2. Decorator Pattern](#2-decorator-pattern)
   - [3. Factory Method Pattern](#3-factory-method-pattern)
   - [4. Command Pattern](#4-command-pattern)
   - [5. Singleton Pattern](#5-singleton-pattern)

2. [Core Architecture and Utility (Ciphers.Core)](#-core-architecture-and-utility-cipherscore)

3. [User Interface and Execution Flow](#user-interface-and-execution-flow)
   - [Console Mode](#console-mode)
   - [WinForms Mode](#winforms-mode)
)

3. [User Interface and Execution Flow](#user-interface-and-execution-flow)
   - [Console Mode](#console-mode)
   - [WinForms Mode](#winforms-mode)

---

## Design Patterns Used

### 1. **Strategy Pattern**

- **Where used:**  
  - `ICipherStrategy` (interface)  
  - `BaseCipherStrategy` (abstract base)  
  - `PlayfairCipherStrategy`, `WinstonCipherStrategy`, `VigenereCipherStrategy` (concrete implementations)

- **Why it's necessary:**  
  The Strategy pattern allows defining a family of encryption algorithms and encapsulating each one in its own class. This makes it easy to switch between ciphers at runtime without modifying the UI or execution code. Each cipher has a different internal logic (bigram-based, table-based, etc.), but shares a common interface, allowing interchangeable use.

---

### 2. **Decorator Pattern**

- **Where used:**  
  - `BaseCipherDecorator`  
  - `PlayfairCipherDecorator`, `VigenereCipherDecorator`, `WinstonCipherDecorator`

- **Why it's necessary:**  
  The Decorator pattern is used to extend the functionality of a cipher without altering its core behavior. Each decorator wraps a cipher strategy and adds:
    - Logging of internal steps (e.g., bigram transformations, table positions)
    - Clean formatting of tables and keys for debugging
  This allows detailed tracing of the encryption/decryption process without violating the Open/Closed Principle (i.e., changing core code).

---

### 3. **Factory Method Pattern**

- **Where used:**  
  - `CipherFactoryMethod.Create(...)`

- **Why it's necessary:**  
  The Factory Method centralizes the creation of cipher strategy objects. Instead of scattering object construction logic throughout the app, a single method decides which cipher to instantiate based on a string input. This:
    - Keeps the UI and command layers clean
    - Reduces coupling between layers
    - Simplifies input validation

---

### 4. **Command Pattern**

- **Where used:**  
  - `ICipherCommand` (interface)  
  - `BaseCipherCommand`, `Encrypt*/Decrypt*Command`  
  - `RunCipher`, `CommandInvoker`

- **Why it's necessary:**  
  The Command pattern turns encryption and decryption actions into objects.  
  This makes the code easier to manage and scale. Instead of handling logic in `if-else`, each command does one job:
  - `EncryptPlayfairCommand` encrypts using Playfair  
  - `DecryptWinstonCommand` decrypts using Winston  
  etc.

  `RunCipher` selects the correct command and passes it to `CommandInvoker`, which runs it.  
  This makes the code cleaner, avoids duplication, and simplifies adding new actions.

---

### 5. **Singleton Pattern**

- **Where used:**  
  - `ConsoleLogger.Instance`  
  - `UILogger.Instance`  
  - Also used in `UtilForText.ReadParameter` and `RunConsoleApp()`

- **Why it's necessary:**  
  Logging is needed throughout the application — in the console version, UI, decorators, and utility methods.  
  Both `ConsoleLogger` and `UILogger` use the Singleton pattern to ensure a single, shared logger instance across the app.  
  This prevents conflicting outputs, ensures consistent formatting, and simplifies access to logging from any component.  
  For example, `ConsoleLogger` is used in `UtilForText.ReadParameter()` and `RunConsoleApp()`, while `UILogger` is initialized once per form and reused in the UI workflow.

> Unlike `ConsoleLogger`, which initializes itself automatically, `UILogger` requires explicit initialization with a `CipherForm` instance, typically done during form construction.


---

## Core Architecture and Utility (Ciphers.Core)

### Components:
- **`ICipherStrategy`** – interface shared by all cipher strategies
- **`CipherContext`** – structural holder for strategy and mode (not actively used but supports Strategy-compliant architecture)
- **`UtilForText`** – provides text preprocessing:
  - filters input
  - generates bigrams
  - repeats key for Vigenère
- **`UtilForTables`** – table generation and lookup used in Playfair and Winston
- **`UtilForDecorator`** – printing tables and debug-formatting for decorators

---

## User Interface and Execution Flow

### Console Mode
- Chosen via `Program.cs`
- Uses `ConsoleLogger` and direct `CipherFactoryMethod` + `RunCipher` pipeline

### WinForms Mode
- `CipherForm.cs` builds the UI using `ComboBox`, `TextBox`, and `Button`
- Based on user input:
  - Cipher type and action are passed to `CipherFactoryMethod`
  - A logger (`UILogger`) is attached
  - A `RunCipher` object determines the command and executes it
- UI and logic are completely decoupled via interfaces and factory

---
