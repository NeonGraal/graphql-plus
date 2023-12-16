using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyDirectiveInput(
  IVerifyAliased<DirectiveDeclAst> aliased
) : UsageAliasedVerifier<DirectiveDeclAst, InputDeclAst>(aliased)
{
  protected override void UsageValue(DirectiveDeclAst usage, IMap<InputDeclAst[]> byId, ITokenMessages errors)
  {
    foreach (var parameter in usage.Parameters) {
      if (!byId.ContainsKey(parameter.Input.Name)) {
        errors.AddError(parameter, $"Invalid Directive Parameter. '{parameter.Input}' not defined");
      }
    }
  }
}
