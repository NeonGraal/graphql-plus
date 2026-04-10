using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : IdentifiedVerifierTestsBase<IAstSpread, IAstFragment>
{
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
