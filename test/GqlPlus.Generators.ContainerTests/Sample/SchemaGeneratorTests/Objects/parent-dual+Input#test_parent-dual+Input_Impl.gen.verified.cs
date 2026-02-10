//HintName: test_parent-dual+Input_Impl.gen.cs
// Generated from parent-dual+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
  public ItestPrntDualInpObject AsPrntDualInp { get; set; }
}

public class testRefPrntDualInp
  : ItestRefPrntDualInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualInpObject AsRefPrntDualInp { get; set; }
}
