//HintName: test_parent-dual+Input_Impl.gen.cs
// Generated from parent-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
  public testPrntDualInp PrntDualInp { get; set; }
}

public class testRefPrntDualInp
  : ItestRefPrntDualInp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntDualInp RefPrntDualInp { get; set; }
}
