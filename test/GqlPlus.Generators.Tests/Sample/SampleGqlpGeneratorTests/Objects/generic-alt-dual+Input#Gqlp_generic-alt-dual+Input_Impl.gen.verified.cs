//HintName: Gqlp_generic-alt-dual+Input_Impl.gen.cs
// Generated from generic-alt-dual+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_dual_Input;
public class InputGnrcAltDualInp
  : IGnrcAltDualInp
{
  public RefGnrcAltDualInp<AltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
}
public class InputRefGnrcAltDualInp<Tref>
  : IRefGnrcAltDualInp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcAltDualInp
  : IAltGnrcAltDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
