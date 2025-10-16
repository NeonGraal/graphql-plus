//HintName: test_parent-dual+Input_Impl.gen.cs
// Generated from parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
}

public class testRefPrntDualInp
  : ItestRefPrntDualInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
