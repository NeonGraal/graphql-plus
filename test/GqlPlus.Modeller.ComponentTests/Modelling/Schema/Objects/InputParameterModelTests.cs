using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Schema.Objects;

public class InputParamModelTests(
  ICheckDescribedModel<string, InputParamModel> checks
) : TestDescribedModel<string, InputParamModel>(checks)
{ }

internal sealed class InputParamModelChecks(
  IModeller<IGqlpInputParam, InputParamModel> modeller,
  IEncoder<InputParamModel> encoding
) : CheckDescribedModel<string, IGqlpInputParam, InputParamModel>(modeller, encoding)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<string> input)
    => ["!_InputParam", .. input.ExpectedDescription, "name: " + input.Name];

  protected override InputParamAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
