using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
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

    foreach (AstDomain<DomainLabelAst, IGqlpDomainLabel> domain in types.OfType<AstDomain<DomainLabelAst, IGqlpDomainLabel>>()) {
      foreach (DomainLabelAst item in domain.Items) {
        if (string.IsNullOrEmpty(item.EnumType)
          && enumValues.TryGetValue(item.EnumItem ?? "", out string? enumType)) {
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

  private static void FixupType<TEnum>(IGqlpOutputEnum type, Map<string> enumValues)
    where TEnum : AstNamed, IGqlpOutputEnum
  {
    if (type is TEnum named) {
      if (string.IsNullOrWhiteSpace(named.Name)
        && enumValues.TryGetValue(type.EnumLabel ?? "", out string? enumType)) {
        named.Name = enumType;
      }
    }
  }

  private static void FixupType(IGqlpOutputBase type, Map<string> enumValues)
  {
    FixupType<OutputBaseAst>(type, enumValues);

    foreach (IGqlpOutputArg argument in type.BaseArgs) {
      FixupType<OutputArgAst>(argument, enumValues);
    }
  }
}
