//HintName: test_output-parent-generic_Impl.gen.cs
// Generated from output-parent-generic.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public class testOutpPrntGnrc
  : ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<ItestEnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject AsOutpPrntGnrc { get; set; }
}

public class testRefOutpPrntGnrc<Ttype>
  : ItestRefOutpPrntGnrc<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefOutpPrntGnrcObject AsRefOutpPrntGnrc { get; set; }
}
