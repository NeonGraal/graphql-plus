using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierTestsBase<IGqlpArg, IGqlpVariable>
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
