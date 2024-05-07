namespace GqlPlus;

public static class TypeHelpers
{
  public static string FullTypeName(this Type type, string? ns = null)
      => type is null ? "null"
        : type.Namespace is null || type.Namespace == ns
          ? ExpandTypeName(type)
          : type.Namespace + "::" + ExpandTypeName(type);

  public static string TidyTypeName(this Type type)
    => type.ExpandTypeName()
      .Replace("Ast", "", StringComparison.OrdinalIgnoreCase)
      .Replace("IGqlp", "", StringComparison.OrdinalIgnoreCase)
      .Replace("Model", "", StringComparison.OrdinalIgnoreCase);

  public static string ExpandTypeName(this Type type)
  {
    ArgumentNullException.ThrowIfNull(type);

    if (type.IsGenericTypeParameter) {
      return "";
    }

    if (type.IsGenericType || type.IsGenericTypeDefinition) {
      string baseType = NestedTypeName(type.GetGenericTypeDefinition());
      Type[] args = type.GetGenericArguments();
      string placeholder = $"`{args.Length}";
      string arguments = "<" + string.Join(",", args.Select(ExpandTypeName)) + ">";

      return baseType.Replace(placeholder, arguments, StringComparison.InvariantCulture);
    }

    return NestedTypeName(type);
  }

  private static string NestedTypeName(Type type)
    => type is null ? "null"
      : type.IsNested && !type.IsGenericTypeParameter && type.DeclaringType is not null
        ? NestedTypeName(type.DeclaringType) + "+" + type.Name
        : type.Name;
}
