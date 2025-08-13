using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseUnionTests(
  IBaseSimpleChecks<UnionInput, IGqlpUnion> checks
) : BaseSimpleTests<UnionInput, IGqlpUnion>(checks)
{
  [Theory, RepeatData]
  public void WithUnionMembers_ReturnsCorrectAst(string name, string[] members)
    => checks.TrueExpected(
      name + members.Bracket("{", "}").Joined(),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()));

  [Theory, RepeatData]
  public void WithUnionMembersBad_ReturnsFalse(string name, string[] members)
    => checks.FalseExpected(name + "{" + members.Joined() + "|}");

  [Theory, RepeatData]
  public void WithUnionMembersNone_ReturnsFalse(string name)
    => checks.TrueExpected(name + "{}", new UnionDeclAst(AstNulls.At, name, []));

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] members)
    => checks.TrueExpected(
      name + members.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()) {
        Parent = checks.ParentFactory(parent),
      });
}

internal sealed class ParseUnionChecks(
  Parser<IGqlpUnion>.D parser
) : BaseSimpleChecks<UnionInput, UnionDeclAst, IGqlpUnion>(parser)
{
  protected internal override UnionDeclAst NamedFactory(UnionInput input)
    => new(AstNulls.At, input.Type, new[] { input.Member }.UnionMembers());

  protected internal override string AliasesString(UnionInput input, string aliases)
    => input.Type + aliases + "{" + input.Member + "}";
  protected override string ParentString(UnionInput input, string aliases, string? parent)
    => input.Type + aliases + "{" +
    (string.IsNullOrWhiteSpace(parent) ? "" : $":{parent} ") +
    input.Member + "}";
}

public record struct UnionInput(string Type, string Member);
