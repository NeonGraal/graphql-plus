//HintName: test_parent-alt+Output_Impl.gen.cs
// Generated from parent-alt+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public class testPrntAltOutp
  : testRefPrntAltOutp
  , ItestPrntAltOutp
{
  public testNumber AsNumber { get; set; }
  public testPrntAltOutp PrntAltOutp { get; set; }
}

public class testRefPrntAltOutp
  : ItestRefPrntAltOutp
{
  public testNumber parent { get; set; }
  public testString AsString { get; set; }
  public testRefPrntAltOutp RefPrntAltOutp { get; set; }
}
