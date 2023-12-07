using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputsAliased(
  IVerify<OutputDeclAst> definition,
   IMerge<OutputDeclAst> merger
) : AliasedVerifier<OutputDeclAst>(definition, merger)
{
  public override string Label => "Outputs";

  protected override object GroupKey(OutputDeclAst item) => item.Name + "-" + (item.Extends?.Name ?? "");
}
