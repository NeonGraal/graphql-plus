using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseInputArgTests(
  ICheckObjectArg<IGqlpObjArg> objectArgChecks
) : TestObjectArg<IGqlpObjArg>(objectArgChecks)
{ }

internal sealed class ParseInputArgChecks(
  Parser<IGqlpObjArg>.DA parser
) : CheckObjectArg<IGqlpObjArg, InputArgAst>(new InputFactories(), parser)
{ }
