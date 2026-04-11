using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseOutputTests(
  ICheckObject<IAstOutputField> objectChecks
) : TestObject<IAstOutputField>(objectChecks)
{ }

internal sealed class ParseOutputChecks(
  IParserRepository parsers
) : CheckObject<IAstOutputField, OutputFieldAst>(new OutputFactories(), parsers)
{ }
