//HintName: test_parent-alt+Output_Impl.gen.cs
// Generated from parent-alt+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public class testPrntAltOutp
  : testRefPrntAltOutp
  , ItestPrntAltOutp
{
  public Number AsNumber { get; set; }
}

public class testRefPrntAltOutp
  : ItestRefPrntAltOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
