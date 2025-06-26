using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions;

namespace GqlPlus.Structures;

public static class StructureHelper
{
  public static Structured Encode<T>(this IEnumerable<T> list, Func<T, Structured> mapper, string? tag = null, bool flow = false)
    => new(list.Select(mapper), tag, flow);

  public static Structured Encode(this IEnumerable<string> list, string? tag = null, bool flow = false)
    => list.Encode(i => new(i), tag, flow);

  public static Structured Encode<T>(this IMap<T> groups, Func<T, Structured> mapper, string? tag = null, bool flow = false)
    => new(groups.ToDictionary(k => new StructureValue(k.Key), v => mapper(v.Value)), tag, flow);

  public static Structured Encode(this IMap<Structured> groups, string? tag = null, bool flow = false)
    => groups.Encode(v => v, tag, flow);

  public static Structured Encode(this ITokenMessages errors)
    => new(errors.Select(Encode), "_Errors");

  private static Structured Encode(ITokenMessage error)
    => new Map<Structured>() { ["_message"] = error.Message }.Encode("_Error")
      .AddIf(error.Kind is TokenKind.Start or TokenKind.End,
        onFalse: r => r.Add("_at", EncodeAt(error)))
      .AddEnum("_kind", error.Kind);

  private static Structured EncodeAt(ITokenAt at)
    => new Map<Structured>() {
      ["_col"] = at.Column,
      ["_line"] = at.Line,
    }.Encode("_At", true);

  public static string TypeTag(this Type type)
  {
    string result = "_" + type.ThrowIfNull().Name.Replace("Model", "");

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  public static Structured EncodeEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.ToString(), value.GetType().TypeTag());

  internal static bool BothValued([NotNullWhen(true)] this string? left, [NotNullWhen(true)] string? right)
    => !string.IsNullOrEmpty(left) && !string.IsNullOrEmpty(right);

  internal static bool BothValued<T>([NotNullWhen(true)] this T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;

  internal static bool BothAny<T>([NotNullWhen(true)] this IEnumerable<T>? left, [NotNullWhen(true)] IEnumerable<T>? right)
    => left.BothValued(right) && left.Any() && right.Any();

  public static bool IsSingleFlag(this int flag)
  {
    while (flag > 0) {
      bool rem = (flag & 1) > 0;
      flag >>= 1;
      if (rem) {
        return flag == 0;
      }
    }

    return false;
  }
}
