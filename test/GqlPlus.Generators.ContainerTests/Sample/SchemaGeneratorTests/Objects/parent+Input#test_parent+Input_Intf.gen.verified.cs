//HintName: test_parent+Input_Intf.gen.cs
// Generated from parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
  public testPrntInp PrntInp { get; set; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
{
  public testString AsString { get; set; }
  public testRefPrntInp RefPrntInp { get; set; }
}

public interface ItestRefPrntInpObject
{
  public testNumber parent { get; set; }
}
