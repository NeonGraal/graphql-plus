//HintName: Model_parent-param-same+Dual.gen.cs
// Generated from parent-param-same+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_param_same_Dual;

public interface IPrntParamSameDual<Ta>
  : IRefPrntParamSameDual
{
  Ta field { get; }
}
public class DualPrntParamSameDual<Ta>
  : DualRefPrntParamSameDual
  , IPrntParamSameDual<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamSameDual<Ta>
{
  Ta Asa { get; }
}
public class DualRefPrntParamSameDual<Ta>
  : IRefPrntParamSameDual<Ta>
{
  public Ta Asa { get; set; }
}
