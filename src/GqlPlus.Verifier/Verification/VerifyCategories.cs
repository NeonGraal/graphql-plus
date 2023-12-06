using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategories(IVerify<CategoryAst> definition)
  : AliasedVerifier<CategoryAst>(definition)
{
  public override string Label => "Categories";

  protected override object GroupKey(CategoryAst aliased) => "";
}
