//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
{
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; }
  ItestOutpPrntGnrcObject AsOutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
{
}

public interface ItestRefOutpPrntGnrc<Ttype>
{
  ItestRefOutpPrntGnrcObject AsRefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<Ttype>
{
  Ttype Field { get; }
}
