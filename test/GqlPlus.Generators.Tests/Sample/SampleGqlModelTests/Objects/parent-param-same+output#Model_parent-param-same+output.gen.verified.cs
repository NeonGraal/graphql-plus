//HintName: Model_parent-param-same+output.gen.cs
// Generated from parent-param-same+output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_output;

public interface IOutpPrntParamSame<Ta>
  : IRefOutpPrntParamSame
{
  Ta field { get; }
}
public class OutputOutpPrntParamSame<Ta>
  : OutputRefOutpPrntParamSame
  , IOutpPrntParamSame<Ta>
{
  public Ta field { get; set; }
}

public interface IRefOutpPrntParamSame<Ta>
{
  Ta Asa { get; }
}
public class OutputRefOutpPrntParamSame<Ta>
  : IRefOutpPrntParamSame<Ta>
{
  public Ta Asa { get; set; }
}
