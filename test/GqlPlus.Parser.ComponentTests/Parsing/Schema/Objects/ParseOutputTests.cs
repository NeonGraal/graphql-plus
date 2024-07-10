using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests(
  ICheckObject<IGqlpOutputObject> objectChecks
) : TestObject<IGqlpOutputObject>(objectChecks)
{ }

internal sealed class ParseOutputChecks(
  Parser<IGqlpOutputObject>.D parser
) : CheckObject<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArgument, OutputArgumentAst>(new OutputFactories(), parser)
{ }
