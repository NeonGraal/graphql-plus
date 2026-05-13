using GqlPlus.Ast.Operation;
using GqlPlus.Verifying.Operation;

namespace GqlPlus.Verifying.Operation;

public class IdentifiedVerifierTests
  : SubstituteBase
{
  [Fact]
  public void Verify_WhenCalled_DelegatesToValue()
  {
    IVerifyIdentified<IAstError, IAstIdentified> inner = A.Of<IVerifyIdentified<IAstError, IAstIdentified>>();
    UsageIdentified<IAstError, IAstIdentified> item = new([], []);
    IMessages errors = A.Of<IMessages>();

    IdentifiedVerifier<IAstError, IAstIdentified> verifier = new(() => inner);

    verifier.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_FromDelegate_ReturnsIdentifiedVerifier()
  {
    IVerifyIdentified<IAstError, IAstIdentified> inner = A.Of<IVerifyIdentified<IAstError, IAstIdentified>>();
    UsageIdentified<IAstError, IAstIdentified> item = new([], []);
    IMessages errors = A.Of<IMessages>();

    IdentifiedVerifier<IAstError, IAstIdentified>.D factory = () => inner;
    IdentifiedVerifier<IAstError, IAstIdentified> result = factory;

    result.Verify(item, errors);

    inner.Received(1).Verify(item, errors);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    IdentifiedVerifier<IAstError, IAstIdentified>.D? factory = null;

    Action result = () => _ = (IdentifiedVerifier<IAstError, IAstIdentified>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
