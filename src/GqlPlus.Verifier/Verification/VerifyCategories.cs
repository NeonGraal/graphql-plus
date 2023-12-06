using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategories(IVerify<CategoryDeclAst> definition)
  : AliasedVerifier<CategoryDeclAst>(definition)
{
  public override string Label => "Categories";

  protected override object GroupKey(CategoryDeclAst aliased) => "";
}
