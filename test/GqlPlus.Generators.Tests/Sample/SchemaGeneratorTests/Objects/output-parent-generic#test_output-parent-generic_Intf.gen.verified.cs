//HintName: test_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

public interface ItestOutpPrntGnrc
{
  RefOutpPrntGnrc<EnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrc<Ttype>
{
  Ttype field { get; }
}
