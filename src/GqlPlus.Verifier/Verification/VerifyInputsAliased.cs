using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputsAliased(
  IVerify<InputDeclAst> definition,
   IMerge<InputDeclAst> merger
) : AliasedVerifier<InputDeclAst>(definition, merger)
{
  public override string Label => "Inputs";

  protected override object GroupKey(InputDeclAst item) => item.Name + "-" + (item.Extends?.Name ?? "");
}
