using System.ComponentModel;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarEnum
  : AstScalarVerifier<ScalarMemberAst>
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
          foreach (var enumMember in theType.Members) {
            members.Add(member.Excludes, theType, enumMember.Name);
          }
        } else if (context.GetEnumValueType(theType, member.Member, out var memberType)) {
          members.Add(member.Excludes, memberType, member.Member);
        } else {
          context.AddError(member, "Scalar Enum Value", $"'{member.Member}' not a Value of '{member.EnumType}'");
        }
      } else {
        context.AddError(member, "Scalar Enum", $"'{member.EnumType}' not an Enum type");
      }
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
}
