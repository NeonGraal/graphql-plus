//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<ItestEnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; set; }
}

public interface ItestOutpPrntGnrcObject
{
}

public interface ItestRefOutpPrntGnrc<Ttype>
{
}

public interface ItestRefOutpPrntGnrcObject<Ttype>
{
  public Ttype Field { get; set; }
}
