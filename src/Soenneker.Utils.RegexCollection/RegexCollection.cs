using System.Text.RegularExpressions;

namespace Soenneker.Utils.RegexCollection;

/// <summary>
/// A collection of regular expressions that are generated at compile time.
/// </summary>
public partial class RegexCollection
{
    /// <summary>
    /// Generates a regex that matches any whitespace character.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object configured to match whitespace characters.</returns>
    /// <remarks>
    /// This regex can be used to find or split strings based on whitespace characters.
    /// It matches spaces, tabs, and any character that is considered a space in a regex pattern.
    /// </remarks>
    [GeneratedRegex(@"\s")]
    public static partial Regex Spaces();

    /// <summary>
    /// Generates a regex that matches characters that are not lowercase letters, digits, spaces, hyphens, or underscores.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object configured to exclude non-alphanumeric characters except for hyphens and underscores.</returns>
    /// <remarks>
    /// This regex is useful for sanitizing strings to contain only lowercase letters, digits, spaces, hyphens, and underscores.
    /// It can be used for inputs where special characters are not allowed, ensuring a certain level of data consistency.
    /// </remarks>
    [GeneratedRegex(@"[^a-z0-9\s-_]")] 
    public static partial Regex AlphaNumericAndDashUnderscore();

    /// <summary>
    /// Generates a regex that matches occurrences of two or more consecutive hyphens or underscores.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object configured to match sequences of two or more hyphens or underscores.</returns>
    /// <remarks>
    /// Ideal for validating or sanitizing strings to avoid double occurrences of hyphens or underscores,
    /// which is often a requirement in usernames, URLs, and other identifiers.
    /// </remarks>
    [GeneratedRegex(@"([-_]){2,}")]
    public static partial Regex DoubleOccurrencesOfDashUnderscore();

    /// <summary>
    /// Generates a regex that extracts the last segment of a URI along with the protocol, domain, and any query parameters.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object capable of extracting the last segment of a URI.</returns>
    /// <remarks>
    /// This regex is particularly useful for parsing URIs to extract the last path segment.
    /// It can be used in logging, monitoring, or any functionality that requires analysis or manipulation of URIs.
    /// </remarks>
    [GeneratedRegex(@"([^:]+://[^?]+)(/[^/?#]+)(.*$)")]
    public static partial Regex UriLastSegment();

    /// <summary>
    /// Generates a regex that matches URLs, including those starting with "http://", "https://", or "www.".
    /// </summary>
    /// <returns>A <see cref="Regex"/> object configured to match URLs.</returns>
    /// <remarks>
    /// This regex is suitable for extracting URLs from text. It matches URLs that begin with "http://", "https://", or "www."
    /// and continues until it encounters a space or a character that is typically not part of a URL.
    /// </remarks>
    [GeneratedRegex(@"(?:https?:\/\/|www\.)[^ \f\n\r\t\v\]\[]+\b")]
    public static partial Regex Url();

    /// <summary>
    /// Generates a regex that validates a DNS hostname.
    /// </summary>
    /// <returns>A <see cref="Regex"/> object configured to validate DNS hostnames.</returns>
    /// <remarks>
    /// This method produces a regex designed to match valid DNS hostnames according to the following criteria:
    /// - Hostnames may contain alphanumeric characters (a-z, A-Z, 0-9), and hyphens (-).
    /// - Each label (section of the hostname separated by ".") must start and end with an alphanumeric character.
    /// - Labels can be 63 characters long at most but must have at least one character.
    /// - The total length of the hostname can be up to 253 characters.
    /// - The top-level domain (TLD) must be at least two characters long and can only contain letters.
    /// 
    /// Note:
    /// - This regex does not support Internationalized Domain Names (IDNs) that contain characters outside the standard ASCII range.
    /// - The presence of a hyphen at the beginning or end of a label is not permitted, consistent with DNS naming rules.
    /// - Underscores (_) are not allowed, as they are not permitted in DNS hostnames, though they may appear in certain DNS records like TXT records.
    /// </remarks>
    [GeneratedRegex(@"^([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}$")]
    public static partial Regex DnsHostname();

    /// <summary>
    /// A compiled regex pattern to match common spintax format: 
    /// <code>{{ RANDOM | option1 | option2 | ... }}</code>. 
    /// This pattern captures multiple options separated by pipes (`|`) within 
    /// curly braces and the keyword 'RANDOM'.
    /// </summary>
    /// <returns>
    /// A <see cref="Regex"/> object that can be used to process and replace spintax 
    /// with random selections from the options.
    /// </returns>
    [GeneratedRegex(@"\{\{\s*RANDOM\s*\|\s*(.*?)\s*\}\}")]
    public static partial Regex Spintax();

    /// <summary>
    /// Generates a regular expression that matches a string containing a city, state abbreviation, 
    /// and a 5-digit or 9-digit postal code (ZIP code).
    /// </summary>
    /// <returns>
    /// A <see cref="Regex"/> object that matches strings formatted as "CityName StateAbbreviation PostalCode".
    /// Example: "Los Angeles CA 90001" or "Los Angeles CA 90001-1234".
    /// </returns>
    /// <remarks>
    /// The regular expression pattern:
    /// - Matches any city name followed by whitespace.
    /// - Expects a two-letter state abbreviation.
    /// - Matches a 5-digit postal code or a 9-digit postal code in the form "12345-1234".
    /// </remarks>
    [GeneratedRegex(@"^(.*)\s+([A-Za-z]{2})\s+(\d{5}(?:-\d{4})?)$")]
    public static partial Regex CityStatePostal();

    /// <summary>
    /// Provides a compiled regular expression that matches the opening of a Markdown-style code block fence.
    /// </summary>
    /// <returns>
    /// A <see cref="Regex"/> that matches code block markers of the form <c>```</c> followed optionally by a language identifier and a newline.
    /// For example: <c>```csharp</c>, <c>``` js</c>, or simply <c>```</c>.
    /// </returns>
    /// <remarks>
    /// The pattern used is <c>^```[a-zA-Z]*\s*\n?</c>, which matches from the beginning of a line:
    /// <list type="bullet">
    ///   <item><description><c>```</c> – the code block fence</description></item>
    ///   <item><description><c>[a-zA-Z]*</c> – optional language identifier</description></item>
    ///   <item><description><c>\s*</c> – optional whitespace</description></item>
    ///   <item><description><c>\n?</c> – optional newline</description></item>
    /// </list>
    /// </remarks>
    [GeneratedRegex(@"^```[a-zA-Z]*\s*\n?")]
    public static partial Regex MarkdownCodeFence();
}