using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyCategoryAliased(
  IVerify<CategoryDeclAst> definition,
   IMerge<CategoryDeclAst> merger
) : AliasedVerifier<CategoryDeclAst>(definition, merger)
{
  public override string Label => "Categories";

  protected override object GroupKey(CategoryDeclAst aliased) => "";
}
