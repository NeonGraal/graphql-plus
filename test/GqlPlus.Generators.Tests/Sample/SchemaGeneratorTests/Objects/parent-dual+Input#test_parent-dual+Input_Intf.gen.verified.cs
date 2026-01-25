//HintName: test_parent-dual+Input_Intf.gen.cs
// Generated from parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  public testPrntDualInp PrntDualInp { get; set; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
{
  public testString AsString { get; set; }
  public testRefPrntDualInp RefPrntDualInp { get; set; }
}

public interface ItestRefPrntDualInpObject
{
  public testNumber parent { get; set; }
}
