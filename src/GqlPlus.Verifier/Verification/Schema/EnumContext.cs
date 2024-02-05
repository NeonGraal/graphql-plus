using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

public record class EnumContext(
  IMap<AstDescribed> Types,
  ITokenMessages Errors,
  IMap<string> EnumValues
) : UsageContext(Types, Errors)
{
  internal bool GetEnumValue(string value, out string? type)
    => EnumValues.TryGetValue(value, out type);

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
