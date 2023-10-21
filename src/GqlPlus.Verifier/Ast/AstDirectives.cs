using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Ast;

internal interface AstDirectives
{
  DirectiveAst[] Directives { get; set; }
}
