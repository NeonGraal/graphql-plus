using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class ParseEnumChecks
  : BaseAliasedParserChecks<EnumInput, EnumDeclAst>
{
  public ParseEnumChecks(Parser<EnumDeclAst>.D parser)
    : base(parser) { }

  protected internal override EnumDeclAst AliasedFactory(EnumInput input)
    => new(AstNulls.At, input.Name) { Labels = new[] { input.Label }.EnumLabels(), };

  protected internal override string AliasesString(EnumInput input, string aliases)
    => input.Name + aliases + "{" + input.Label + "}";
}

public record struct EnumInput(string Name, string Label);
