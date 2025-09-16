using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging;

internal class MergeAllTypes(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<IGqlpType>> types
) : AllMerger<IGqlpType>(logger, types)
{
  protected override string ItemMatchName => "Type";
  protected override string ItemMatchKey(IGqlpType item) => item.Label;

  public override IMessages CanMerge(IEnumerable<IGqlpType> items)
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

    foreach (IGqlpObject output in types.OfType<IGqlpObject>()) {
      foreach (IGqlpObjAlternate alternate in output.Alternates) {
        // No fixup needed?
        // FixupType(alternate, enumValues);
      }

      foreach (IGqlpObjField field in output.Fields) {
        FixupType<IGqlpObjField>(field, enumValues);

        foreach (IGqlpObjArg argument in field.Type.Args) {
          FixupType<IGqlpObjArg>(argument, enumValues);
        }
      }
    }

    foreach (AstDomain<DomainLabelAst, IGqlpDomainLabel> domain in types.OfType<AstDomain<DomainLabelAst, IGqlpDomainLabel>>()) {
      foreach (DomainLabelAst item in domain.Items.Cast<DomainLabelAst>()) {
        if (string.IsNullOrEmpty(item.EnumType)
          && enumValues.TryGetValue(item.EnumItem.IfWhiteSpace(), out string? enumType)) {
          item.EnumType = enumType;
        }
      }
    }
  }

  private static Map<string> GetEnumValues(IEnumerable<EnumDeclAst> enums)
    => enums.SelectMany(e => e.Items.Select(v => (Value: v.Name, Type: e.Name)))
      .ToLookup(p => p.Value, p => p.Type)
      .Where(g => g.Count() == 1)
      .ToMap(e => e.Key, e => e.First());

  private static void FixupType<TEnum>(IGqlpObjectEnum type, Map<string> enumValues)
    where TEnum : IGqlpObjectEnum
  {
    if (type is TEnum named) {
      if (string.IsNullOrWhiteSpace(named.EnumType.Name)
        && enumValues.TryGetValue(type.EnumLabel.IfWhiteSpace(), out string? enumType)) {
        named.SetEnumType(enumType);
      }
    }
  }
}
