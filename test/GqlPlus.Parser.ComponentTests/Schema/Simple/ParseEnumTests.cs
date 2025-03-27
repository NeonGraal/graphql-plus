using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseEnumTests(
  IBaseSimpleChecks<EnumInput, IGqlpEnum> checks
) : BaseSimpleTests<EnumInput, IGqlpEnum>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumLabels_ReturnsCorrectAst(string name, string[] members)
    => checks.TrueExpected(
      name + members.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, []) {
        Items = members.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabelsBad_ReturnsFalse(string name, string[] members)
    => checks
    .SkipNull(members)
    .SkipIf(members.Length < 2)
    .FalseExpected(name + "{" + string.Join("|", members) + "}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabelsNone_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] members)
    => checks.TrueExpected(
      name + members.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, members.EnumLabels()) { Parent = parent });
}

internal sealed class ParseEnumChecks(
  Parser<IGqlpEnum>.D parser
) : BaseSimpleChecks<EnumInput, EnumDeclAst, IGqlpEnum>(parser)
{
  protected internal override EnumDeclAst NamedFactory(EnumInput input)
    => new(AstNulls.At, input.Type, new[] { input.Member }.EnumLabels());

  protected override string ParentString(EnumInput input, string aliases, string? parent)
    => input.Type + aliases + "{" +
    (string.IsNullOrWhiteSpace(parent) ? "" : $":{parent} ") +
    input.Member + "}";
}

public record struct EnumInput(string Type, string Member);
