using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseDualFieldTests(
  ICheckObjectField<IGqlpDualField> checks
) : TestObjectField<IGqlpDualField>(checks)
{ }

internal sealed class ParseDualFieldChecks(
  Parser<IGqlpDualField>.D parser
) : CheckObjectField<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualBaseAst, DualArgAst>(new DualFactories(), parser)
{ }
