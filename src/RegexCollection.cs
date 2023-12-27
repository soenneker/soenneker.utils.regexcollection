using System.Text.RegularExpressions;

namespace Soenneker.Utils.RegexCollection;

/// <summary>
/// A collection of regular expressions that are generated at compile time.
/// </summary>
public partial class RegexCollection
{
    [GeneratedRegex(@"\s")]
    public static partial Regex Spaces();

    [GeneratedRegex(@"[^a-z0-9\s-_]")] 
    public static partial Regex AlphaNumericAndDashUnderscore();

    [GeneratedRegex(@"([-_]){2,}")]
    public static partial Regex DoubleOccurrencesOfDashUnderscore();

    [GeneratedRegex(@"([^:]+://[^?]+)(/[^/?#]+)(.*$)")]
    public static partial Regex UriLastSegment();

    [GeneratedRegex(@"(?:https?:\/\/|www\.)[^ \f\n\r\t\v\]\[]+\b")]
    public static partial Regex Url();
}