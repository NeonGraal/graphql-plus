using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using GqlPlus.Abstractions;
using GqlPlus.Structures;

namespace GqlPlus;

public static class GeneralHelpers
{
  public static Dictionary<TKey, TValue> DictWith<TKey, TValue>(this TKey key, TValue value)
    where TKey : notnull
    => new() { [key] = value };

  public static string[]? FlagNames<TEnum>(this TEnum flagValue)
    where TEnum : Enum
  {
    Type type = typeof(TEnum);
    if (!type.GetCustomAttributes<FlagsAttribute>().Any()) {
      return null;
    }

    int flags = (int)(object)flagValue;
    List<string> result = [];

    foreach (object? value in Enum.GetValues(type)) {
      int flag = (int)value;
      if (flag.IsSingleFlag() && (flags & flag) == flag) {
        result.Add(Enum.GetName(type, flag));
      }
    }

    return [.. result];
  }

  public static int NullHashCode<T>(this T? value)
    => value?.GetHashCode() ?? 0;

  public static bool NullEqual(this decimal? left, decimal? right)
    => left is null && right is null
    || left is not null && left == right;

  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && right is not null && left.Equals(right);

  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    if (value is null) {
      throw new ArgumentNullException(expression);
    }

    return value;
  }

  public static string TrueFalse(this bool value)
    => value ? "true" : "false";

  public static string TrueFalse(this bool? value)
    => value is null ? "" : value == true ? "true" : "false";

  public static string Show(this IGqlpAbbreviated? abbr)
  {
    if (abbr is null) {
      return "";
    }

    using StringWriter sw = new();
    int indent = 0;
    string[] begins = ["(", "{", "[", "<"];
    string[] ends = [")", "}", "]", ">"];
    foreach (string? field in abbr.GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field!);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field!);
      } else {
        Write(field!);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (int i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }
}
