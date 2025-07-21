//HintName: Gqlp_generic-alt-arg+Dual_Impl.gen.cs
// Generated from generic-alt-arg+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_Dual;
public class DualGnrcAltArgDual<Ttype>
  : IGnrcAltArgDual<Ttype>
{
  public RefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; set; }
}
public class DualRefGnrcAltArgDual<Tref>
  : IRefGnrcAltArgDual<Tref>
{
  public Tref Asref { get; set; }
}
