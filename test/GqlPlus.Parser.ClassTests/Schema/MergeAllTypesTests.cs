using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using NSubstitute;

using Xunit.Abstractions;

namespace GqlPlus.Schema;

public class MergeAllTypesTests
  : TestAbbreviatedMerger<IGqlpType>
{
  private readonly MergeAllTypes _merger;

  public MergeAllTypesTests(ITestOutputHelper outputHelper)
  {
    IMergeAll<IGqlpType> result = Substitute.For<IMergeAll<IGqlpType>>();
    result.CanMerge([]).ReturnsForAnyArgs(EmptyMessages);
    result.Merge([]).ReturnsForAnyArgs(c => c.Arg<IEnumerable<IGqlpType>>());

    _merger = new(outputHelper.ToLoggerFactory(), [result]);
  }

  protected override IMerge<IGqlpType> MergerBase => _merger;

  protected override IGqlpType MakeAst(string input)
    => new EnumDeclAst(AstNulls.At, input, []);
}
