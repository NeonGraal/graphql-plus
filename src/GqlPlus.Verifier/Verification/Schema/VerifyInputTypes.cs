using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased
) : UsageAliasedVerifier<InputDeclAst, AstType>(aliased)
{
  protected override void UsageValue(InputDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
    foreach (var field in usage.Fields) {
      if (!byId.ContainsKey(field.Type.Name)) {
        errors.AddError(usage, $"Invalid Input Field. '{field.Type}' not defined.");
      }

      if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
        errors.AddError(usage, $"Invalid Input Field Default. 'null' default requires Optional type, not '{field.ModifiedType}'.");
      }
    }
  }
}
