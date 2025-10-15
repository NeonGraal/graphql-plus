//HintName: test_parent-dual+Input_Impl.gen.cs
// Generated from parent-dual+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public class InputtestPrntDualInp
  : InputtestRefPrntDualInp
  , ItestPrntDualInp
{
}

public class DualtestRefPrntDualInp
  : ItestRefPrntDualInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
