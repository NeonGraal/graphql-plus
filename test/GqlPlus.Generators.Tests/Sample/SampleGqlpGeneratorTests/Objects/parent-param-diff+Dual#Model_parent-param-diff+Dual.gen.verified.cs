//HintName: Model_parent-param-diff+Dual.gen.cs
// Generated from parent-param-diff+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_param_diff_Dual;

public interface IPrntParamDiffDual<Ta>
  : IRefPrntParamDiffDual
{
  Ta field { get; }
}
public class DualPrntParamDiffDual<Ta>
  : DualRefPrntParamDiffDual
  , IPrntParamDiffDual<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamDiffDual<Tb>
{
  Tb Asb { get; }
}
public class DualRefPrntParamDiffDual<Tb>
  : IRefPrntParamDiffDual<Tb>
{
  public Tb Asb { get; set; }
}
