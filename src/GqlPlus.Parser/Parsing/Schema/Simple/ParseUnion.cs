﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal class ParseUnion(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<UnionDefinition>.D definition
) : SimpleParser<UnionDefinition, IGqlpUnion>(name, param, aliases, option, definition)
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
  : SimpleDefinition
{
  internal UnionMemberAst[] Values { get; set; } = [];
}

internal class ParseUnionDefinition(
  Parser<IGqlpTypeRef>.D typeRef,
  Parser<IGqlpUnionMember>.D unionMember
) : SimpleDefinitionParser<UnionDefinition>(typeRef)
{
  private readonly Parser<IGqlpUnionMember>.L _unionMember = unionMember;

  public override IResult<UnionDefinition> Parse(ITokenizer tokens, string label)
  {
    UnionDefinition result = new();

    if (!ParseParent(tokens, result)) {
      return tokens.Error(label, "parent type after ':'", result);
    }

    List<IGqlpUnionMember> members = [];
    while (!tokens.Take('}')) {
      IResult<IGqlpUnionMember> unionMember = _unionMember.Parse(tokens, "Union Member");
      if (!unionMember.Required(members.Add)) {
        result.Values = members.ArrayOf<UnionMemberAst>();
        return result.Partial(unionMember.Message());
      }
    }

    result.Values = members.ArrayOf<UnionMemberAst>();
    return result.Ok();
  }
}
