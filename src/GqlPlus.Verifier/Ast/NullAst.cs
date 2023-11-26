using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Ast;

public record class NullAst(ParseAt At)
{
  [ExcludeFromCodeCoverage]
  public override string ToString() => "NULL";
}
