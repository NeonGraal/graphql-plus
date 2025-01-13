using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public abstract class BaseSimpleTests<TInput, TSimple>(
  IBaseSimpleChecks<TInput, TSimple> simpleChecks
) : BaseAliasedTests<TInput, TSimple>(simpleChecks)
  where TSimple : IGqlpSimple
{
  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(TInput input, string parent)
    => simpleChecks.WithParent(input, parent);

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(string name)
    => simpleChecks.FalseExpected(name + "{:}");
}

internal abstract class BaseSimpleChecks<TInput, TSimpleAst, TSimple>(
  Parser<TSimple>.D parser
) : BaseAliasedChecks<TInput, TSimpleAst, TSimple>(parser)
  , IBaseSimpleChecks<TInput, TSimple>
  where TSimpleAst : AstSimple, TSimple
  where TSimple : IGqlpSimple
{
  public void WithParent(TInput input, string parent)
    //    => TrueExpected(input.Type + "{:" + parent + " " + input.Member + "}",
    => TrueExpected(ParentString(input, string.Empty, parent),
      NamedFactory(input) with {
        Parent = parent,
      });

  protected internal override string AliasesString(TInput input, string aliases)
    => ParentString(input, aliases, null);

  protected abstract string ParentString(TInput input, string aliases, string? parent);
}

public interface IBaseSimpleChecks<TInput, TSimple>
  : IBaseAliasedChecks<TInput, TSimple>
  where TSimple : IGqlpSimple
{
  void WithParent(TInput input, string parent);
}
