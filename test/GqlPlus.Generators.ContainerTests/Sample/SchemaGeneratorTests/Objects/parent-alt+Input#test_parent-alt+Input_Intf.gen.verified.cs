//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltInpObject AsPrntAltInp { get; set; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
{
  public string AsString { get; set; }
  public ItestRefPrntAltInpObject AsRefPrntAltInp { get; set; }
}

public interface ItestRefPrntAltInpObject
{
  public decimal Parent { get; set; }
}
