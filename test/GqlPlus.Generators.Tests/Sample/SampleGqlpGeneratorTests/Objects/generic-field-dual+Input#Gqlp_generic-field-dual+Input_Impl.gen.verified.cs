//HintName: Gqlp_generic-field-dual+Input_Impl.gen.cs
// Generated from generic-field-dual+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Input;
public class InputGnrcFieldDualInp
  : IGnrcFieldDualInp
{
  public RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; set; }
}
public class InputRefGnrcFieldDualInp<Tref>
  : IRefGnrcFieldDualInp<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcFieldDualInp
  : IAltGnrcFieldDualInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
