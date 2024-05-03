using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Globals;

internal class ParseOption(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<OptionDefinition>.D definition
  ) : DeclarationParser<OptionDefinition, OptionDeclAst>(name, param, aliases, option, definition)
{
  protected override OptionDeclAst MakeResult(OptionDeclAst result, OptionDefinition value)
  {
    result.Settings = value.Settings;

    return result;
  }

  protected override bool ApplyOption(OptionDeclAst result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(OptionDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override OptionDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class OptionDefinition
{
  internal OptionSettingAst[] Settings { get; set; } = [];
}

internal class ParseOptionDefinition(
  Parser<OptionSettingAst>.D setting
) : Parser<OptionDefinition>.I
{
  private readonly Parser<OptionSettingAst>.L _setting = setting;

  public IResult<OptionDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    OptionDefinition result = new();

    List<OptionSettingAst> values = [];
    while (!tokens.Take("}")) {
      IResult<OptionSettingAst> setting = _setting.Parse(tokens, "Option Setting");
      if (!setting.Required(values.Add)) {
        result.Settings = [.. values];
        return setting.AsResult(result);
      }
    }

    result.Settings = [.. values];
    return result.Ok();
  }
}
