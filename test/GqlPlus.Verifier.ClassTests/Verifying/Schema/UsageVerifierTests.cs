using GqlPlus.Verifying.Schema;

namespace GqlPlus.Verifying.Schema;

public class UsageVerifierTests
  : SubstituteBase
{
  [Fact]
  public void Verify_WhenCalled_DelegatesToValue()
  {
    IVerifyUsage<IAstAliased> inner = A.Of<IVerifyUsage<IAstAliased>>();
    UsageAliased<IAstAliased> item = new([], []);
    IMessages errors = A.Of<IMessages>();

    UsageVerifier<IAstAliased> verifier = new(() => inner);

    verifier.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsUsageVerifier()
  {
    IVerifyUsage<IAstAliased> inner = A.Of<IVerifyUsage<IAstAliased>>();
    UsageAliased<IAstAliased> item = new([], []);
    IMessages errors = A.Of<IMessages>();

    UsageVerifier<IAstAliased>.D factory = () => inner;
    UsageVerifier<IAstAliased> result = factory;

    result.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    UsageVerifier<IAstAliased>.D? factory = null;

    Action result = () => _ = (UsageVerifier<IAstAliased>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
