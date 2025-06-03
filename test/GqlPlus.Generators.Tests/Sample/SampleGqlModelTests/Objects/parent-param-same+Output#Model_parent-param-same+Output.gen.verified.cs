//HintName: Model_parent-param-same+Output.gen.cs
// Generated from parent-param-same+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_Output;

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
