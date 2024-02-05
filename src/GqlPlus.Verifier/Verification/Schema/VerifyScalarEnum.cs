using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarEnum(
  IMerge<ScalarMemberAst> members
) : AstScalarVerifier<ScalarMemberAst>(members)
{
  protected override void VerifyScalar(AstScalar<ScalarMemberAst> scalar, EnumContext context)
  {
    EnumMembers members = new();

    foreach (var member in scalar.Items) {
      if (string.IsNullOrWhiteSpace(member.EnumType)) {
        if (context.GetEnumValue(member.Member, out var enumType)) {
          member.EnumType = enumType;
          if (context.GetEnumType(member.EnumType, out var theType)) {
            members.Add(member.Excludes, theType, member.Member);
          }
        } else {
          context.AddError(member, "Scalar Enum Member", $"Enum Value '{member.Member}' not defined");
        }
      } else if (context.GetEnumType(member.EnumType, out var theType)) {
        if (member.Member == "*") {
          AddAllMembers(members, context, member.Excludes, theType);
        } else if (context.GetEnumValueType(theType, member.Member, out var memberType)) {
          members.Add(member.Excludes, memberType, member.Member);
        } else {
          context.AddError(member, "Scalar Enum Value", $"'{member.Member}' not a Value of '{member.EnumType}'");
        }
      } else {
        context.AddError(member, "Scalar Enum", $"'{member.EnumType}' not an Enum type");
      }
    }

    foreach (var duplicate in members.DuplicateMembers()) {
      var member = duplicate[0].Member;
      var enums = duplicate.Select(x => x.Enum.Name).Joined();
      context.AddError(scalar, "Scalar Enum", $"'{member}' duplicated from these Enums: {enums}");
    }
  }

  private static void AddAllMembers(EnumMembers members, EnumContext context, bool excludes, EnumDeclAst enumType)
  {
    foreach (var enumMember in enumType.Members) {
      members.Add(excludes, enumType, enumMember.Name);
    }

    if (context.GetEnumType(enumType.Parent, out var parentType)) {
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
    var enumMember = theEnum.Members.First(m => m.Name == theMember || m.Aliases.Contains(theMember));
    if (excluded) {
      _excludes.Add(new(theEnum, enumMember.Name));
    } else {
      _includes.Add(new(theEnum, enumMember.Name));
    }
  }

  internal EnumMember[][] DuplicateMembers()
  {
    var allMembers = _includes
      .Except(_excludes)
      .GroupBy(m => m.Member);

    return allMembers
      .Where(g => g.Count() != 1)
      .Select(g => g.ToArray())
      .ToArray();
  }
}
