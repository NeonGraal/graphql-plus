using GqlPlus.Verifying;

namespace GqlPlus.Verifying;

public class VerifierTests
  : SubstituteBase
{
  [Fact]
  public void Verify_WhenCalled_DelegatesToValue()
  {
    IVerify<IAstError> inner = A.Of<IVerify<IAstError>>();
    IAstError item = A.Of<IAstError>();
    IMessages errors = A.Of<IMessages>();

    Verifier<IAstError> verifier = new(() => inner);

    verifier.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsVerifier()
  {
    IVerify<IAstError> inner = A.Of<IVerify<IAstError>>();
    IAstError item = A.Of<IAstError>();
    IMessages errors = A.Of<IMessages>();

    Verifier<IAstError>.D factory = () => inner;
    Verifier<IAstError> result = factory;

    result.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Verifier<IAstError>.D? factory = null;

    Action result = () => _ = (Verifier<IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
