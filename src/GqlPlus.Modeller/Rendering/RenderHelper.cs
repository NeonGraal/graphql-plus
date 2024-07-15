namespace GqlPlus.Rendering;

internal static class RenderHelper
{
  internal static RenderStructure Render(this ITokenMessages errors)
    => new(errors.Select(Render), "_Errors");

  private static RenderStructure Render(ITokenMessage error)
    => RenderStructure.New("_Error")
      .Add(error.Kind is TokenKind.Start or TokenKind.End,
        onFalse: r => r.Add("_at", RenderAt(error)))
      .Add("_kind", error.Kind)
      .Add("_message", error.Message);

  private static RenderStructure RenderAt(ITokenAt at)
    => RenderStructure.New("_At", true)
      .Add("_col", at.Column)
      .Add("_line", at.Line);

  internal static string TrueFalse(this bool value)
    => value ? "true" : "false";

  internal static string TypeTag(this Type type)
  {
    string result = "_" + type.Name.Replace("Model", "", StringComparison.InvariantCulture);

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  internal static RenderStructure RenderEnum<TEnum>(this TEnum value)
    where TEnum : struct
    => new(value.ToString(), value.GetType().TypeTag());
}
