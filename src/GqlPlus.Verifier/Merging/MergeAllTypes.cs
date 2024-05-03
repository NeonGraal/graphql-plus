using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal class MergeAllTypes(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<AstType>> types
) : AllMerger<AstType>(logger, types)
{
  protected override string ItemMatchName => "Type";
  protected override string ItemMatchKey(AstType item) => item.Label;

  public override ITokenMessages CanMerge(IEnumerable<AstType> items)
  {
    FixupEnums(items);

    return base.CanMerge(items);
  }

  public override IEnumerable<AstType> Merge(IEnumerable<AstType> items)
  {
    if (items is null) {
      return [];
    }

    FixupEnums(items);

    return base.Merge(items);
  }

  private static void FixupEnums(IEnumerable<AstType> items)
  {
    Map<string> enumValues = GetEnumValues(
      BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(items.OfType<EnumDeclAst>()));

    foreach (OutputDeclAst output in items.OfType<OutputDeclAst>()) {
      foreach (AstAlternate<OutputBaseAst> alternate in output.Alternates) {
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

  private static void FixupType(OutputBaseAst type, Map<string> enumValues)
  {
    if (string.IsNullOrWhiteSpace(type.Name)
      && enumValues.TryGetValue(type.EnumValue ?? "", out string? enumType)) {
      type.Name = enumType;
    }

    foreach (OutputBaseAst argument in type.Arguments) {
      FixupType(argument, enumValues);
    }
  }
}
