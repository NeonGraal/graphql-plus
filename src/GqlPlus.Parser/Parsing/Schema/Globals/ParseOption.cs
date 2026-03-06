using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseOption(
  ISimpleName name,
  IParserRepository parsers
) : DeclarationParser<OptionDefinition, IGqlpSchemaOption>(
    name,
    parsers.GetArray<NullAst>(),
    parsers.GetArray<string>(),
    parsers.GetInterface<IOptionParser<NullOption>, NullOption>(),
    parsers.Get<OptionDefinition>())
{
  protected override IGqlpSchemaOption MakeResult(AstPartial<NullAst, NullOption> partial, OptionDefinition value)
        => new OptionDeclAst(partial.At, partial.Name, partial.Description) {
          Aliases = partial.Aliases,
          Settings = value.Settings,
        };

  protected override IGqlpSchemaOption ToResult(AstPartial<NullAst, NullOption> partial)
    => new OptionDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
    };
}

internal class OptionDefinition
{
  internal OptionSettingAst[] Settings { get; set; } = [];
}

internal class ParseOptionDefinition(
  IParserRepository parsers
) : Parser<OptionDefinition>.I
{
  private readonly Parser<IGqlpSchemaSetting>.L _setting = parsers.Get<IGqlpSchemaSetting>();

  public IResult<OptionDefinition> Parse(ITokenizer tokens, string label)

  {
    OptionDefinition result = new();

    List<IGqlpSchemaSetting> values = [];
    while (!tokens.Take('}')) {
      IResult<IGqlpSchemaSetting> setting = _setting.Parse(tokens, "Option Setting");
      if (!setting.Required(values.Add)) {
        result.Settings = values.ArrayOf<OptionSettingAst>();
        return result.Partial(setting.Message());
      }
    }

    result.Settings = values.ArrayOf<OptionSettingAst>();
    return result.Ok();
  }
}
