using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Ast;

internal interface IAstDirectives
{
  DirectiveAst[] Directives { get; set; }
}
