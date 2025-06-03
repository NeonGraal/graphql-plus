//HintName: Model_parent-param-same+Dual.gen.cs
// Generated from parent-param-same+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_Dual;

public interface IDualPrntParamSame<Ta>
  : IRefDualPrntParamSame
{
  Ta field { get; }
}
public class DualDualPrntParamSame<Ta>
  : DualRefDualPrntParamSame
  , IDualPrntParamSame<Ta>
{
  public Ta field { get; set; }
}

public interface IRefDualPrntParamSame<Ta>
{
  Ta Asa { get; }
}
public class DualRefDualPrntParamSame<Ta>
  : IRefDualPrntParamSame<Ta>
{
  public Ta Asa { get; set; }
}
