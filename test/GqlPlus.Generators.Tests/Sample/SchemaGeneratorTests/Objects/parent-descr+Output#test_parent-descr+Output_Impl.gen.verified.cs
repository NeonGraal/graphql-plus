//HintName: test_parent-descr+Output_Impl.gen.cs
// Generated from parent-descr+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public class testPrntDescrOutp
  : testRefPrntDescrOutp
  , ItestPrntDescrOutp
{
  public testPrntDescrOutp PrntDescrOutp { get; set; }
}

public class testRefPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDescrOutp RefPrntDescrOutp { get; set; }
}
