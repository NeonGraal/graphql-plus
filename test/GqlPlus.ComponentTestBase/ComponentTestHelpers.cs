using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus;

public static class ComponentTestHelpers
{
  public static IGqlpSchema Schema(this IEnumerable<IGqlpDeclaration> declarations)
    => new TestSchema(declarations);
  public static IGqlpSchema Schema(this IGqlpDeclaration declaration)
    => new TestSchema([declaration]);
}

public class TestSchema(IEnumerable<IGqlpDeclaration> declarations)
  : IGqlpSchema
{
  public IEnumerable<IGqlpDeclaration> Declarations => declarations;
  public ParseResultKind Result { get; }
  public IMessages Errors { get; } = Messages.New;
  public ITokenAt At { get; } = AstNulls.At;
  public string Abbr { get; } = "S";

  public bool Equals(IGqlpAbbreviated? other) => false;
  public bool Equals(IGqlpSchema? other) => false;
  public IEnumerable<string?> GetFields() => throw new NotImplementedException();
  public IMessages MakeError(string message) => throw new NotImplementedException();
}
