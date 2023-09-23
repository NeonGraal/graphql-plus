using System.Reflection.Metadata.Ecma335;
using GqlPlus.Verifier;
// Licensed to the .NET Foundation under one or more agreements.

namespace GqlPlus.Verifier
{
  internal class OperationParser
  {
    internal static OperationAst? Parse(string operation)
    {
      return new OperationAst { Result = ParseResult.Success };
    }
  }
}
