using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnum(
  SimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<NullAst>.D option,
  Parser<EnumDefinition>.D definition
  ) : DeclarationParser<SimpleName, NullAst, NullAst, EnumDefinition, EnumDeclAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(EnumDeclAst result, EnumDefinition value)
  {
    result.Extends = value.Extends;
    result.Values = value.Values;
  }

  protected override bool ApplyOption(EnumDeclAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameters(EnumDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override EnumDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class EnumDefinition
{
  internal string? Extends { get; set; }
  internal EnumValueAst[] Values { get; set; } = [];
}

internal class ParseEnumDefinition(
  Parser<EnumValueAst>.D enumValue
) : Parser<EnumDefinition>.I
{
  private readonly Parser<EnumValueAst>.L _enumValue = enumValue;

  public IResult<EnumDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    EnumDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var extends)) {
        result.Extends = extends;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<EnumValueAst> values = [];
    while (!tokens.Take("}")) {
      var enumValue = _enumValue.Parse(tokens, "Enum Value");
      if (!enumValue.Required(values.Add)) {
        result.Values = [.. values];
        return enumValue.AsResult(result);
      }
    }

    result.Values = [.. values];
    return values.Count != 0
      ? result.Ok()
      : tokens.Partial(label, "at least one value", () => result);
  }
}
