using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased
) : AstObjectTypesVerifier<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(aliased)
{
  public override string Label => "Output";

  public override void Verify(UsageAliases<OutputDeclAst, AstType> item, ITokenMessages errors)
  {
    var enumTypes = item.Definitions
      .OfType<EnumDeclAst>().ToArray();

    var enumValues = enumTypes.SelectMany(e => e.Values.Select(v => (Value: v.Name, Type: e.Name)))
      .Distinct().ToDictionary(e => e.Value, e => e.Type);

    var enumFields = item.Usages
      .SelectMany(u => u.Fields)
      .Where(f => !string.IsNullOrWhiteSpace(f.EnumValue));

    foreach (var enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField.Type.Name)) {
        if (enumValues.TryGetValue(enumField.EnumValue!, out var value)) {
          enumField.Type = new(enumField.At, value);
        } else {
          errors.AddError(enumField, $"Invalid Output Field Enum. Enum Value '{enumField.EnumValue}' not defined.");
        }
      }
    }

    base.Verify(item, errors);
  }
}
