//HintName: Gqlp_generic-parent-dual-parent+Output_Impl.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_parent_Output;
public class OutputGnrcPrntDualPrntOutp
  : OutputRefGnrcPrntDualPrntOutp
  , IGnrcPrntDualPrntOutp
{
}
public class OutputRefGnrcPrntDualPrntOutp<Tref>
  : Outputref
  , IRefGnrcPrntDualPrntOutp<Tref>
{
}
public class DualAltGnrcPrntDualPrntOutp
  : IAltGnrcPrntDualPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
