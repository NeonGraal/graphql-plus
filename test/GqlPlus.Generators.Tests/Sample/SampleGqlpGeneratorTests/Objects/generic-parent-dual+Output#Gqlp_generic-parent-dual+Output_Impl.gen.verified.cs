//HintName: Gqlp_generic-parent-dual+Output_Impl.gen.cs
// Generated from generic-parent-dual+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_dual_Output;

public class OutputGnrcPrntDualOutp
  : OutputRefGnrcPrntDualOutp
  , IGnrcPrntDualOutp
{
}

public class OutputRefGnrcPrntDualOutp<Tref>
  : IRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class DualAltGnrcPrntDualOutp
  : IAltGnrcPrntDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
