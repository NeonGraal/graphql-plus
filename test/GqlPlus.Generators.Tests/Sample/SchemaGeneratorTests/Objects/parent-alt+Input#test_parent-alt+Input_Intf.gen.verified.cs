//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  public testNumber AsNumber { get; set; }
  public testPrntAltInp PrntAltInp { get; set; }
}

public interface ItestPrntAltInpField
  : ItestRefPrntAltInpField
{
}

public interface ItestRefPrntAltInp
{
  public testString AsString { get; set; }
  public testRefPrntAltInp RefPrntAltInp { get; set; }
}

public interface ItestRefPrntAltInpField
{
  public testNumber parent { get; set; }
}
