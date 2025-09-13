using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseInputTests(
  ICheckObject<IGqlpInputObject> objectChecks
) : TestObject<IGqlpInputObject>(objectChecks)
{ }

internal sealed class ParseInputChecks(
  Parser<IGqlpInputObject>.D parser
) : CheckObject<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, InputBaseAst, IGqlpObjArg, InputArgAst>(new InputFactories(), parser)
{ }
