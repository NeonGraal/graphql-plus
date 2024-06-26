﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class UnionDeclAst(
  TokenAt At,
  string Name,
  string Description,
  UnionMemberAst[] Members
) : AstSimple<UnionMemberAst>(At, Name, Description, Members)
  , IEquatable<UnionDeclAst>
  , IGqlpUnion
{
  internal override string Abbr => "Un";
  public override string Label => "Union";

  IEnumerable<IGqlpUnionItem> IGqlpSimple<IGqlpUnionItem>.Items => Members;

  public UnionDeclAst(TokenAt at, string name, UnionMemberAst[] members)
    : this(at, name, "", members) { }

  public bool HasValue(string value)
    => Members.Select(a => a.Name).Contains(value);
}
