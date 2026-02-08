//HintName: test_parent-dual+Input_Intf.gen.cs
// Generated from parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  public ItestPrntDualInpObject AsPrntDualInp { get; set; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
{
  public ItestString AsString { get; set; }
  public ItestRefPrntDualInpObject AsRefPrntDualInp { get; set; }
}

public interface ItestRefPrntDualInpObject
{
  public ItestNumber Parent { get; set; }
}
