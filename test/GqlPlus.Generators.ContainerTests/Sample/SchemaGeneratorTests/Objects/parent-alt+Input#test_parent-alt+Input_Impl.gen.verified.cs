//HintName: test_parent-alt+Input_Impl.gen.cs
// Generated from parent-alt+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public class testPrntAltInp
  : testRefPrntAltInp
  , ItestPrntAltInp
{
  public ItestNumber AsNumber { get; set; }
}

public class testRefPrntAltInp
  : ItestRefPrntAltInp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
