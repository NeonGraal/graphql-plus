using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Simple;

internal class ParseUnion(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<UnionDefinition>.D definition
) : DeclarationParser<UnionDefinition, IGqlpUnion>(name, param, aliases, option, definition)
{
  protected override IGqlpUnion MakeResult(AstPartial<NullAst, NullOption> partial, UnionDefinition value)
    => new UnionDeclAst(partial.At, partial.Name, partial.Description, value.Values) {
      Aliases = partial.Aliases,
      Parent = value.Parent,
    };

  protected override IGqlpUnion ToResult(AstPartial<NullAst, NullOption> partial)
    => new UnionDeclAst(partial.At, partial.Name, partial.Description, []) {
      Aliases = partial.Aliases,
    };
}

internal class UnionDefinition
{
  internal string? Parent { get; set; }
  internal UnionMemberAst[] Values { get; set; } = [];
}

internal class ParseUnionDefinition(
  Parser<UnionMemberAst>.D unionMember
) : Parser<UnionDefinition>.I
{
  private readonly Parser<UnionMemberAst>.L _unionMember = unionMember;

  public IResult<UnionDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    UnionDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out string? parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<UnionMemberAst> members = [];
    while (!tokens.Take("}")) {
      IResult<UnionMemberAst> unionMember = _unionMember.Parse(tokens, "Union Member");
      if (!unionMember.Required(members.Add)) {
        result.Values = [.. members];
        return unionMember.AsResult(result);
      }
    }

    result.Values = [.. members];
    return members.Count != 0
      ? result.Ok()
      : tokens.Partial(label, "at least one member", () => result);
  }
}
