using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseDomainEnumTests(
  IBaseDomainChecks<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>> checks
) : BaseDomainTests<DomainEnumInput, IGqlpDomain<IGqlpDomainLabel>>(checks)
{

  [Theory, RepeatData]
  public void WithEnumType_ReturnsCorrectAst(DomainEnumInput input, string enumType)
    => checks.TrueExpected(
      input.Name + "{enum!" + enumType + "." + input.Label + "}",
      NewDomain(input, input.DomainLabel(enumType)));

  [Theory, RepeatData]
  public void WithEnumAllLabels_ReturnsCorrectAst(DomainEnumInput input)
    => checks.TrueExpected(
      input.Name + "{enum " + input.Label + ".* }",
      NewDomain(input, input.DomainAllLabels()));

  [Theory, RepeatData]
  public void WithLabels_ReturnsCorrectAst(DomainEnumInput input)
    => checks.TrueExpected(
      input.Name + "{enum!" + input.Label + " " + TestLabel + "}",
      NewDomain(input, input.DomainLabels(TestLabel)));

  [Theory, RepeatData]
  public void WithLabelsExcludeBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{enum !}");

  [Theory, RepeatData]
  public void WithLabelsFirstBad_ReturnsFalse(DomainEnumInput input)
    => checks.FalseExpected(input.Name + "{enum " + input.Label + ".}");

  [Theory, RepeatData]
  public void WithLabelsSecondBad_ReturnsFalse(DomainEnumInput input)
    => checks.FalseExpected(input.Name + "{enum " + input.Label + "!" + TestLabel + ".}");

  private static AstDomain<DomainLabelAst, IGqlpDomainLabel> NewDomain(DomainEnumInput input, DomainLabelAst[] labels)
    => new(AstNulls.At, input.Name, DomainKind.Enum, labels);
}

internal sealed class ParseDomainEnumChecks(
  Parser<IGqlpDomain>.D parser
) : BaseDomainChecks<DomainEnumInput, AstDomain<DomainLabelAst, IGqlpDomainLabel>, IGqlpDomain<IGqlpDomainLabel>>(parser, DomainKind.Enum)
{
  protected internal override AstDomain<DomainLabelAst, IGqlpDomainLabel> NamedFactory(DomainEnumInput input)
    => new(AstNulls.At, input.Name, DomainKind.Enum, input.DomainLabels());

  protected internal override string AliasesString(DomainEnumInput input, string aliases)
    => input.Name + aliases + "{enum !" + input.Label + "}";
  protected internal override string KindString(DomainEnumInput input, string kind, string parent)
    => input.Name + "{" + parent + kind + "!" + input.Label + "}";
}

public record struct DomainEnumInput(string Name, string Label)
{
  internal readonly DomainLabelAst[] DomainLabel(string enumType)
      => [new(AstNulls.At, "", true, Label) { EnumType = enumType }];
  internal readonly DomainLabelAst[] DomainAllLabels()
      => [new(AstNulls.At, "", false, "*") { EnumType = Label }];

  internal readonly DomainLabelAst[] DomainLabels(params string[] labels)
      => [.. labels.Select(r => new DomainLabelAst(AstNulls.At, "", false, r)).Prepend(new(AstNulls.At, "", true, Label))];
}
