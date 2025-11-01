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

public interface ItestPrntFieldInpField
  : ItestRefPrntFieldInpField
{
  public testNumber field { get; set; }
}

public interface ItestRefPrntFieldInp
{
  public testString AsString { get; set; }
  public testRefPrntFieldInp RefPrntFieldInp { get; set; }
}

public interface ItestRefPrntFieldInpField
{
  public testNumber parent { get; set; }
}
