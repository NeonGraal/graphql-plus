//HintName: Gqlp_generic-alt-simple+Dual_Impl.gen.cs
// Generated from generic-alt-simple+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_simple_Dual;
public class DualGnrcAltSmplDual
  : IGnrcAltSmplDual
{
  public RefGnrcAltSmplDual<String> AsRefGnrcAltSmplDual { get; set; }
}
public class DualRefGnrcAltSmplDual<Tref>
  : IRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
}
