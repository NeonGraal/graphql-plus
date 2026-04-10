using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : IdentifiedVerifierTestsBase<IGqlpSpread, IAstFragment>
{
  protected override IEnumerable<IAstFragment> OneDefinition(string name)
  {
    IAstFragment definition = A.Error<IAstFragment>();
    definition.Identifier.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpSpread> OneUsage(string key)
  {
    IGqlpSpread usage = A.Error<IGqlpSpread>();
    usage.Identifier.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpSpread, IAstFragment> NewVerifier()
    => new VerifyFragmentUsage(VerifierRepo);
}
