//HintName: test_parent-field+Input_Intf.gen.cs
// Generated from parent-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  public testPrntFieldInp PrntFieldInp { get; set; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  public testNumber field { get; set; }
}

public interface ItestRefPrntFieldInp
{
  public testString AsString { get; set; }
  public testRefPrntFieldInp RefPrntFieldInp { get; set; }
}

public interface ItestRefPrntFieldInpObject
{
  public testNumber parent { get; set; }
}
