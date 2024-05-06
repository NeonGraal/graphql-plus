using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainEnum(
  IMerge<DomainMemberAst> members
) : AstDomainVerifier<DomainMemberAst>(members)
{
  protected override void VerifyDomain(IGqlpDomain<DomainMemberAst> domain, EnumContext context)
  {
    EnumMembers members = new();

    foreach (DomainMemberAst member in domain.Items) {
      if (string.IsNullOrWhiteSpace(member.EnumType)) {
        if (context.GetEnumValue(member.Member, out string? enumType)) {
          member.EnumType = enumType;
          if (context.GetEnumType(member.EnumType, out EnumDeclAst? theType)) {
            members.Add(member.Excludes, theType, member.Member);
          }
        } else {
          context.AddError(member, "Domain Enum Member", $"Enum Value '{member.Member}' not defined");
        }
      } else if (context.GetEnumType(member.EnumType, out EnumDeclAst? theType)) {
        if (member.Member == "*") {
          AddAllMembers(members, context, member.Excludes, theType);
        } else if (context.GetEnumValueType(theType, member.Member, out EnumDeclAst? memberType)) {
          members.Add(member.Excludes, memberType, member.Member);
        } else {
          context.AddError(member, "Domain Enum Value", $"'{member.Member}' not a Value of '{member.EnumType}'");
        }
      } else {
        context.AddError(member, "Domain Enum", $"'{member.EnumType}' not an Enum type");
      }
    }

    foreach (EnumMember[] duplicate in members.DuplicateMembers()) {
      string member = duplicate[0].Member;
      string enums = duplicate.Select(x => x.Enum.Name).Joined();
      context.AddError(domain, "Domain Enum", $"'{member}' duplicated from these Enums: {enums}");
    }
  }

  private static void AddAllMembers(EnumMembers members, EnumContext context, bool excludes, EnumDeclAst enumType)
  {
    foreach (EnumMemberAst enumMember in enumType.Members) {
      members.Add(excludes, enumType, enumMember.Name);
    }

    if (context.GetEnumType(enumType.Parent, out EnumDeclAst? parentType)) {
      AddAllMembers(members, context, excludes, parentType);
    }
  }
}

internal record struct EnumMember(EnumDeclAst Enum, string Member);

internal class EnumMembers
{
  private readonly List<EnumMember> _includes = [];
  private readonly List<EnumMember> _excludes = [];

  internal void Add(bool excluded, EnumDeclAst theEnum, string theMember)
  {
    EnumMemberAst enumMember = theEnum.Members.First(m => m.Name == theMember || m.Aliases.Contains(theMember));
    if (excluded) {
      _excludes.Add(new(theEnum, enumMember.Name));
    } else {
      _includes.Add(new(theEnum, enumMember.Name));
    }
  }

  internal EnumMember[][] DuplicateMembers()
  {
    IEnumerable<IGrouping<string, EnumMember>> allMembers = _includes
      .Except(_excludes)
      .GroupBy(m => m.Member);

    return allMembers
      .Where(g => g.Count() != 1)
      .Select(g => g.ToArray())
      .ToArray();
  }
}
