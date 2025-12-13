using Xunit.Sdk;

namespace GqlPlus.Convert;

internal static class PlainTestHelpers
{
  internal static IConvertTestsBase Converters { get; } = new PlainConverters();

  internal static Func<string?, string[]> Tagged(this string tag, string prefix = "=")
    => value => [string.IsNullOrWhiteSpace(tag)
      ? prefix + value.IfWhiteSpace()
      : $"{prefix}({tag}){value}"];

  internal static string[] BlockList<T>(this T[]? list, Func<T?, string[]> mapper)
    => list is null ? []
      : [.. list
        .SelectMany((v, idx) => mapper(v)
          .Select(t => $".{idx}" + t))];

  internal static string[] BlockMap<T>(this MapPair<T>[]? map, Func<T?, string[]> mapper, string mapTag = "")
    => map is null ? []
      : [.. map
        .OrderBy(kv => kv.Key, StringComparer.Ordinal)
        .SelectMany(v => mapper(v.Value)
          .Select(t => ":" + v.Key + t))
          .SelectMany(mapTag.Tagged(""))];

  private sealed class PlainConverters
    : IConvertTestsBase
  {
    public Structured ConvertFrom(string[] input)
      => throw SkipException.ForSkip("Plain Deserialize not implemented (yet)");
    public string[] ConvertTo(Structured model)
      => model.ToPlain(false);
  }
}
