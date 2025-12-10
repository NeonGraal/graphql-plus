using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public partial class DualFactoriesTests
{
  [CheckTests]
  private IObjectFactoriesChecks Checks { get; }
    = new ObjectFactoriesChecks<IGqlpDualField, DualFieldAst>(new DualFactories());
}

public partial class InputFactoriesTests
{
  [CheckTests]
  private IObjectFactoriesChecks Checks { get; }
    = new ObjectFactoriesChecks<IGqlpInputField, InputFieldAst>(new InputFactories());
}

public partial class OutputFactoriesTests
{
  [CheckTests]
  private IObjectFactoriesChecks Checks { get; }
    = new ObjectFactoriesChecks<IGqlpOutputField, OutputFieldAst>(new OutputFactories());
}
