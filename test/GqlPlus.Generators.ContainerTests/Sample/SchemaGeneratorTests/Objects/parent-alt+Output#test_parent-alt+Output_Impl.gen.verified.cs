//HintName: test_parent-alt+Output_Impl.gen.cs
// Generated from parent-alt+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public class testPrntAltOutp
  : testRefPrntAltOutp
  , ItestPrntAltOutp
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltOutpObject AsPrntAltOutp { get; set; }
}

public class testRefPrntAltOutp
  : ItestRefPrntAltOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntAltOutpObject AsRefPrntAltOutp { get; set; }
}
