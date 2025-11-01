//HintName: test_parent+Input_Impl.gen.cs
// Generated from parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
  public testPrntInp PrntInp { get; set; }
}

public class testRefPrntInp
  : ItestRefPrntInp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntInp RefPrntInp { get; set; }
}
