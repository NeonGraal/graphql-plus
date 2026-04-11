using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : IdentifiedVerifierTestsBase<IAstSpread, IAstFragment>
{
  [Fact]
  public void Verify_WithCycle()
  {
    IEnumerable<IAstSpread> usage1 = OneUsage("frag1");
    IEnumerable<IAstSpread> usage2 = OneUsage("frag2");

    IAstFragment definition1 = OneDefinition("frag1").First();
    definition1.Selections.Returns(usage2.Cast<IAstSelection>());
    IAstFragment definition2 = OneDefinition("frag2").First();
    definition2.Selections.Returns(usage1.Cast<IAstSelection>());

    UsageIdentified<IAstSpread, IAstFragment> item = new(usage1.Concat(usage2), [definition1, definition2]);

    VerifyWithErrors(item, 1);
  }

  protected override IEnumerable<IAstFragment> OneDefinition(string name)
  {
    IAstFragment definition = A.Error<IAstFragment>();
    definition.Identifier.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IAstSpread> OneUsage(string key)
  {
    IAstSpread usage = A.Error<IAstSpread>();
    usage.Identifier.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IAstSpread, IAstFragment> NewVerifier()
    => new VerifyFragmentUsage(VerifierRepo);
}
