using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputTests(
  ICheckObject<IGqlpInputObject> objectChecks
) : TestObject<IGqlpInputObject>(objectChecks)
{ }

internal sealed class ParseInputChecks(
  Parser<IGqlpInputObject>.D parser
) : CheckObject<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, InputBaseAst, IGqlpInputArg, InputArgAst>(new InputFactories(), parser)
{ }
