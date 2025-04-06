using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions;

namespace GqlPlus.Structures;

public static class StructureHelper
{
  public static Structured Render<T>(this IEnumerable<T> list, Func<T, Structured> mapper, string tag = "", bool flow = false)
    => new(list.Select(mapper), tag, flow);

  public static Structured Render(this IEnumerable<string> list, string tag = "", bool flow = false)
    => list.Render(i => new(i), tag, flow);

  public static Structured Render<T>(this IMap<T> groups, Func<T, Structured> mapper, string tag = "", bool flow = false)
    => new(groups.ToDictionary(k => new StructureValue(k.Key), v => mapper(v.Value)), tag, flow);

  public static Structured Render(this IMap<Structured> groups, string tag = "", bool flow = false)
    => groups.Render(v => v, tag, flow);

  public static Structured Render(this ITokenMessages errors)
    => new(errors.Select(Render), "_Errors");

  private static Structured Render(ITokenMessage error)
    => new Map<Structured>() { ["_message"] = error.Message }.Render("_Error")
      .AddIf(error.Kind is TokenKind.Start or TokenKind.End,
        onFalse: r => r.Add("_at", RenderAt(error)))
      .AddEnum("_kind", error.Kind);

  private static Structured RenderAt(ITokenAt at)
    => new Map<Structured>() {
      ["_col"] = at.Column,
      ["_line"] = at.Line,
    }.Render("_At", true);

  public static string TrueFalse(this bool value)
    => value ? "true" : "false";

  public static string TypeTag(this Type type)
  {
    string result = "_" + type.ThrowIfNull().Name.Replace("Model", "");

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  public static Structured RenderEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.ToString(), value.GetType().TypeTag());

  internal static bool BothValued<T>([NotNullWhen(true)] this T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;

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
