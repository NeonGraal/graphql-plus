//HintName: test_parent-alt+Input_Impl.gen.cs
// Generated from parent-alt+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public class InputtestPrntAltInp
  : InputtestRefPrntAltInp
  , ItestPrntAltInp
{
  public Number AsNumber { get; set; }
}

public class InputtestRefPrntAltInp
  : ItestRefPrntAltInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
