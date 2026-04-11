using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

public class VerifyDomainRangeTests()
  : AstDomainVerifierTestsBase<IAstDomainRange>(DomainKind.Number)
{ }
