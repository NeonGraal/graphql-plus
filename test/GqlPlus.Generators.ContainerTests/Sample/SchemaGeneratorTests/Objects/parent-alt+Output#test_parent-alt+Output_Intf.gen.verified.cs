//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltOutpObject AsPrntAltOutp { get; set; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
{
  public string AsString { get; set; }
  public ItestRefPrntAltOutpObject AsRefPrntAltOutp { get; set; }
}

public interface ItestRefPrntAltOutpObject
{
  public decimal Parent { get; set; }
}
