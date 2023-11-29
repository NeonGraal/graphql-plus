using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Ast;

[ExcludeFromCodeCoverage]
public record class NullAst(ParseAt At)
{
  public override string ToString() => "NULL";
}
