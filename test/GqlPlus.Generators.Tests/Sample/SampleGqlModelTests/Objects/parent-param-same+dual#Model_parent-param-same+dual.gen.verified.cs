//HintName: Model_parent-param-same+dual.gen.cs
// Generated from parent-param-same+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_dual;

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
