using GqlPlus.Ast;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Verifying;

public class NullVerifierTests
  : VerifierTestsBase
{
  [Fact]
  public void Verify_ShouldLogNullVerification()
  {
    // Arrange
    NullVerifierError<IAstError> verifier = new(VerifierRepo);
    IAstError mockItem = A.Of<IAstError>();
    IMessages mockErrors = A.Of<IMessages>();

    // Act
    verifier.Verify(mockItem, mockErrors);

    // Assert
    LoggerCalled(LogLevel.Information, "Null verification");
  }
}
