using GqlPlus.Abstractions.Operation;
using GqlPlus.Verifying.Operation;
using NSubstitute;

namespace GqlPlus.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierBase<IGqlpArg, IGqlpVariable>
{
  protected override IEnumerable<IGqlpVariable> OneDefinition(string name)
  {
    IGqlpVariable definition = EFor<IGqlpVariable>();
    definition.Identifier.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpArg> OneUsage(string key)
  {
    IGqlpArg usage = EFor<IGqlpArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpArg, IGqlpVariable> NewVerifier()
    => new VerifyVariableUsage(Usage, Definition);
}
