using GqlPlus.Abstractions.Operation;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : NamedVerifierBase<IGqlpSpread, IGqlpFragment>
{
  protected override IEnumerable<IGqlpFragment> OneDefinition(string name)
  {
    IGqlpFragment definition = For<IGqlpFragment>();
    definition.Name.Returns(name);
    definition.MakeError("").ReturnsForAnyArgs(MakeMessages);

    return [definition];
  }

  protected override IEnumerable<IGqlpSpread> OneUsage(string key)
  {
    IGqlpSpread usage = For<IGqlpSpread>();
    usage.Name.Returns(key);
    usage.MakeError("").ReturnsForAnyArgs(MakeMessages);

    return [usage];
  }

  internal override NamedVerifier<IGqlpSpread, IGqlpFragment> NewVerifier(IVerify<IGqlpSpread> usage, IVerify<IGqlpFragment> definition)
    => new VerifyFragmentUsage(usage, definition);
}
