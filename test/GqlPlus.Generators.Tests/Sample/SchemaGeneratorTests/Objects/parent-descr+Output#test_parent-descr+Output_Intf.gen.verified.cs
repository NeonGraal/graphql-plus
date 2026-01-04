//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from parent-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public testPrntDescrOutp PrntDescrOutp { get; set; }
}

public interface ItestPrntDescrOutpField
  : ItestRefPrntDescrOutpField
{
}

public interface ItestRefPrntDescrOutp
{
  public testString AsString { get; set; }
  public testRefPrntDescrOutp RefPrntDescrOutp { get; set; }
}

public interface ItestRefPrntDescrOutpField
{
  public testNumber parent { get; set; }
}
