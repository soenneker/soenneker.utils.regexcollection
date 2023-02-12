[![](https://img.shields.io/nuget/v/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.regexcollection/main.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.regexcollection/actions/workflows/main.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)

# Soenneker.Utils.RegexCollection
### A collection of regular expressions that are generated at compile time (.NET 7+)

## Installation

```
Install-Package Soenneker.Utils.RegexCollection
```

## Usage

```csharp
string spacesToDashes = RegexCollection.Spaces().Replace("hello there", "-");
// "hello-there"
```