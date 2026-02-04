//HintName: test_parent-alt+Input_Impl.gen.cs
// Generated from parent-alt+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public class testPrntAltInp
  : testRefPrntAltInp
  , ItestPrntAltInp
{
  public testNumber AsNumber { get; set; }
  public testPrntAltInp PrntAltInp { get; set; }
}

public class testRefPrntAltInp
  : ItestRefPrntAltInp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntAltInp RefPrntAltInp { get; set; }
}
