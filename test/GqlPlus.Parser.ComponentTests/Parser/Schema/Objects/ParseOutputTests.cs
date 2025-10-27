using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseOutputTests(
  ICheckObject<IGqlpOutputField> objectChecks
) : TestObject<IGqlpOutputField>(objectChecks)
{ }

internal sealed class ParseOutputChecks(
  Parser<IGqlpObject<IGqlpOutputField>>.D parser
) : CheckObject<IGqlpOutputField, OutputFieldAst>(new OutputFactories(), parser)
{ }
