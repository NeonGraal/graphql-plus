using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualFieldTests(
  ICheckObjectField<IGqlpDualField> checks
) : TestObjectField<IGqlpDualField>(checks)
{ }

internal sealed class ParseDualFieldChecks(
  Parser<IGqlpDualField>.D parser
) : CheckObjectField<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualBaseAst, IGqlpDualArgument, DualArgumentAst>(new DualFactories(), parser)
{ }
