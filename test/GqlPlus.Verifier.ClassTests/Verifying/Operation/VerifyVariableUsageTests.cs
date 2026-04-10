using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierTestsBase<IGqlpArg, IAstVariable>
{
  protected override IEnumerable<IAstVariable> OneDefinition(string name)
  {
    IAstVariable definition = A.Variable(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpArg> OneUsage(string key)
  {
    IGqlpArg usage = A.Error<IGqlpArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpArg, IAstVariable> NewVerifier()
    => new VerifyVariableUsage(VerifierRepo);
}
