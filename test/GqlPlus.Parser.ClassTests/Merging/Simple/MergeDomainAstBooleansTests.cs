using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainAstBooleansTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainTrueFalseAst, bool>(outputHelper)
{
  protected override DomainTrueFalseAst[] MakeItems(bool input)
    => new[] { input }.DomainTrueFalses();

  protected override AstDomain<DomainTrueFalseAst> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new(AstNulls.At, name, description, DomainKind.Boolean) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
