using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseOutputTests(
  ICheckObject<IGqlpOutputObject> objectChecks
) : TestObject<IGqlpOutputObject>(objectChecks)
{ }

internal sealed class ParseOutputChecks(
  Parser<IGqlpOutputObject>.D parser
) : CheckObject<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(new OutputFactories(), parser)
{ }
