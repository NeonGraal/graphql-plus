using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeTypeParametersTests
  : TestDescriptions<TypeParameterAst>
{
  private readonly MergeTypeParameters _merger = new();

  protected override DescribedsMerger<TypeParameterAst> MergerDescribed => _merger;

  protected override TypeParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
