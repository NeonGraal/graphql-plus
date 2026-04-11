using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

public class VerifyDomainRegexTests()
  : AstDomainVerifierTestsBase<IAstDomainRegex>(DomainKind.String)
{ }
