using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Simple;

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
  internal EnumMemberAst[] Values { get; set; } = [];
}

internal class ParseEnumDefinition(
  Parser<EnumMemberAst>.D enumMember
) : Parser<EnumDefinition>.I
{
  private readonly Parser<EnumMemberAst>.L _enumMember = enumMember;

  public IResult<EnumDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    EnumDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out string? parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<EnumMemberAst> members = [];
    while (!tokens.Take("}")) {
      IResult<EnumMemberAst> enumMember = _enumMember.Parse(tokens, "Enum Member");
      if (!enumMember.Required(members.Add)) {
        result.Values = [.. members];
        return enumMember.AsResult(result);
      }
    }

    result.Values = [.. members];
    return members.Count != 0
      ? result.Ok()
      : tokens.Partial(label, "at least one member", () => result);
  }
}
