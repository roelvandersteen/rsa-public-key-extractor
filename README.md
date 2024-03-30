# RSA Public Key Extractor

This is a small .NET Core CLI tool that extracts the modulus and public exponent from an RSA private key in PEM format.

## Usage

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Running the Tool

1. Clone this repository to your local machine:

```bash
git clone https://github.com/roelvandersteen/rsa-public-key-extractor.git
```

2. Navigate to the project directory:

```bash
cd rsa-public-key-extractor
```

3. Build the project:

```bash
dotnet build
```

4. Run the tool with the path to your private key file:

```bash
dotnet run -- <private_key_file.pem>
```

Replace `<private_key_file.pem>` with the path to your RSA private key file in PEM format.

## Example

```bash
dotnet run -- private_key.pem
```

This will output the base64-encoded modulus and public exponent extracted from the private key.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
