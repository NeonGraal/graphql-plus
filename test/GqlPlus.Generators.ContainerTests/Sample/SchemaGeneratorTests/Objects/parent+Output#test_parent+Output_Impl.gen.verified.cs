//HintName: test_parent+Output_Impl.gen.cs
// Generated from parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
  public ItestPrntOutpObject AsPrntOutp { get; set; }
}

public class testRefPrntOutp
  : ItestRefPrntOutp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
  public ItestRefPrntOutpObject AsRefPrntOutp { get; set; }
}
