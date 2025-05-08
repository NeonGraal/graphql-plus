using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseEnum(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<EnumDefinition>.D definition
) : DeclarationParser<EnumDefinition, IGqlpEnum>(name, param, aliases, option, definition)
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
{
  internal string? Parent { get; set; }
  internal EnumLabelAst[] Values { get; set; } = [];
}

internal class ParseEnumDefinition(
  Parser<IGqlpEnumLabel>.D enumLabel
) : Parser<EnumDefinition>.I
{
  private readonly Parser<IGqlpEnumLabel>.L _enumLabel = enumLabel;

  public IResult<EnumDefinition> Parse(ITokenizer tokens, string label)

  {
    EnumDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out string? parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<IGqlpEnumLabel> labels = [];
    while (!tokens.Take("}")) {
      IResult<IGqlpEnumLabel> enumLabel = _enumLabel.Parse(tokens, "Enum Label");
      if (!enumLabel.Required(labels.Add)) {
        result.Values = labels.ArrayOf<EnumLabelAst>();
        return enumLabel.AsResult(result);
      }
    }

    result.Values = labels.ArrayOf<EnumLabelAst>();
    return labels.Count != 0
      ? result.Ok()
      : tokens.Partial(label, "at least one label", () => result);
  }
}
