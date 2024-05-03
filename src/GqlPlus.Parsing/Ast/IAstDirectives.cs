using GqlPlus.Ast.Operation;

namespace GqlPlus.Ast;

internal interface IAstDirectives
{
  DirectiveAst[] Directives { get; set; }
}
