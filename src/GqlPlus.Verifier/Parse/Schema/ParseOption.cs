using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseOption(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<NullAst>.D option,
  Parser<OptionDefinition>.D definition
  ) : DeclarationParser<ISimpleName, NullAst, NullAst, OptionDefinition, OptionDeclAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(OptionDeclAst result, OptionDefinition value)
    => result.Settings = value.Settings;

  protected override bool ApplyOption(OptionDeclAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameters(OptionDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override OptionDeclAst MakeResult(TokenAt at, string? name, string description)
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
      var setting = _setting.Parse(tokens, "Option Setting");
      if (!setting.Required(values.Add)) {
        result.Settings = [.. values];
        return setting.AsResult(result);
      }
    }

    result.Settings = [.. values];
    return result.Ok();
  }
}
