using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parsing.Schema.Simple;

public sealed class ParseEnumTests(
  IBaseSimpleChecks<EnumInput, IGqlpEnum> checks
) : BaseSimpleTests<EnumInput, IGqlpEnum>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumMembers_ReturnsCorrectAst(string name, string[] members)
    => checks.TrueExpected(
      name + members.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, []) {
        Members = members.EnumMembers(),
      });

  [SkippableTheory, RepeatData(Repeats)]
  public void WithEnumMembersBad_ReturnsFalse(string name, string[] members)
    => checks
    .SkipNull(members)
    .SkipIf(members.Length < 2)
    .FalseExpected(name + "{" + string.Join("|", members) + "}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumMembersNone_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] members)
    => checks.TrueExpected(
      name + members.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, members.EnumMembers()) { Parent = parent });
}

internal sealed class ParseEnumChecks(
  Parser<IGqlpEnum>.D parser
) : BaseSimpleChecks<EnumInput, EnumDeclAst, IGqlpEnum>(parser)
{
  protected internal override EnumDeclAst NamedFactory(EnumInput input)
    => new(AstNulls.At, input.Type, new[] { input.Member }.EnumMembers());

  protected override string ParentString(EnumInput input, string aliases, string? parent)
    => input.Type + aliases + "{" +
    (string.IsNullOrWhiteSpace(parent) ? "" : $":{parent} ") +
    input.Member + "}";
}

public record struct EnumInput(string Type, string Member);
