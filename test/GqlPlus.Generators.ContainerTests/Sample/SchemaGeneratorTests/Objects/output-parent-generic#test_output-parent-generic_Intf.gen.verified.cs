//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject AsOutpPrntGnrc { get; set; }
}

public interface ItestOutpPrntGnrcObject
{
}

public interface ItestRefOutpPrntGnrc<Ttype>
{
  public ItestRefOutpPrntGnrcObject AsRefOutpPrntGnrc { get; set; }
}

public interface ItestRefOutpPrntGnrcObject<Ttype>
{
  public Ttype Field { get; set; }
}
