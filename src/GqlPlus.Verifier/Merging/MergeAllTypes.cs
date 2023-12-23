using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllTypes(
  IMerge<EnumDeclAst> enums,
  IMerge<InputDeclAst> inputs,
  IMerge<OutputDeclAst> outputs,
  IMerge<ScalarDeclAst> scalars
) : IMerge<AstType>
{
  public bool CanMerge(AstType[] items)
  {
    FixupEnums(items.OfType<EnumDeclAst>(), items.OfType<OutputDeclAst>());

    return items.Select(i => i.GetType()).Distinct().Count() == 1;
  }

  public AstType[] Merge(AstType[] items)
  {
    var enumTypes = items.ArrayOf<EnumDeclAst>();
    var inputTypes = items.ArrayOf<InputDeclAst>();
    var outputTypes = items.ArrayOf<OutputDeclAst>();
    var scalarTypes = items.ArrayOf<ScalarDeclAst>();

    FixupEnums(enumTypes, outputTypes);

    var enumsMerged = enums.Merge(enumTypes);
    var inputsMerged = inputs.Merge(inputTypes);
    var outputsMerged = outputs.Merge(outputTypes);
    var scalarsMerged = scalars.Merge(scalarTypes);

    return [.. enumsMerged, .. inputsMerged, .. outputsMerged, .. scalarsMerged];
  }

  private static void FixupEnums(IEnumerable<EnumDeclAst> enumTypes, IEnumerable<OutputDeclAst> outputTypes)
  {
    var enumValues = BuiltIn.Basic.OfType<EnumDeclAst>()
      .Concat(BuiltIn.Internal.OfType<EnumDeclAst>())
      .Concat(enumTypes)
      .SelectMany(e => e.Values.Select(v => (Value: v.Name, Type: e.Name)))
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
