using System.Text.RegularExpressions;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public partial class DataTests
  : SampleChecks
{
  [Fact]
  public void EnsureSampleDataKeysUnique()
  {
    IEnumerable<string> duplicateKeys = SchemaValidData.All
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.ShouldBeEmpty();
  }

  private const int AbbreviationLength = 4;
  private static readonly Regex s_vowels = Vowels();

  private static string Abbreviate(string word)
  {
    string abbr = word[0] + s_vowels.Replace(word[1..], "");
    if (abbr.Length > AbbreviationLength) {
      abbr = abbr[..AbbreviationLength];
    }

    return $"{word} -> {abbr}";
  }

  [Fact]
  public void VerifySampleNameAbbreviations()
  {
    IEnumerable<string> longWords = SchemaValidData.All
      .SelectMany(TitleWords)
      .Distinct()
      .Where(w => w.Length > AbbreviationLength + 1)
      .ToHashSet();

    IEnumerable<string> missing = longWords
      .Where(w => !Abbreviations.ContainsKey(w))
      .OrderBy(w => w)
      .Select(Abbreviate);

    IEnumerable<string> extra = Abbreviations.Keys
      .Except(longWords.Append("Input"))
      .OrderBy(w => w);

    longWords.ShouldSatisfyAllConditions(
      () => missing.ShouldBeEmpty(),
      () => extra.ShouldBeEmpty());
  }

  [GeneratedRegex("[aeiou]", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-NZ")]
  private static partial Regex Vowels();
}
