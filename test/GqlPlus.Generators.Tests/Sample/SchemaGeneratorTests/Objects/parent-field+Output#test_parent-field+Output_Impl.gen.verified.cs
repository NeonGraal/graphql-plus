//HintName: test_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class OutputtestPrntFieldOutp
  : OutputtestRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public Number field { get; set; }
}

public class OutputtestRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
