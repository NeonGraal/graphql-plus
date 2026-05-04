using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnion(
  IParserRepository parsers
) : SimpleParser<UnionDefinition, IAstUnion>(parsers)
{
  protected override IAstUnion MakeResult(AstPartial<NullAst, NullOption> partial, UnionDefinition value)
    => new UnionDeclAst(partial.At, partial.Name, partial.Description, value.Values) {
      Aliases = partial.Aliases,
      Parent = value.Parent,
    };

  protected override IAstUnion ToResult(AstPartial<NullAst, NullOption> partial)
    => new UnionDeclAst(partial.At, partial.Name, partial.Description, []) {
      Aliases = partial.Aliases,
    };

  internal static ParseUnion Factory(IParserRepository p) => new(p);
}

internal class UnionDefinition
  : SimpleDefinition
{
  internal UnionMemberAst[] Values { get; set; } = [];
}

internal class ParseUnionDefinition(
  IParserRepository parsers
) : SimpleDefinitionParser<UnionDefinition>(parsers)
{
  private readonly Parser<IAstUnionMember>.L _unionMember = parsers.ParserFor<IAstUnionMember>();

  public override IResult<UnionDefinition> Parse(ITokenizer tokens, string label)
  {
    UnionDefinition result = new();

    if (!ParseParent(tokens, result)) {
      return tokens.Error(label, "parent type after ':'", result);
    }

    List<IAstUnionMember> members = [];
    while (!tokens.Take('}')) {
      IResult<IAstUnionMember> unionMember = _unionMember.Parse(tokens, "Union Member");
      if (!unionMember.Required(members.Add)) {
        result.Values = members.ArrayOf<UnionMemberAst>();
        return result.Partial(unionMember.Message());
      }
    }

    result.Values = members.ArrayOf<UnionMemberAst>();
    return result.Ok();
  }

  internal static ParseUnionDefinition Factory(IParserRepository p) => new(p);
}
