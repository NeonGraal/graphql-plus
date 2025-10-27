//HintName: test_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public Number field { get; set; }
}

public class testRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
