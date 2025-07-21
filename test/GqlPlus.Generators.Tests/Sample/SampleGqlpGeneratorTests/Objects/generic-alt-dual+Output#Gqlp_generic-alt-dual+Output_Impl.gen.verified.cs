//HintName: Gqlp_generic-alt-dual+Output_Impl.gen.cs
// Generated from generic-alt-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Output;
public class OutputGnrcAltDualOutp
  : IGnrcAltDualOutp
{
  public RefGnrcAltDualOutp<AltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
}
public class OutputRefGnrcAltDualOutp<Tref>
  : IRefGnrcAltDualOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcAltDualOutp
  : IAltGnrcAltDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
