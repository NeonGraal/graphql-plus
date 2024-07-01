using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging;

internal class MergeAllTypes(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<IGqlpType>> types
) : AllMerger<IGqlpType>(logger, types)
{
  protected override string ItemMatchName => "Type";
  protected override string ItemMatchKey(IGqlpType item) => item.Label;

  public override ITokenMessages CanMerge(IEnumerable<IGqlpType> items)
  {
    FixupEnums(items);

    return base.CanMerge(items);
  }

  public override IEnumerable<IGqlpType> Merge(IEnumerable<IGqlpType> items)
  {
    if (items is null) {
      return [];
    }

    FixupEnums(items);

    return base.Merge(items);
  }

  private static void FixupEnums(IEnumerable<IGqlpType> items)
  {
    IGqlpType[] types = [.. items];

    Map<string> enumValues = GetEnumValues(
      BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(types.OfType<EnumDeclAst>()));

    foreach (OutputDeclAst output in types.OfType<OutputDeclAst>()) {
      foreach (IGqlpOutputAlternate alternate in output.ObjAlternates) {
        FixupType(alternate.BaseType, enumValues);
      }

      foreach (IGqlpOutputField field in output.ObjFields) {
        FixupType(field.BaseType, enumValues);
      }
    }

    foreach (AstDomain<DomainMemberAst, IGqlpDomainMember> domain in types.OfType<AstDomain<DomainMemberAst, IGqlpDomainMember>>()) {
      foreach (DomainMemberAst item in domain.Members) {
        if (string.IsNullOrEmpty(item.EnumType)
          && enumValues.TryGetValue(item.Member ?? "", out string? enumType)) {
          item.EnumType = enumType;
        }
      }
    }
  }

  private static Map<string> GetEnumValues(IEnumerable<EnumDeclAst> enums)
    => enums.SelectMany(e => e.Members.Select(v => (Value: v.Name, Type: e.Name)))
      .ToLookup(p => p.Value, p => p.Type)
      .Where(g => g.Count() == 1)
      .ToMap(e => e.Key, e => e.First());

  private static void FixupType(IGqlpOutputArgument type, Map<string> enumValues)
  {
    if (string.IsNullOrWhiteSpace(type.Output)
      && enumValues.TryGetValue(type.EnumMember ?? "", out string? enumType)) {
      ((OutputArgumentAst)type).Name = enumType;
    }
  }

  private static void FixupType(IGqlpOutputBase type, Map<string> enumValues)
  {
    foreach (IGqlpOutputArgument argument in type.BaseArguments) {
      FixupType(argument, enumValues);
    }
  }
}
