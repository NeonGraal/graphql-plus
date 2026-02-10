//HintName: test_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  public ItestPrntOutpObject AsPrntOutp { get; set; }
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
{
  public string AsString { get; set; }
  public ItestRefPrntOutpObject AsRefPrntOutp { get; set; }
}

public interface ItestRefPrntOutpObject
{
  public decimal Parent { get; set; }
}
