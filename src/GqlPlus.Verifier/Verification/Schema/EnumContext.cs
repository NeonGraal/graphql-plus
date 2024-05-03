using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema;

public class EnumContext(
  IMap<AstDescribed> types,
  ITokenMessages errors,
  IMap<string> enumValues
) : UsageContext(types, errors)
{
  internal bool GetEnumValue(string value, out string? type)
    => enumValues.TryGetValue(value, out type);

  internal bool GetEnumType(string? name, [NotNullWhen(true)] out EnumDeclAst? enumType)
  {
    enumType = null;
    if (GetType(name, out var theType)) {
      enumType = theType as EnumDeclAst;
    }

    return enumType is not null;
  }

  internal bool GetEnumValueType(EnumDeclAst enumType, string value, [NotNullWhen(true)] out EnumDeclAst? valueType)
  {
    valueType = enumType;
    while (!valueType.HasValue(value)) {
      if (!GetEnumType(valueType.Parent, out valueType)) {
        valueType = null;
        return false;
      }
    }

    return true;
  }
}

public static class EnumContextHelper
{
  public static IMap<string> MakeEnumValues(this AstType[] aliased)
  {
    var enums = aliased
        .OfType<EnumDeclAst>()
        .SelectMany(e => e.Members.Select(v => (Member: v.Name, Type: e.Name)))
        .GroupBy(e => e.Member, e => e.Type);

    var enumNames = enums.Select(e => e.Key).ToHashSet();

    return aliased
        .OfType<EnumDeclAst>()
        .SelectMany(e => e.Members.SelectMany(
          v => v.Aliases
            .Where(a => !enumNames.Contains(a))
            .Select(a => (Member: a, Type: e.Name))))
        .GroupBy(e => e.Member, e => e.Type)
        .Concat(enums)
        .Where(g => g.Count() == 1)
        .ToMap(e => e.Key, e => e.First());
  }
}
