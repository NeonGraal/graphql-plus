//HintName: test_parent-field+Input_Impl.gen.cs
// Generated from parent-field+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public decimal Field { get; set; }
  public ItestPrntFieldInpObject AsPrntFieldInp { get; set; }
}

public class testRefPrntFieldInp
  : ItestRefPrntFieldInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntFieldInpObject AsRefPrntFieldInp { get; set; }
}
