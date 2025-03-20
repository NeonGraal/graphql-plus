﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainMemberAst(
  TokenAt At,
  string Description,
  bool Excludes,
  string Member
) : AstDomainItem(At, Description, Excludes)
  , IEquatable<DomainMemberAst>
  , IGqlpDomainMember
{
  public string EnumType { get; set; } = "";

  internal override string Abbr => "DE";

  string IGqlpDomainMember.EnumItem => Member;

  public bool Equals(DomainMemberAst? other)
    => base.Equals(other)
      && Member.NullEqual(other.Member)
      && EnumType.NullEqual(other.EnumType);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Member, EnumType);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Excludes ? "!" : "")
      .Append(EnumType)
      .Append(Member);

  void IGqlpDomainMember.SetEnumType(string enumType)
    => EnumType ??= enumType;
}
