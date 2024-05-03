﻿using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public sealed class ParseEnumTests
  : TestAliased<EnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithParent_ReturnsCorrectAst(EnumInput input, string parent)
    => _checks.TrueExpected(input.Type + "{:" + parent + " " + input.Member + "}",
      _checks.NamedFactory(input) with {
        Parent = parent,
      });

  [Theory, RepeatData(Repeats)]
  public void WithParentBad_ReturnsFalse(string name)
    => _checks.False(name + "{:}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumMembers_ReturnsCorrectAst(string name, string[] members)
    => _checks.TrueExpected(
      name + members.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, []) {
        Members = members.EnumMembers(),
      });

  [SkippableTheory, RepeatData(Repeats)]
  public void WithEnumMembersBad_ReturnsFalse(string name, string[] members)
    => _checks.False(name + "{" + string.Join("|", members) + "}",
      skipIf: members is null || members.Length < 2);

  [Theory, RepeatData(Repeats)]
  public void WithEnumMembersNone_ReturnsFalse(string name)
    => _checks.False(name + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] members)
    => _checks.TrueExpected(
      name + members.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, members.EnumMembers()) { Parent = parent });

  internal override ICheckAliased<EnumInput> AliasChecks => _checks;

  private readonly ParseEnumChecks _checks;

  public ParseEnumTests(Parser<EnumDeclAst>.D parser)
    => _checks = new(parser);
}

internal sealed class ParseEnumChecks
  : CheckAliased<EnumInput, EnumDeclAst>
{
  public ParseEnumChecks(Parser<EnumDeclAst>.D parser)
    : base(parser) { }

  protected internal override EnumDeclAst NamedFactory(EnumInput input)
    => new(AstNulls.At, input.Type, new[] { input.Member }.EnumMembers());

  protected internal override string AliasesString(EnumInput input, string aliases)
    => input.Type + aliases + "{" + input.Member + "}";
}

public record struct EnumInput(string Type, string Member);
