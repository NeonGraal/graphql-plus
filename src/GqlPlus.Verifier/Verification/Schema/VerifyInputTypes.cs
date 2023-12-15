using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased
) : UsageAliasedVerifier<InputDeclAst, AstType>(aliased)
{
  protected override ITokenMessages UsageValue(InputDeclAst usage, IMap<AstType[]> byId)
  {
    var errors = new TokenMessages();

    foreach (var field in usage.Fields) {
      if (!byId.ContainsKey(field.Type.Name)) {
        errors.Add(usage.Error($"Invalid Input Field. '{field.Type}' not defined."));
      }

      if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
        errors.Add(usage.Error($"Invalid Input Field Default. 'null' default requires Optional type, not '{field.ModifiedType}'."));
      }
    }

    return errors;
  }
}
