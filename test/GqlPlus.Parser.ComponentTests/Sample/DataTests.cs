using System.Text.RegularExpressions;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public partial class DataTests
  : SampleChecks
{
  [Fact]
  public void VerifySchemaDataKeys()
  {
    IEnumerable<string> duplicateKeys = SchemaValidData.All
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.ShouldBeEmpty();
  }

  private static readonly Regex s_vowels = Vowels();

  private static string Abbreviate(string word)
  {
    string abbr = s_vowels.Replace(word, "");
    if (abbr.Length > 4) {
      abbr = abbr[..4];
    }

    return $"{word} -> {abbr}";
  }

  [Fact]
  public void VerifySchemaAbbreviations()
  {
    IEnumerable<string> duplicateKeys = SchemaValidData.All
      .SelectMany(TitleWords)
      .Distinct()
      .Where(w => w.Length > 5 && !Abbreviations.ContainsKey(w))
      .Select(Abbreviate);

    duplicateKeys.ShouldBeEmpty();
  }

  [GeneratedRegex("[aeiou]", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-NZ")]
  private static partial Regex Vowels();
}
