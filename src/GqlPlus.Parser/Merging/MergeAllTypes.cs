using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging;

internal class MergeAllTypes(
  IMergerRepository mergers
) : AllMerger<IAstType>(mergers)
{
  protected override string ItemMatchName => "Type";
  protected override string ItemMatchKey(IAstType item) => item.Label;

  public override IMessages CanMerge(IEnumerable<IAstType> items)
  {
    FixupEnums(items);

    return base.CanMerge(items);
  }

  public override IEnumerable<IAstType> Merge(IEnumerable<IAstType> items)
  {
    if (items is null) {
      return [];
    }

    FixupEnums(items);

    return base.Merge(items);
  }

  private static void FixupEnums(IEnumerable<IAstType> items)
  {
    IAstType[] types = [.. items];
    HashSet<string> typeNames = [.. types
      .Concat(BuiltIn.Basic)
      .Concat(BuiltIn.Internal)
      .SelectMany(t => t.Aliases.Append(t.Name))];

    Map<string> enumValues = GetEnumValues(
      BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(types.OfType<EnumDeclAst>()));

    FixupObjects(types, typeNames, enumValues);
    FixupEnumDomains(types, enumValues);
  }

  private static void FixupEnumDomains(IAstType[] types, Map<string> enumValues)
  {
    foreach (AstDomain<DomainLabelAst, IAstDomainLabel> domain in types.OfType<AstDomain<DomainLabelAst, IAstDomainLabel>>()) {
      foreach ((DomainLabelAst item, string enumType) in domain.Items
          .Cast<DomainLabelAst>()
          .Where(l => string.IsNullOrEmpty(l.EnumType))
          .Select(l => (l, enumValues.TryGetValue(l.EnumItem.IfWhiteSpace(), out string? et) ? et : string.Empty))) {
        item.EnumType = enumType;
      }
    }
  }

  private static void FixupObjects(IAstType[] types, HashSet<string> typeNames, Map<string> enumValues)
  {
    foreach (IAstObject output in types.OfType<IAstObject>()) {
      foreach (IAstAlternate alternate in output.Alternates) {
        FixupType(alternate, typeNames, enumValues);

        foreach (IAstTypeArg argument in alternate.Args) {
          FixupType(argument, typeNames, enumValues);
        }
      }

      foreach (IAstObjField field in output.Fields) {
        FixupType(field, typeNames, enumValues);

        foreach (IAstTypeArg argument in field.Type.Args) {
          FixupType(argument, typeNames, enumValues);
        }
      }
    }
  }

  private static Map<string> GetEnumValues(IEnumerable<EnumDeclAst> enums)
    => enums.SelectMany(e => e.Items.Select(v => (Value: v.Name, Type: e.Name)))
      .ToLookup(p => p.Value, p => p.Type)
      .Where(g => g.Count() == 1)
      .ToMap(e => e.Key, e => e.First());

  private static void FixupType(IAstObjEnum type, HashSet<string> typeNames, Map<string> enumValues)
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

    if (string.IsNullOrWhiteSpace(enumType)) {
      return;
    }

    type.SetEnumType(enumType!);
  }
}
