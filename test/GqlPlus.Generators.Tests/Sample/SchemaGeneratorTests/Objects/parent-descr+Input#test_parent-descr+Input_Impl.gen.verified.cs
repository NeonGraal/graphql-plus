//HintName: test_parent-descr+Input_Impl.gen.cs
// Generated from parent-descr+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
  public testPrntDescrInp PrntDescrInp { get; set; }
}

public class testRefPrntDescrInp
  : ItestRefPrntDescrInp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDescrInp RefPrntDescrInp { get; set; }
}
