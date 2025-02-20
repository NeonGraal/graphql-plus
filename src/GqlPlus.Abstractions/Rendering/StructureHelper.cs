using GqlPlus.Abstractions;

namespace GqlPlus.Rendering;

public static class StructureHelper
{
  public static Structured Render(this ITokenMessages errors)
    => new(errors.Select(Render), "_Errors");

  private static Structured Render(ITokenMessage error)
    => Structured.New("_Error")
      .AddIf(error.Kind is TokenKind.Start or TokenKind.End,
        onFalse: r => r.Add("_at", RenderAt(error)))
      .AddEnum("_kind", error.Kind)
      .Add("_message", error.Message);

  private static Structured RenderAt(ITokenAt at)
    => Structured.New("_At", true)
      .Add("_col", at.Column)
      .Add("_line", at.Line);

  public static string TrueFalse(this bool value)
    => value ? "true" : "false";

  public static string TypeTag(this Type type)
  {
    string result = "_" + type.ThrowIfNull().Name.Replace("Model", "", StringComparison.InvariantCulture);

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  public static Structured RenderEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.ToString(), value.GetType().TypeTag());
}
