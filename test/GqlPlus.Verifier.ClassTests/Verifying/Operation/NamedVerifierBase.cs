using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public abstract class NamedVerifierBase<TUsage, TNamed>
  : VerifierBase
  where TUsage : class, IGqlpError
  where TNamed : class, IGqlpNamed
{
  private readonly IVerify<TUsage> _usage = VFor<TUsage>();
  private readonly IVerify<TNamed> _definition = VFor<TNamed>();
  private readonly TokenMessages _errors = [];

  [Fact]
  public void Verify_WithNone()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(_usage, _definition);

    UsageNamed<TUsage, TNamed> item = new([], []);

    verifier.Verify(item, _errors);

    using AssertionScope scope = new();

    _usage.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TUsage>(), _errors);
    _definition.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TNamed>(), _errors);
    _errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_WithDefinition()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(_usage, _definition);

    UsageNamed<TUsage, TNamed> item = new([], OneDefinition("defined"));

    verifier.Verify(item, _errors);

    using AssertionScope scope = new();

    _usage.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TUsage>(), _errors);
    _definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), _errors);
    _errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_WithUsage()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(_usage, _definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), []);

    verifier.Verify(item, _errors);

    using AssertionScope scope = new();

    _usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), _errors);
    _definition.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TNamed>(), _errors);
    _errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_WithDifferent()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(_usage, _definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), OneDefinition("defined"));

    verifier.Verify(item, _errors);

    using AssertionScope scope = new();

    _usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), _errors);
    _definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), _errors);
    _errors.Count.Should().Be(2);
  }

  [Fact]
  public void Verify_WithMatching()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(_usage, _definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("match"), OneDefinition("match"));

    verifier.Verify(item, _errors);

    using AssertionScope scope = new();

    _usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), _errors);
    _definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), _errors);
    _errors.Should().BeNullOrEmpty();
  }

  internal abstract NamedVerifier<TUsage, TNamed> NewVerifier(IVerify<TUsage> usage, IVerify<TNamed> definition);
  protected abstract IEnumerable<TNamed> OneDefinition(string name);
  protected abstract IEnumerable<TUsage> OneUsage(string key);
}
