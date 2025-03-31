**ZipCrack** - .NET console application to execute multithreaded brute-force and dictionary attacks on password protected ZIP files.

## Features

- **Brute Force Attack**: Cracks passwords by trying all possible combinations of characters.
- **Dictionary Attack**: Attempts to crack the password using a file of the most common possible passwords.
- **Multithreading**: Utilizes multiple threads to speed up the attack process.
- **Customizable Parameters**: Control the attack settings like minimum and maximum password length, characters to use, and how many threads you want to use.

## Usage

### Brute Force Attack

To perform a brute force attack, you can run the application with the following arguments:

- `--brute`: Indicates that you want to perform a brute force attack.
- `--min=4`: Minimum password length (in this case, 4 characters).
- `--max=8`: Maximum password length (in this case, 8 characters).
- `--chars=lu`: Specifies the character set to use.
Here's a list of possible character combinations to use:
`l` - lowercase letters only;
`u` - uppercase letters only;
`n` - numbers only;
`lu` - lowercase and uppercase letters;
`lun` - lowercase, uppercase letters and numbers;
`luns` - lowercase, uppercase letters, numbers and special characters;
- `--test.zip`: The path to the password-protected ZIP file.
- `--threads=8`: The number of threads to use for the attack.

### Dictionary Attack

To perform a dictionary attack using a list of predefined words, run the following:

- `--dict`: Indicates that you want to perform a dictionary attack.
- `--test.zip`: The path to the password-protected ZIP file.
- `--threads=8`: The number of threads to use for the attack.

***If unsure how many threads to use, leave `0`, the number of threads will be assigned based on your proccessor for optimum speed.***

## Getting Started

### 1. Clone the Repository

`git clone https://github.com/paplauskis/zipcrack.git`

### 2. Navigate to the project directory

`cd zipcrack/`

### 3. If you want to execute a dictionary attack, add your .txt file into project root folder and name it TEST.txt

### 4. Restore dependencies

`dotnet restore`

### 5. Build the app and run it

`dotnet build`   
`dotnet run <your arguments>`
