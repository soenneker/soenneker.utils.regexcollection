[![](https://img.shields.io/nuget/v/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.regexcollection/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.regexcollection/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.RegexCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.RegexCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.regexcollection/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.regexcollection/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.RegexCollection
### A collection of regular expressions that are generated at compile time

## Installation

```
dotnet add package Soenneker.Utils.RegexCollection
```

## Usage

```csharp
using Soenneker.Utils.RegexCollection;

string spacesToDashes = RegexCollection.Spaces().Replace("hello there", "-");
// "hello-there"
```

The methods return source-generated `Regex` instances and are safe to reuse across calls and
threads. They do not use runtime pattern compilation.

## Available patterns

### Text cleanup

- `Spaces()` matches one .NET `\s` whitespace character at a time, including tabs and line breaks—not only ASCII spaces.
- `AlphaNumericAndDashUnderscore()` matches characters outside lowercase ASCII `a-z`, digits, whitespace, `_`, and `-`. Uppercase letters are removed unless the caller normalizes case first.
- `DoubleOccurrencesOfDashUnderscore()` matches a run of two or more dash/underscore characters, including mixed runs such as `-_`.

```csharp
string slug = input.ToLowerInvariant();
slug = RegexCollection.AlphaNumericAndDashUnderscore().Replace(slug, "");
slug = RegexCollection.Spaces().Replace(slug, "-");
slug = RegexCollection.DoubleOccurrencesOfDashUnderscore().Replace(slug, "-");
```

### URLs and hostnames

- `Url()` finds text beginning with `http://`, `https://`, or `www.` and continues until whitespace or a square bracket. It is an extractor, not full URI validation.
- `UriLastSegment()` requires an absolute `scheme://` form with a non-empty final path segment. Group 1 contains the URI prefix before that segment, group 2 the slash and final segment, and group 3 the remaining query/fragment text.
- `DnsHostname()` validates a multi-label ASCII hostname with an alphabetic TLD of at least two letters. It rejects single-label hosts, a trailing root dot, underscores, Unicode IDNs, and punycode TLDs containing hyphens.

Use `Uri.TryCreate`, `IdnMapping`, or a DNS-aware validator when those broader semantics are needed.

### Structured text

- `Spintax()` matches `{{ RANDOM | ... }}` and captures all option text in group 1; it does not split options or choose one.
- `CityStatePostal()` captures city, two-letter state text, and a US five-digit or ZIP+4 value in groups 1–3. It checks shape only, not whether the city, state, or ZIP exists.
- `MarkdownCodeFence()` matches an opening triple-backtick fence only at the beginning of the entire input. Its optional language identifier accepts ASCII letters only, and trailing `\s*` can consume whitespace following the fence.

None of these patterns sanitize untrusted input for HTML, SQL, shell commands, filesystem paths,
or network access. Apply validation and encoding appropriate to the eventual sink.
