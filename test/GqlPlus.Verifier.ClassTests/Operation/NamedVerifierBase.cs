// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using GqlPlus.Verifying;
using GqlPlus.Verifying.Operation;

namespace GqlPlus.Operation;

public abstract class NamedVerifierBase<TUsage, TNamed>
  : VerifierBase
  where TUsage : class, IGqlpError
  where TNamed : class, IGqlpNamed
{
  private readonly ForV<TUsage> _usage = new();
  private readonly ForV<TNamed> _definition = new();

  protected IVerify<TUsage> Usage => _usage.Intf;
  protected IVerify<TNamed> Definition => _definition.Intf;

  [Fact]
  public void Verify_WithNone()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier();

    UsageNamed<TUsage, TNamed> item = new([], []);

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    _usage.NotCalled();
    _definition.NotCalled();
    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_WithDefinition()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier();

    UsageNamed<TUsage, TNamed> item = new([], OneDefinition("defined"));

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    _usage.NotCalled();
    _definition.Called();
    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_WithUsage()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier();

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), []);

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    _usage.Called();
    _definition.NotCalled();
    Errors.Count.ShouldBe(1);
  }

  [Fact]
  public void Verify_WithDifferent()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier();

    UsageNamed<TUsage, TNamed> item = new(OneUsage("usage"), OneDefinition("defined"));

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    _usage.Called();
    _definition.Called();
    Errors.Count.ShouldBe(2);
  }

  [Fact]
  public void Verify_WithMatching()
  {
    NamedVerifier<TUsage, TNamed> verifier = NewVerifier();

    UsageNamed<TUsage, TNamed> item = new(OneUsage("match"), OneDefinition("match"));

    verifier.Verify(item, Errors);

    // using AssertionScope scope = new();

    _usage.Called();
    _definition.Called();
    Errors.ShouldBeEmpty();
  }

  internal abstract NamedVerifier<TUsage, TNamed> NewVerifier();
  protected abstract IEnumerable<TNamed> OneDefinition(string name);
  protected abstract IEnumerable<TUsage> OneUsage(string key);
}
