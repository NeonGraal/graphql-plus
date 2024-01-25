﻿namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstEnumTests
  : AstScalarTests<ScalarMemberInput, ScalarMemberAst>
{
  protected override string MembersString(string name, ScalarMemberInput input)
    => $"( !S {name} Enum !SM {input} )";
  protected override AstScalar<ScalarMemberAst> NewScalar(string name, ScalarMemberAst[] list)
    => new(AstNulls.At, name, ScalarKind.Enum, list);
  protected override ScalarMemberAst[] ScalarMembers(ScalarMemberInput input)
    => [new ScalarMemberAst(AstNulls.At, false, input.EnumMember) { EnumType = input.EnumType }];
}

public record struct ScalarMemberInput(string EnumType, string EnumMember)
{
  public override readonly string? ToString()
    => $"{EnumType} {EnumMember}";
}
