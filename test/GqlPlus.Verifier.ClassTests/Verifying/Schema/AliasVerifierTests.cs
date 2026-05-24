namespace GqlPlus.Verifying.Schema;

public class AliasVerifierTests
  : SubstituteBase
{
  [Fact]
  public void Verify_WhenCalled_DelegatesToValue()
  {
    IVerifyAliased<IAstAliased> inner = A.Of<IVerifyAliased<IAstAliased>>();
    IAstAliased[] items = [A.Of<IAstAliased>()];
    IMessages errors = A.Of<IMessages>();

    AliasVerifier<IAstAliased> verifier = new(() => inner);

    verifier.Verify(items, errors);

    inner.Received(1).Verify(items, errors);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsAliasVerifier()
  {
    IVerifyAliased<IAstAliased> inner = A.Of<IVerifyAliased<IAstAliased>>();
    IAstAliased[] items = [A.Of<IAstAliased>()];
    IMessages errors = A.Of<IMessages>();

    AliasVerifier<IAstAliased>.D factory = () => inner;
    AliasVerifier<IAstAliased> result = factory;

    result.Verify(items, errors);

    inner.Received(1).Verify(items, errors);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    AliasVerifier<IAstAliased>.D? factory = null;

    Action result = () => _ = (AliasVerifier<IAstAliased>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
