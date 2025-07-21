//HintName: Gqlp_parent-param-same+Output_Impl.gen.cs
// Generated from parent-param-same+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_param_same_Output;
public class OutputPrntParamSameOutp<Ta>
  : OutputRefPrntParamSameOutp
  , IPrntParamSameOutp<Ta>
{
  public Ta field { get; set; }
}
public class OutputRefPrntParamSameOutp<Ta>
  : IRefPrntParamSameOutp<Ta>
{
  public Ta Asa { get; set; }
}
