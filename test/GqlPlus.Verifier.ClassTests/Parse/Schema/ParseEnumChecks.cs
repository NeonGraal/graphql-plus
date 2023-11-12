using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseEnumChecks
  : BaseAliasedChecks<EnumInput, EnumAst>
{
  public ParseEnumChecks()
    : base(parser => parser.ParseEnumDeclarationNew(""))
  { }

  protected internal override EnumAst AliasedFactory(EnumInput input)
    => new(AstNulls.At, input.Name) { Labels = new[] { input.Label }.EnumLabels(), };

  protected internal override string AliasesString(EnumInput input, string aliases)
    => input.Name + aliases + "{" + input.Label + "}";
}

public record struct EnumInput(string Name, string Label);
