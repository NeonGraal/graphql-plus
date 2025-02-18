using GqlPlus.Abstractions.Operation;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : NamedVerifierBase<IGqlpArg, IGqlpVariable>
{
  protected override IEnumerable<IGqlpVariable> OneDefinition(string name)
  {
    IGqlpVariable definition = EFor<IGqlpVariable>();
    definition.Name.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpArg> OneUsage(string key)
  {
    IGqlpArg usage = EFor<IGqlpArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override NamedVerifier<IGqlpArg, IGqlpVariable> NewVerifier()
    => new VerifyVariableUsage(Usage, Definition);
}
