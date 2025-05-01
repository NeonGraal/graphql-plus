using GqlPlus.Verification;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Verifying;

public class NullVerifierTests
  : VerifierBase
{
  [Fact]
  public void Verify_ShouldLogNullVerification()
  {
    // Arrange
    NullVerifierError<IGqlpError> verifier = new(LoggerFactory);
    IGqlpError mockItem = For<IGqlpError>();
    ITokenMessages mockErrors = For<ITokenMessages>();

    // Act
    verifier.Verify(mockItem, mockErrors);

    // Assert
    LoggerCalled(LogLevel.Information, "Null verification");
  }
}
