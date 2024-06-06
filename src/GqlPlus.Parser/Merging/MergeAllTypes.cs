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
      foreach (AstAlternate<IGqlpOutputBase> alternate in output.Alternates) {
        FixupType(alternate.Type, enumValues);
      }

      foreach (OutputFieldAst field in output.Fields) {
        FixupType(field.Type, enumValues);
      }
    }
  }

  private static Map<string> GetEnumValues(IEnumerable<EnumDeclAst> enums)
    => enums.SelectMany(e => e.Members.Select(v => (Value: v.Name, Type: e.Name)))
      .ToLookup(p => p.Value, p => p.Type)
      .Where(g => g.Count() == 1)
      .ToMap(e => e.Key, e => e.First());

  private static void FixupType(IGqlpOutputBase type, Map<string> enumValues)
  {
    if (string.IsNullOrWhiteSpace(type.Output)
      && enumValues.TryGetValue(type.EnumMember ?? "", out string? enumType)) {
      ((OutputBaseAst)type).Name = enumType;
    }

    foreach (IGqlpOutputBase argument in type.TypeArguments) {
      FixupType(argument, enumValues);
    }
  }
}
