﻿using GqlPlus.Abstractions.Operation;

namespace GqlPlus;

public static class OperationBuilderHelpers
{
  public static IGqlpVariable Variable(this IMockBuilder builder, string name)
  {
    IGqlpVariable result = builder.Error<IGqlpVariable>();
    result.Identifier.Returns(name);
    return result;
  }
}
