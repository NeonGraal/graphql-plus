//HintName: test_parent-descr+Input_Intf.gen.cs
// Generated from parent-descr+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
  public testPrntDescrInp PrntDescrInp { get; set; }
}

public interface ItestPrntDescrInpField
  : ItestRefPrntDescrInpField
{
}

public interface ItestRefPrntDescrInp
{
  public testString AsString { get; set; }
  public testRefPrntDescrInp RefPrntDescrInp { get; set; }
}

public interface ItestRefPrntDescrInpField
{
  public testNumber parent { get; set; }
}
