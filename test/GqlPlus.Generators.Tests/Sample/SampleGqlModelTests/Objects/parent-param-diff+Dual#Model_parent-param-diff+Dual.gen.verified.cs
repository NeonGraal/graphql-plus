//HintName: Model_parent-param-diff+Dual.gen.cs
// Generated from parent-param-diff+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_Dual;

public interface IDualPrntParamDiff<Ta>
  : IRefDualPrntParamDiff
{
  Ta field { get; }
}
public class DualDualPrntParamDiff<Ta>
  : DualRefDualPrntParamDiff
  , IDualPrntParamDiff<Ta>
{
  public Ta field { get; set; }
}

public interface IRefDualPrntParamDiff<Tb>
{
  Tb Asb { get; }
}
public class DualRefDualPrntParamDiff<Tb>
  : IRefDualPrntParamDiff<Tb>
{
  public Tb Asb { get; set; }
}
