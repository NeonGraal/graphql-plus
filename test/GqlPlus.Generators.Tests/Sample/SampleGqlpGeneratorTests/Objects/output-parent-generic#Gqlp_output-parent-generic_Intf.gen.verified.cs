//HintName: Gqlp_output-parent-generic_Intf.gen.cs
// Generated from output-parent-generic.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_output_parent_generic;

public interface IOutpPrntGnrc
{
  RefOutpPrntGnrc<EnumOutpPrntGnrc> AsRefOutpPrntGnrc { get; }
}

public interface IRefOutpPrntGnrc<Ttype>
{
  Ttype field { get; }
}
