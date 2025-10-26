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
    HashSet<string> typeNames = [.. types.SelectMany(t => t.Aliases.Append(t.Name))];

    Map<string> enumValues = GetEnumValues(
      BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(types.OfType<EnumDeclAst>()));

    foreach (IGqlpObject output in types.OfType<IGqlpObject>()) {
      foreach (IGqlpAlternate alternate in output.Alternates) {
        FixupType(alternate, typeNames, enumValues);

        foreach (IGqlpTypeArg argument in alternate.Args) {
          FixupType(argument, typeNames, enumValues);
        }
      }

      foreach (IGqlpObjField field in output.Fields) {
        FixupType(field, typeNames, enumValues);

        foreach (IGqlpTypeArg argument in field.Type.Args) {
          FixupType(argument, typeNames, enumValues);
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

  private static void FixupType(IGqlpObjEnum type, HashSet<string> typeNames, Map<string> enumValues)
  {
    string? enumType = null;

    if (type.EnumValue is null) {
      if (string.IsNullOrWhiteSpace(type.EnumTypeName) || typeNames.Contains(type.EnumTypeName)) {
        return;
      }

      enumValues.TryGetValue(type.EnumTypeName, out enumType);
    } else {
      if (string.IsNullOrWhiteSpace(type.EnumValue.EnumType)) {
        enumValues.TryGetValue(type.EnumValue.EnumLabel.IfWhiteSpace(), out enumType);
      }
    }

    if (!string.IsNullOrWhiteSpace(enumType)) {
      type.SetEnumType(enumType!);
    }
  }
}
