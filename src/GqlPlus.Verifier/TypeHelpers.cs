namespace GqlPlus.Verifier;

public static class TypeHelpers
{
  public static string FullTypeName(this Type t, string? ns = null)
      => t is null
        ? "{null}"
        : t.Namespace is null || t.Namespace == ns
          ? ExpandTypeName(t)
          : t.Namespace + "::" + ExpandTypeName(t);

  public static string ExpandTypeName(this Type t)
  {
    if (t is null) {
      return "{null}";
    }

    if (t.IsGenericTypeParameter) {
      return "";
    }

    if (t.IsGenericType || t.IsGenericTypeDefinition) {
      var baseType = NestedTypeName(t.GetGenericTypeDefinition());
      var args = t.GetGenericArguments();
      var placeholder = $"`{args.Length}";
      var arguments = "<" + string.Join(",", args.Select(ExpandTypeName)) + ">";

      return baseType.Replace(placeholder, arguments);
    }

    return NestedTypeName(t);
  }

  private static string NestedTypeName(Type? t)
    => t is null
      ? "{null}"
      : t.IsNested && !t.IsGenericTypeParameter
        ? NestedTypeName(t.DeclaringType) + "+" + t.Name
        : t.Name;
}
