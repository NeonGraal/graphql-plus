namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarAstEnumTests
  : AstScalarTests<ScalarMemberInput, ScalarMemberAst>
{
  protected override string MembersString(string name, ScalarMemberInput input)
    => $"( !S {name} Enum !SM {input.EnumType} {input.EnumMember} )";
  protected override AstScalar<ScalarMemberAst> NewScalar(string name, ScalarMemberAst[] list)
    => new(AstNulls.At, name, ScalarDomain.Enum, list);
  protected override ScalarMemberAst[] ScalarMembers(ScalarMemberInput input)
    => [new ScalarMemberAst(AstNulls.At, false, input.EnumMember) { EnumType = input.EnumType }];
}

public record struct ScalarMemberInput(string EnumType, string EnumMember);
