//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
{
  public testRefOutpPrntGnrc<testEnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; set; }
  public testOutpPrntGnrc OutpPrntGnrc { get; set; }
}

public interface ItestOutpPrntGnrcField
{
}

public interface ItestRefOutpPrntGnrc<Ttype>
{
  public testRefOutpPrntGnrc RefOutpPrntGnrc { get; set; }
}

public interface ItestRefOutpPrntGnrcField<Ttype>
{
  public Ttype field { get; set; }
}
