using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierTestsBase<IGqlpArg, IGqlpVariable>
{
  protected override IEnumerable<IGqlpVariable> OneDefinition(string name)
  {
    IGqlpVariable definition = A.Variable(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpArg> OneUsage(string key)
  {
    IGqlpArg usage = A.Error<IGqlpArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpArg, IGqlpVariable> NewVerifier()
    => new VerifyVariableUsage(Usage, Definition);
}
