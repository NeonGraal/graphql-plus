using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

public abstract class BaseSimpleTests<TInput, TSimple>(
  IBaseSimpleChecks<TInput, TSimple> simpleChecks
) : BaseAliasedTests<TInput, TSimple>(simpleChecks)
  where TSimple : IAstSimple
{
  [Theory, RepeatData]
  public void WithParent_ReturnsCorrectAst(TInput input, string parent)
    => simpleChecks.WithParent(input, parent);

  [Theory, RepeatData]
  public void WithParentBad_ReturnsFalse(string name)
    => simpleChecks.FalseExpected(name + "{:}");
}

internal abstract class BaseSimpleChecks<TInput, TSimpleAst, TSimple>(
  IParserRepository parsers
) : BaseAliasedChecks<TInput, TSimpleAst, TSimple>(parsers)
  , IBaseSimpleChecks<TInput, TSimple>
  where TSimpleAst : AstSimple, TSimple
  where TSimple : IAstSimple
{
  public void WithParent(TInput input, string parent)
    //    => TrueExpected(input.Type + "{:" + parent + " " + input.Member + "}",
    => TrueExpected(ParentString(input, string.Empty, parent),
      NamedFactory(input) with {
        Parent = ParentFactory(parent),
      });

  protected internal override string AliasesString(TInput input, string aliases)
    => ParentString(input, aliases, null);

  protected abstract string ParentString(TInput input, string aliases, string? parent);
}

public interface IBaseSimpleChecks<TInput, TSimple>
  : IBaseAliasedChecks<TInput, TSimple>
  where TSimple : IAstSimple
{
  void WithParent(TInput input, string parent);
  IAstTypeRef ParentFactory(string parent);
}
