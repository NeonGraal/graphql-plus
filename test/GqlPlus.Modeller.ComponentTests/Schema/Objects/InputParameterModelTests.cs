﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class InputParamModelTests(
  ICheckDescribedModel<string, InputParamModel> checks
) : TestDescribedModel<string, InputParamModel>(checks)
{ }

internal sealed class InputParamModelChecks(
  IModeller<IGqlpInputParam, InputParamModel> modeller,
  IRenderer<InputParamModel> rendering
) : CheckDescribedModel<string, IGqlpInputParam, InputParamModel>(modeller, rendering)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<string> input)
    => ["!_InputParam", .. input.ExpectedDescription, "input: " + input.Name];

  protected override InputParamAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
