//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  public ItestNumber AsNumber { get; set; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntAltInpObject
{
  public ItestNumber Parent { get; set; }
}
