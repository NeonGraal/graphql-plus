using System.Globalization;

namespace GqlPlus.Ast.Schema.Simple;

public partial class DomainRangeAstTests
{
  [CheckTests(Inherited = true)]
  private IAstAbbreviatedChecks<DomainRangeInput> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<DomainRangeInput, DomainRangeAst>(CreateRange);

  [CheckTests]
  internal ICloneChecks<DomainRangeInput> CloneChecks { get; }
    = new CloneChecks<DomainRangeInput, DomainRangeAst>(CreateRange, CloneRange);

  private static DomainRangeAst CloneRange(DomainRangeAst original, DomainRangeInput input)
    => original with { Lower = input.Lower, Upper = input.Upper };
  private static DomainRangeAst CreateRange(DomainRangeInput input)
    => new(AstNulls.At, (input.Lower ?? input.Upper ?? 0m).ToString(CultureInfo.InvariantCulture), false, input.Lower, input.Upper);
}
