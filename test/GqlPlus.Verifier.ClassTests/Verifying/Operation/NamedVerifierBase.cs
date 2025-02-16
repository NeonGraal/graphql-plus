using GqlPlus.Token;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public abstract class NamedVerifierBase<TUsage, TNamed>
  : VerifierBase
  where TUsage : class, IGqlpError
  where TNamed : class, IGqlpNamed
{
  [Fact]
  public void Verify_WithNone()
  {
    IVerify<TUsage> usage = VFor<TUsage>();
    IVerify<TNamed> definition = VFor<TNamed>();
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(usage, definition);

    UsageNamed<TUsage, TNamed> item = new([], []);
    ITokenMessages errors = new TokenMessages();

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usage.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TUsage>(), errors);
    definition.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TNamed>(), errors);
    errors.Should().BeNullOrEmpty();
  }

  [Fact]
  public void Verify_WithDefinition()
  {
    IVerify<TUsage> usage = VFor<TUsage>();
    IVerify<TNamed> definition = VFor<TNamed>();
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(usage, definition);

    UsageNamed<TUsage, TNamed> item = new([], OneDefinition("defined"));
    TokenMessages errors = [];

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usage.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TUsage>(), errors);
    definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), errors);
    errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_WithUsage()
  {
    IVerify<TUsage> usage = VFor<TUsage>();
    IVerify<TNamed> definition = VFor<TNamed>();
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(usage, definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), []);
    TokenMessages errors = [];

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), errors);
    definition.DidNotReceiveWithAnyArgs().Verify(Arg.Any<TNamed>(), errors);
    errors.Count.Should().Be(1);
  }

  [Fact]
  public void Verify_WithDifferent()
  {
    IVerify<TUsage> usage = VFor<TUsage>();
    IVerify<TNamed> definition = VFor<TNamed>();
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(usage, definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), OneDefinition("defined"));
    TokenMessages errors = [];

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), errors);
    definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), errors);
    errors.Count.Should().Be(2);
  }

  [Fact]
  public void Verify_WithMatching()
  {
    IVerify<TUsage> usage = VFor<TUsage>();
    IVerify<TNamed> definition = VFor<TNamed>();
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier(usage, definition);

    UsageNamed<TUsage, TNamed> item = new(OneUsage("match"), OneDefinition("match"));
    TokenMessages errors = [];

    verifier.Verify(item, errors);

    using AssertionScope scope = new();

    usage.ReceivedWithAnyArgs().Verify(Arg.Any<TUsage>(), errors);
    definition.ReceivedWithAnyArgs().Verify(Arg.Any<TNamed>(), errors);
    errors.Should().BeNullOrEmpty();
  }

  internal abstract NamedVerifier<TUsage, TNamed> NewVerifier(IVerify<TUsage> usage, IVerify<TNamed> definition);
  protected abstract IEnumerable<TNamed> OneDefinition(string name);
  protected abstract IEnumerable<TUsage> OneUsage(string key);
}
