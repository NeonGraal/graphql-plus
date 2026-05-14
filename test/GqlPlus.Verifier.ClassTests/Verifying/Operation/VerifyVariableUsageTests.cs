using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierTestsBase<IAstArg, IAstVariable>
{
  protected override IEnumerable<IAstVariable> OneDefinition(string name)
  {
    IAstVariable definition = A.Identified<IAstVariable>(name);

    return [definition];
  }

  protected override IEnumerable<IAstArg> OneUsage(string key)
  {
    IAstArg usage = A.Error<IAstArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifierBase<IAstArg, IAstVariable> NewVerifier()
    => new VerifyVariableUsage(VerifierRepo);
}
