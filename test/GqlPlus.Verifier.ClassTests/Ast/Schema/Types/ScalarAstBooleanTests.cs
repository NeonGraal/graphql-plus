﻿namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarAstBooleanTests
  : AstScalarTests<bool, ScalarTrueFalseAst>
{
  protected override string MembersString(string name, bool input)
    => $"( !S {name} Boolean !STF {input} )";
  protected override AstScalar<ScalarTrueFalseAst> NewScalar(string name, ScalarTrueFalseAst[] list)
    => new(AstNulls.At, name, ScalarDomain.Boolean, list);
  protected override ScalarTrueFalseAst[] ScalarMembers(bool input)
    => [new(AstNulls.At, false, input)];
}
