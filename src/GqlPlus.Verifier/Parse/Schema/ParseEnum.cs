using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnum : DeclarationParser<TypeName, NullAst, NullAst, EnumDefinition, EnumAst>
{
  public ParseEnum(
    TypeName name,
    Parser<NullAst>.DA param,
    Parser<string>.DA aliases,
    Parser<NullAst>.D option,
    Parser<EnumDefinition>.D definition
  ) : base(name, param, aliases, option, definition)
  {
  }

  protected override void ApplyDefinition(EnumAst result, EnumDefinition value)
  {
    result.Extends = value.Extends;
    result.Labels = value.Labels;
  }

  protected override bool ApplyOption(EnumAst result, IResult<NullAst> option) => true;
  protected override bool ApplyParameters(EnumAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override EnumAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class EnumDefinition
{
  internal string? Extends { get; set; }
  internal EnumLabelAst[] Labels { get; set; } = Array.Empty<EnumLabelAst>();
}

internal class ParseEnumDefinition : Parser<EnumDefinition>.I
{
  private readonly Parser<EnumLabelAst>.L _enumLabel;

  public ParseEnumDefinition(Parser<EnumLabelAst>.D enumLabel)
    => _enumLabel = enumLabel;

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

    List<EnumLabelAst> labels = [];
    while (!tokens.Take("}")) {
      var enumLabel = _enumLabel.Parse(tokens, "Enum Label");
      if (!enumLabel.Required(labels.Add)) {
        result.Labels = labels.ToArray();
        return enumLabel.AsResult(result);
      }
    }

    result.Labels = labels.ToArray();
    return labels.Any()
      ? result.Ok()
      : tokens.Partial(label, "at least one label", () => result);
  }
}

internal class TypeName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
  {
    at = tokens.At;
    return tokens.Identifier(out name);
  }
}
