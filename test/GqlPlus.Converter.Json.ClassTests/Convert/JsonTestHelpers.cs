using System.Text.Json;
using Xunit.Sdk;

namespace GqlPlus.Convert;

internal static class JsonTestHelpers
{
  internal static IConvertTestsBase Indented { get; } = new JsonConverters();
  internal static IConvertTestsBase Unindented { get; } = new JsonConverters(RenderJson.Unindented);

  internal static string Surround(this string str, string open, string close, string by = "")
    => $"{open}{by}{str}{by}{close}";

  internal static string WithUnindentedValue(this string tag, string? value)
    => tag.WithValue(value, ":").Surround("{", "}", "");
  internal static Func<string?, string> AsUnindentedValue(this string tag, string by = " ")
    => value => tag.WithValue(value.JsonValue(), ":").Surround("{", "}", by);
  internal static string[] WithValue(this string tag, string? value, string sep)
    => [$"\"$tag\"{sep}\"{tag}\",", $"\"$value\"{sep}{value}"];
  internal static string[] WithIndentedValue(this string tag, string? value)
    => ["{", .. tag.WithValue(value, ": ").Indent(), "}"];
  internal static Func<string?, string[]> AsIndentedValue(this string tag)
    => value => ["{", .. tag.WithValue(value.JsonValue(), ": ").Indent(), "}"];

  internal static string JsonValue(this string? value)
    => value.Quoted('"');

  internal static string AsUnindentedList(this string[] values)
    => values.AsUnindentedList(JsonValue, ", ");
  internal static string AsUnindentedList<T>(this T[] values, Func<T?, string> mapper, string by = ",")
    => values.Surround("[", "]", mapper, by);

  internal static string AsUnindentedMap(this MapPair<string>[] values)
    => values.AsUnindentedMap(JsonValue);
  internal static string AsUnindentedMap<T>(this MapPair<T>[] values, Func<T?, string> mapper, string tag = "")
    => values
    .OrderBy(v => v.Key, StringComparer.Ordinal)
    .Select(v => JsonValue(v.Key) + ":" + mapper(v.Value))
    .PrependWith(tag, $"\"$tag\":\"{tag}\"")
    .Surround("{", "}", ",");

  internal static string[] AsIndentedList<T>(this T[] values, Func<T?, string[]> mapper, string indent = "  ")
    => values.Select(mapper).ToArray().Indent(indent).AddComma("[", "]");

  internal static string[] AsIndentedMap(this MapPair<string>[] values)
    => values.AsIndentedMap(v => [JsonValue(v)]);
  internal static string[] AsIndentedMap<T>(this MapPair<T>[] values, Func<T?, string[]> mapper, string tag = "")
    => values
    .OrderBy(v => v.Key, StringComparer.Ordinal)
    .Select(v => mapper(v.Value).PrefixFirst(JsonValue(v.Key) + ": ").Indent().ToArray())
    .PrependWith(tag, [$"  \"$tag\": \"{tag}\""])
    .AddComma("{", "}");

  internal static string[] AddComma(this IEnumerable<string[]> lines, string open, string close)
  {
    string[][] input = [.. lines];
    return [open, .. input.SkipLast(1).SelectMany(l => l.SuffixLast(",")), .. input.Last(), close];
  }

  internal static T[] PrependWith<T>(this IEnumerable<T> array, string value, T item)
    => string.IsNullOrWhiteSpace(value) ? [.. array] : [item, .. array];

  private sealed class JsonConverters(
    JsonSerializerOptions? options = null
  ) : IConvertTestsBase
  {
    public Structured ConvertFrom(string[] input)
      => throw SkipException.ForSkip("Json Deserialize not implemented yet");
    public string[] ConvertTo(Structured model)
      => model.ToJson(options).ToLines();
  }
}
