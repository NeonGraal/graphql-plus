﻿namespace GqlPlus.Ast.Operation;

public class OperationAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<OperationAst>(name => new OperationAst(AstNulls.At, name));

  protected override string DirectiveString(string input, string directives)
    => $"( !g query {input} Failure{directives} )";
}
