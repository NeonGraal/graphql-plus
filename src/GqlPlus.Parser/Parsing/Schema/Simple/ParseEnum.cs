using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseEnum(
  IParserRepository parsers
) : SimpleParser<EnumDefinition, IAstEnum>(parsers)
{
  protected override IAstEnum MakeResult(AstPartial<NullAst, NullOption> partial, EnumDefinition value)
    => new EnumDeclAst(partial.At, partial.Name, partial.Description, value.Values) {
      Aliases = partial.Aliases,
      Parent = value.Parent,
    };

  protected override IAstEnum ToResult(AstPartial<NullAst, NullOption> partial)
    => new EnumDeclAst(partial.At, partial.Name, partial.Description, []) {
      Aliases = partial.Aliases,
    };
}

internal class EnumDefinition
  : SimpleDefinition
{
  internal EnumLabelAst[] Values { get; set; } = [];
}

internal class ParseEnumDefinition(
  IParserRepository parsers
) : SimpleDefinitionParser<EnumDefinition>(parsers)
{
  private readonly Parser<IAstEnumLabel>.L _enumLabel = parsers.ParserFor<IAstEnumLabel>();

  public override IResult<EnumDefinition> Parse(ITokenizer tokens, string label)
  {
    EnumDefinition result = new();

    if (!ParseParent(tokens, result)) {
      return tokens.Error(label, "parent type after ':'", result);
    }

    List<IAstEnumLabel> labels = [];
    while (!tokens.Take('}')) {
      IResult<IAstEnumLabel> enumLabel = _enumLabel.Parse(tokens, "Enum Label");
      if (!enumLabel.Required(labels.Add)) {
        result.Values = labels.ArrayOf<EnumLabelAst>();
        return result.Partial(enumLabel.Message());
      }
    }

    result.Values = labels.ArrayOf<EnumLabelAst>();
    return result.Ok();
  }
}
