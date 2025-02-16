using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace GqlPlus.Verifying.Operation;

[TracePerTest]
public class VerifyVariableTests
  : VerifierBase
{
  [Fact]
  public void Verify_NoModifiersOrDefault()
  {
    VerifyVariable verifier = new();

    IGqlpVariable item = For<IGqlpVariable>();
    item.DefaultValue.ReturnsNull();
    ITokenMessages errors = new TokenMessages();

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_JustDefault()
  {
    VerifyVariable verifier = new();

    IGqlpConstant defValue = For<IGqlpConstant>();
    IGqlpVariable item = For<IGqlpVariable>();
    item.DefaultValue.Returns(defValue);
    ITokenMessages errors = new TokenMessages();

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_NullDefault()
  {
    VerifyVariable verifier = new();

    IGqlpFieldKey value = For<IGqlpFieldKey>();
    value.EnumValue.Returns("Null.null");

    IGqlpConstant defValue = For<IGqlpConstant>();
    defValue.Value.Returns(value);
    defValue.MakeError("").ReturnsForAnyArgs(MakeMessages);

    IGqlpVariable item = For<IGqlpVariable>();
    item.DefaultValue.Returns(defValue);
    TokenMessages errors = new TokenMessages();

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    errors.Count.Should().Be(1);
  }
}
