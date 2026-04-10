using GqlPlus.Abstractions.Operation;

namespace GqlPlus;

public static class OperationBuilderHelpers
{
  public static IAstVariable Variable(this IMockBuilder builder, string name)
  {
    IAstVariable result = builder.Error<IAstVariable>();
    result.Identifier.Returns(name);
    return result;
  }
}
