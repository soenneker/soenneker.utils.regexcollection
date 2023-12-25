[![](https://img.shields.io/nuget/v/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.regexcollection/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.regexcollection/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.RegexCollection
### A collection of regular expressions that are generated at compile time

## Installation

```
dotnet add package Soenneker.Utils.RegexCollection
```

## Usage

```csharp
string spacesToDashes = RegexCollection.Spaces().Replace("hello there", "-");
// "hello-there"
```