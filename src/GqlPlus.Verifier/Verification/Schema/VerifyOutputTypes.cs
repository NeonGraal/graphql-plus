using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased
) : AstObjectTypesVerifier<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(aliased)
{
  public override string Label => "Output";
}
