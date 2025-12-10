using GqlPlus.Parsing.Schema;

namespace GqlPlus.Ast.Schema;

public partial class AstPartialTests
{
  private readonly AstPartialChecks _checks = new();

  [CheckTests(Inherited = true)]
  internal IAstDeclarationChecks AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, AstPartial<NullAst, NullOption>>(
      CreatePartial,
      (original, input) => original with { Name = input });

  internal static AstPartial<NullAst, NullOption> CreatePartial(string input)
    => new(AstNulls.At, input, "");
}

internal sealed class AstPartialChecks()
  : AstDeclarationChecks<AstPartial<NullAst, NullOption>>(AstPartialTests.CreatePartial)
{
  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} (Unique) None )";

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
