using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Simple;
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
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<AstType>>());

    _merger = new(outputHelper.ToLoggerFactory(), [result]);
  }

  protected override IMerge<AstType> MergerBase => _merger;

  protected override AstType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input, []);
}
