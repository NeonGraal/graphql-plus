//HintName: Gqlp_generic-alt-dual+Dual_Impl.gen.cs
// Generated from generic-alt-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Dual;
public class DualGnrcAltDualDual
  : IGnrcAltDualDual
{
  public RefGnrcAltDualDual<AltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
}
public class DualRefGnrcAltDualDual<Tref>
  : IRefGnrcAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcAltDualDual
  : IAltGnrcAltDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
