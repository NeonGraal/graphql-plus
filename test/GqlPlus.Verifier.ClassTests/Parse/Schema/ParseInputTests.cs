﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputTests : BaseObjectTests
{
  internal override IBaseObjectChecks Checks => Test;

  private static BaseObjectChecks<InputAst, InputFieldAst, InputReferenceAst> Test => new(
    new InputFactories(),
    (SchemaParser parser, out InputAst? result) => parser.ParseInputDeclaration(out result, ""));
}
