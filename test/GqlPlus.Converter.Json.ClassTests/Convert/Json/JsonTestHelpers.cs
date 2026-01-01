using System.Runtime.CompilerServices;
using System.Text.Json;
using Xunit.Sdk;

namespace GqlPlus.Convert.Json;

internal static class JsonTestHelpers
{
  internal static IConvertTestsBase Indented { get; } = new JsonConverters();
  internal static IConvertTestsBase Unindented { get; } = new JsonConverters(RenderJson.Unindented);

  internal static string Surround(this string str, string open, string close, string by = "")
    => $"{open}{by}{str}{by}{close}";

  internal static string Internal(this string? value, string sep = ":", string suffix = "", [CallerArgumentExpression(nameof(value))] string? valueTag = default)
    => $"\"${valueTag}\"{sep}{value}{suffix}";
  internal static string WithUnindentedValue(this string tag, string? value)
    => tag
      .JsonValue()
      .WithValue(value, ":")
      .Surround("{", "}", "");
  internal static Func<string?, string> AsUnindentedValue(this string tag, string by = " ")
    => value => tag
      .JsonValue()
      .WithValue(value.JsonValue(), ":")
      .Surround("{", "}", by);
  internal static Func<string?, string> AsKeyTaggedValue(this string tag, string keyTag)
    => value => tag
      .WithValue(value.JsonValue(), ":")
      .Prepend(keyTag.Internal(suffix: ","))
      .Surround("{", "}", "");
  internal static string[] WithValue(this string valueTag, string? value, string sep)
    => [value.Internal(sep, ","), valueTag.Internal(sep)];
  internal static string[] WithIndentedValue(this string tag, string? value)
    => ["{", .. tag.JsonValue().WithValue(value, ": ").Indent(), "}"];
  internal static Func<string?, string[]> AsIndentedValue(this string tag, string keyTag)
    => value => ["{",
      .. tag.JsonValue()
        .WithValue(value.JsonValue(), ": ")
        .PrependWith(keyTag, keyTag.Internal(": ", suffix: ","))
        .Indent(),
      "}"];

  internal static string JsonValue(this string? value)
    => value.Quoted('"');

  internal static string AsUnindentedList(this string[] values)
    => values.AsUnindentedList(JsonValue, ", ");
  internal static string AsUnindentedList<T>(this T[] values, Func<T?, string> mapper, string by = ",")
    => values.Surround("[", "]", mapper, by);
  internal static string AsUnindentedList<T>(this T[] values, Func<T?, string> mapper, string listTag, string keyTag = "")
    => new string[] { "\"$list\":" + values.AsUnindentedList(mapper), listTag.Internal() }
      .PrependWith(keyTag, keyTag.Internal())
      .RemoveEmpty().Surround("{", "}", ",");

  internal static string AsUnindentedMap(this MapPair<string>[] values)
    => values.AsUnindentedMap(JsonValue);
  internal static string AsUnindentedMap<T>(this MapPair<T>[] values, Func<T?, string> mapper, string mapTag = "", string keyTag = "")
    => values
    .OrderBy(v => v.Key, StringComparer.Ordinal)
    .Select(v => JsonValue(v.Key) + ":" + mapper(v.Value))
    .PrependWith(mapTag, mapTag.Internal())
    .PrependWith(keyTag, keyTag.Internal())
    .Surround("{", "}", ",");

  internal static string[] AsIndentedList<T>(this T[] values, Func<T?, string[]> mapper, string indent = "  ")
    => values.Select(mapper).ToArray().Indent(indent).AddComma("[", "]");
  internal static string[] AsIndentedList<T>(this T[] values, Func<T?, string[]> mapper, string listTag, string keyTag = "")
    => new string[][] {
    [.. values.Select(mapper).ToArray().Indent("  ").AddComma("\"$list\": [", "]")],
    [listTag.Internal(": ")]
    }
    .PrependWith(keyTag, [keyTag.Internal(": ")])
    .Indent("  ")
    .AddComma("{", "}");

  internal static string[] AsIndentedMap(this MapPair<string>[] values)
    => values.AsIndentedMap(v => [JsonValue(v)]);
  internal static string[] AsIndentedMap<T>(this MapPair<T>[] values, Func<T?, string[]> mapper, string mapTag = "", string keyTag = "")
    => values
    .OrderBy(v => v.Key, StringComparer.Ordinal)
    .Select(v => mapper(v.Value).PrefixFirst(JsonValue(v.Key) + ": ").ToArray())
    .PrependWith(mapTag, [mapTag.Internal(": ")])
    .PrependWith(keyTag, [keyTag.Internal(": ")])
    .Indent("  ")
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
      => input.FromJson();
    public string[] ConvertTo(Structured model)
      => model.ToJson(options).ToLines();
  }
}
