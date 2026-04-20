using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus;

public static class ComponentTestHelpers
{
  public static IAstSchema Schema(this IEnumerable<IAstDeclaration> declarations)
    => new TestSchema(declarations);
  public static IAstSchema Schema(this IAstDeclaration declaration)
    => new TestSchema([declaration]);
}

public class TestSchema(IEnumerable<IAstDeclaration> declarations)
  : IAstSchema
{
  public IEnumerable<IAstDeclaration> Declarations => declarations;
  public ParseResultKind Result { get; }
  public IMessages Errors { get; } = Messages.New;
  public ITokenAt At { get; } = AstNulls.At;
  public string Abbr { get; } = "S";

  public bool Equals(IAstAbbreviated? other) => false;
  public bool Equals(IAstSchema? other) => false;
  public IEnumerable<string?> GetFields() => throw new NotImplementedException();
  public IMessages MakeError(string message) => throw new NotImplementedException();
}
