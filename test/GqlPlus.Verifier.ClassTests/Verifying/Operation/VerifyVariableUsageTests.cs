using GqlPlus.Abstractions.Operation;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : NamedVerifierBase<IGqlpArg, IGqlpVariable>
{
  protected override IEnumerable<IGqlpVariable> OneDefinition(string name)
  {
    IGqlpVariable definition = For<IGqlpVariable>();
    definition.Name.Returns(name);
    definition.MakeError("").ReturnsForAnyArgs(MakeMessages);

    return [definition];
  }

  protected override IEnumerable<IGqlpArg> OneUsage(string key)
  {
    IGqlpArg usage = For<IGqlpArg>();
    usage.Variable.Returns(key);
    usage.MakeError("").ReturnsForAnyArgs(MakeMessages);

    return [usage];
  }

  internal override NamedVerifier<IGqlpArg, IGqlpVariable> NewVerifier(IVerify<IGqlpArg> usage, IVerify<IGqlpVariable> definition)
    => new VerifyVariableUsage(usage, definition);
}
