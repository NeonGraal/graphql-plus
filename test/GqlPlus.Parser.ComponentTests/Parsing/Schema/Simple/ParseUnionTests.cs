﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseUnionTests
  : BaseAliasedTests<UnionInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(UnionInput input, string parent)
    => _checks.TrueExpected(input.Type + "{:" + parent + " " + input.Member + "}",
      _checks.NamedFactory(input) with {
        Parent = parent,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(string name)
    => _checks.FalseExpected(name + "{:}");

  [Theory, RepeatData(Repeats)]
  public void WithUnionMembers_ReturnsCorrectAst(string name, string[] members)
    => _checks.TrueExpected(
      name + members.Bracket("{", "}").Joined(),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()));

  [Theory, RepeatData(Repeats)]
  public void WithUnionMembersBad_ReturnsFalse(string name, string[] members)
    => _checks.FalseExpected(name + "{" + members.Joined() + "|}");

  [Theory, RepeatData(Repeats)]
  public void WithUnionMembersNone_ReturnsFalse(string name)
    => _checks.FalseExpected(name + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] members)
    => _checks.TrueExpected(
      name + members.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new UnionDeclAst(AstNulls.At, name, members.UnionMembers()) {
        Parent = parent,
      });

  internal override IBaseAliasedChecks<UnionInput> AliasChecks => _checks;

  private readonly ParseUnionChecks _checks;

  public ParseUnionTests(Parser<IGqlpUnion>.D parser)
    => _checks = new(parser);
}

internal sealed class ParseUnionChecks
  : BaseAliasedChecks<UnionInput, UnionDeclAst, IGqlpUnion>
{
  public ParseUnionChecks(Parser<IGqlpUnion>.D parser)
    : base(parser) { }

  protected internal override UnionDeclAst NamedFactory(UnionInput input)
    => new(AstNulls.At, input.Type, new[] { input.Member }.UnionMembers());

  protected internal override string AliasesString(UnionInput input, string aliases)
    => input.Type + aliases + "{" + input.Member + "}";
}

public record struct UnionInput(string Type, string Member);
