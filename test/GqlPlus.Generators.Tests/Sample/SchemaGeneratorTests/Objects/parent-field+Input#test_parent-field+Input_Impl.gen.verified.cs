//HintName: test_parent-field+Input_Impl.gen.cs
// Generated from parent-field+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public testNumber field { get; set; }
  public testPrntFieldInp PrntFieldInp { get; set; }
}

public class testRefPrntFieldInp
  : ItestRefPrntFieldInp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntFieldInp RefPrntFieldInp { get; set; }
}
