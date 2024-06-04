using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainEnum(
  IMerge<IGqlpDomainMember> members
) : AstDomainVerifier<IGqlpDomainMember>(members)
{
  protected override void VerifyDomain(IGqlpDomain<IGqlpDomainMember> domain, EnumContext context)
  {
    EnumMembers members = new();

    foreach (IGqlpDomainMember member in domain.Items) {
      if (string.IsNullOrWhiteSpace(member.EnumType)) {
        if (context.GetEnumValue(member.EnumItem, out string? enumType)) {
          member.SetEnumType(enumType);
          if (context.GetEnumType(member.EnumType, out IGqlpEnum? theType)) {
            members.Add(member.Excludes, theType, member.EnumItem);
          }
        } else {
          context.AddError(member, "Domain Enum Member", $"Enum Value '{member.EnumItem}' not defined");
        }
      } else if (context.GetEnumType(member.EnumType, out IGqlpEnum? theType)) {
        if (member.EnumItem == "*") {
          AddAllMembers(members, context, member.Excludes, theType);
        } else if (context.GetEnumValueType(theType, member.EnumItem, out IGqlpEnum? memberType)) {
          members.Add(member.Excludes, memberType, member.EnumItem);
        } else {
          context.AddError(member, "Domain Enum Value", $"'{member.EnumItem}' not a Value of '{member.EnumType}'");
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

  private static void AddAllMembers(EnumMembers members, EnumContext context, bool excludes, IGqlpEnum enumType)
  {
    foreach (IGqlpEnumItem enumMember in enumType.Items) {
      members.Add(excludes, enumType, enumMember.Name);
    }

    if (context.GetEnumType(enumType.Parent, out IGqlpEnum? parentType)) {
      AddAllMembers(members, context, excludes, parentType);
    }
  }
}

internal record struct EnumMember(IGqlpEnum Enum, string Member);

internal class EnumMembers
{
  private readonly List<EnumMember> _includes = [];
  private readonly List<EnumMember> _excludes = [];

  internal void Add(bool excluded, IGqlpEnum theEnum, string theMember)
  {
    IGqlpEnumItem enumMember = theEnum.Items.First(m => m.Name == theMember || m.Aliases.Contains(theMember));
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
