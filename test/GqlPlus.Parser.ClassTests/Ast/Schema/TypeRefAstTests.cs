
namespace GqlPlus.Ast.Schema;

public class TypeRefAstTests
  : AstNamedTests<string>
{
  internal sealed override IAstNamedChecks NamedChecks { get; }
    = new AstNamedChecks<TypeRefAst>(CreateTypeRef, CloneTypeRef);

  private static TypeRefAst CloneTypeRef(TypeRefAst original, string input)
    => original with { Name = input };
  private static TypeRefAst CreateTypeRef(string input)
    => new(AstNulls.At, input);
}
