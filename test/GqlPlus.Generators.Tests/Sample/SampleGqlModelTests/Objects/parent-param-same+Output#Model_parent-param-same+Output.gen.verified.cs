//HintName: Model_parent-param-same+Output.gen.cs
// Generated from parent-param-same+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_param_same_Output;

public interface IPrntParamSameOutp<Ta>
  : IRefPrntParamSameOutp
{
  Ta field { get; }
}
public class OutputPrntParamSameOutp<Ta>
  : OutputRefPrntParamSameOutp
  , IPrntParamSameOutp<Ta>
{
  public Ta field { get; set; }
}

public interface IRefPrntParamSameOutp<Ta>
{
  Ta Asa { get; }
}
public class OutputRefPrntParamSameOutp<Ta>
  : IRefPrntParamSameOutp<Ta>
{
  public Ta Asa { get; set; }
}
