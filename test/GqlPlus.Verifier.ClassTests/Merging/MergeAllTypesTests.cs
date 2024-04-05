using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeAllTypesTests
  : TestAbbreviated<AstType>
{
  private readonly MergeAllTypes _merger;

  public MergeAllTypesTests(ITestOutputHelper outputHelper)
  {
    var result = Substitute.For<IMergeAll<AstType>>();
    result.CanMerge([]).ReturnsForAnyArgs(true);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<AstType>>());

    _merger = new([result]);
  }

  protected override IMerge<AstType> MergerBase => _merger;

  protected override AstType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input);
}
