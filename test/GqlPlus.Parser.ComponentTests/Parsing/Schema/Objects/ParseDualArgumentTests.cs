﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualArgTests(
  ICheckObjectArg<IGqlpDualArg> checks
) : TestObjectArg<IGqlpDualArg>(checks)
{ }

internal sealed class ParseDualArgChecks(
  Parser<IGqlpDualArg>.DA parser
) : CheckObjectArg<IGqlpDualArg, DualArgAst>(new DualFactories(), parser)
{ }
