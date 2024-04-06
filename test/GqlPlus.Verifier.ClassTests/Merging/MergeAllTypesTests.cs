using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeAllTypesTests
  : TestAbbreviated<AstType>
{
  private readonly MergeAllTypes _merger;

  public MergeAllTypesTests()
  {
    var result = Substitute.For<IMergeAll<AstType>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<AstType>>());

    _merger = new([result]);
  }

  protected override IMerge<AstType> MergerBase => _merger;

  protected override AstType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input);
}
