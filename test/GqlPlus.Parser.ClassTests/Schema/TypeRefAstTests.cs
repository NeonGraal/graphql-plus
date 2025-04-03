using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Schema;

public class TypeRefAstTests
  : AstNamedTests
{
  internal sealed override IAstNamedChecks NamedChecks { get; }
    = new AstNamedChecks<TypeRefAst>(name => new TypeRefAst(AstNulls.At, name));
}
