namespace GqlPlus.Convert.Plain;

internal static class PlainTestHelpers
{
  internal static IConvertTestsBase Converters { get; } = new PlainConverters();

  internal static Func<string?, string[]> Tagged(this string tag, string prefix = "=")
    => value => string.IsNullOrWhiteSpace(tag) ?
      string.IsNullOrEmpty(value)
        ? []
        : [$"{prefix}{value}"]
      : [$"{prefix}[{tag}]{value}"];

  internal static string[] BlockList<T>(this T[]? list, Func<T?, string[]> mapper, string listTag)
    => list is null ? []
      : [.. list
        .SelectMany((v, idx) => mapper(v)
          .Select(t => $".{idx}" + t))
          .SelectMany(listTag.Tagged(""))];

  internal static string[] BlockMap<T>(this MapPair<T>[]? map, Func<T?, string[]> mapper, string mapTag, string keyTag)
    => map is null ? []
      : [.. map
        .OrderBy(kv => kv.Key, StringComparer.Ordinal)
        .SelectMany(v => mapper(v.Value)
          .Select(t => keyTag.Tagged(":")(v.Key)[0] + t))
          .SelectMany(mapTag.Tagged(""))];

  private sealed class PlainConverters
    : IConvertTestsBase
  {
    public Structured ConvertFrom(string[] input)
      => input.FromPlain();
    public string[] ConvertTo(Structured model)
      => model.ToPlain(false);
  }
}
