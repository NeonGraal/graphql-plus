//HintName: Model_parent-param-diff+dual.gen.cs
// Generated from parent-param-diff+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_param_diff_dual;

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
