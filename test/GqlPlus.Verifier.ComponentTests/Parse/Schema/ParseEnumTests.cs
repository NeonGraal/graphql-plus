using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseEnumTests
  : BaseAliasedTests<EnumInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id, string value)
    => _checks.False($"{id}{{{value}}}");

  [Theory, RepeatData(Repeats)]
  public void WithExtends_ReturnsCorrectAst(EnumInput input, string extends)
    => _checks.TrueExpected(input.Type + "{:" + extends + " " + input.Value + "}",
      _checks.AliasedFactory(input) with {
        Extends = extends,
      });

  [Theory, RepeatData(Repeats)]
  public void WithExtendsBad_ReturnsFalse(string name)
    => _checks.False(name + "{:}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumValues_ReturnsCorrectAst(string name, string[] values)
    => _checks.TrueExpected(
      name + values.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name) {
        Values = values.EnumValues(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithEnumValuesBad_ReturnsFalse(string name, string[] values)
    => _checks.False(name + "{" + string.Join("|", values) + "}",
      skipIf: values.Length < 2);

  [Theory, RepeatData(Repeats)]
  public void WithEnumValuesNone_ReturnsFalse(string name)
    => _checks.False(name + "{}");

  internal override IBaseAliasedChecks<EnumInput> AliasChecks => _checks;

  private readonly ParseEnumChecks _checks;

  public ParseEnumTests(Parser<EnumDeclAst>.D parser)
    => _checks = new(parser);
}

internal sealed class ParseEnumChecks
  : BaseAliasedChecks<EnumInput, EnumDeclAst>
{
  public ParseEnumChecks(Parser<EnumDeclAst>.D parser)
    : base(parser) { }

  protected internal override EnumDeclAst AliasedFactory(EnumInput input)
    => new(AstNulls.At, input.Type) { Values = new[] { input.Value }.EnumValues(), };

  protected internal override string AliasesString(EnumInput input, string aliases)
    => input.Type + aliases + "{" + input.Value + "}";
}

public record struct EnumInput(string Type, string Value);
