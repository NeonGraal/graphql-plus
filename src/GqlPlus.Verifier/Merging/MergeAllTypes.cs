using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllTypes(
  IEnumerable<IMergeAll<AstType>> types
) : AllMerger<AstType>(types)
{
  public override bool CanMerge(IEnumerable<AstType> items)
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
    var enumTypes = items.OfType<EnumDeclAst>();
    var outputTypes = items.OfType<OutputDeclAst>();

    var enumValues = BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(enumTypes)
      .SelectMany(e => e.Members.Select(v => (Value: v.Name, Type: e.Name)))
      .ToLookup(p => p.Value, p => p.Type)
      .Where(g => g.Count() == 1)
      .ToMap(e => e.Key, e => e.First());

    foreach (var output in outputTypes) {
      foreach (var alternate in output.Alternates) {
        FixupType(alternate.Type, enumValues);
      }

      foreach (var field in output.Fields) {
        FixupType(field.Type, enumValues);
      }
    }
  }

  private static void FixupType(OutputReferenceAst type, Map<string> enumValues)
  {
    if (string.IsNullOrWhiteSpace(type.Name)
      && enumValues.TryGetValue(type.EnumValue ?? "", out var enumType)) {
      type.Name = enumType;
    }

    foreach (var argument in type.Arguments) {
      FixupType(argument, enumValues);
    }
  }
}
