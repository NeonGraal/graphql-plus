//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  public testNumber AsNumber { get; set; }
  public testPrntAltOutp PrntAltOutp { get; set; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
{
  public testString AsString { get; set; }
  public testRefPrntAltOutp RefPrntAltOutp { get; set; }
}

public interface ItestRefPrntAltOutpObject
{
  public testNumber parent { get; set; }
}
