//HintName: test_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  public testPrntOutp PrntOutp { get; set; }
}

public interface ItestPrntOutpField
  : ItestRefPrntOutpField
{
}

public interface ItestRefPrntOutp
{
  public testString AsString { get; set; }
  public testRefPrntOutp RefPrntOutp { get; set; }
}

public interface ItestRefPrntOutpField
{
  public testNumber parent { get; set; }
}
