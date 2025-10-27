//HintName: test_parent+Input_Impl.gen.cs
// Generated from parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
}

public class testRefPrntInp
  : ItestRefPrntInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
