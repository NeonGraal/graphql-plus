using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseEnum(
  ISimpleName name,
  IParserRepository parsers
) : SimpleParser<EnumDefinition, IGqlpEnum>(
    name,
    parsers.GetArray<NullAst>(),
    parsers.GetArray<string>(),
    parsers.GetInterface<IOptionParser<NullOption>, NullOption>(),
    parsers.Get<EnumDefinition>())
{
  protected override IGqlpEnum MakeResult(AstPartial<NullAst, NullOption> partial, EnumDefinition value)
    => new EnumDeclAst(partial.At, partial.Name, partial.Description, value.Values) {
      Aliases = partial.Aliases,
      Parent = value.Parent,
    };

  protected override IGqlpEnum ToResult(AstPartial<NullAst, NullOption> partial)
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
) : SimpleDefinitionParser<EnumDefinition>(parsers.Get<IGqlpTypeRef>())
{
  private readonly Parser<IGqlpEnumLabel>.L _enumLabel = parsers.Get<IGqlpEnumLabel>();

  public override IResult<EnumDefinition> Parse(ITokenizer tokens, string label)
  {
    EnumDefinition result = new();

    if (!ParseParent(tokens, result)) {
      return tokens.Error(label, "parent type after ':'", result);
    }

    List<IGqlpEnumLabel> labels = [];
    while (!tokens.Take('}')) {
      IResult<IGqlpEnumLabel> enumLabel = _enumLabel.Parse(tokens, "Enum Label");
      if (!enumLabel.Required(labels.Add)) {
        result.Values = labels.ArrayOf<EnumLabelAst>();
        return result.Partial(enumLabel.Message());
      }
    }

    result.Values = labels.ArrayOf<EnumLabelAst>();
    return result.Ok();
  }
}
