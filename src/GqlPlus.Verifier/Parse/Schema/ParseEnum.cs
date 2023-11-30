using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnum : DeclarationParser<TypeName, NullAst, NullAst, EnumDefinition, EnumAst>
{
  public ParseEnum(
    TypeName name,
    IParser<NullAst> param,
    IParserArray<string> aliases,
    IParser<NullAst> option,
    IParser<EnumDefinition> definition
  ) : base(name, param, aliases, option, definition)
  {
  }

  protected override string Label => "Enum";

  protected override void ApplyDefinition(EnumAst result, EnumDefinition value)
  {
    result.Extends = value.Extends;
    result.Labels = value.Labels;
  }

  protected override bool ApplyOption(EnumAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameter(EnumAst result, IResult<NullAst> parameter) => true;

  [return: NotNull]
  protected override EnumAst MakeResult(ParseAt at, string? name, string description)
    => new(at, name!, description);
}

internal class EnumDefinition
{
  internal string? Extends { get; set; }
  internal EnumLabelAst[] Labels { get; set; } = Array.Empty<EnumLabelAst>();
}

internal class ParseEnumDefinition : IParser<EnumDefinition>
{
  private readonly IParser<EnumLabelAst> _enumLabel;

  public ParseEnumDefinition(IParser<EnumLabelAst> enumLabel)
    => _enumLabel = enumLabel.ThrowIfNull();

  public IResult<EnumDefinition> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    EnumDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var extends)) {
        result.Extends = extends;
      } else {
        return tokens.Error("Enum", "type after ':'", result);
      }
    }

    List<EnumLabelAst> labels = new();
    while (!tokens.Take("}")) {
      var enumLabel = _enumLabel.Parse(tokens);
      if (!enumLabel.Required(labels.Add)) {
        result.Labels = labels.ToArray();
        return enumLabel.AsResult(result);
      }
    }

    result.Labels = labels.ToArray();
    return labels.Any()
      ? result.Ok()
      : tokens.Partial("Enum", "at least one label", () => result);
  }
}

internal class TypeName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out ParseAt at)
  {
    at = tokens.At;
    return tokens.Identifier(out name);
  }
}
