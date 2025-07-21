//HintName: Gqlp_generic-field-param+Input_Impl.gen.cs
// Generated from generic-field-param+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_param_Input;
public class InputGnrcFieldParamInp
  : IGnrcFieldParamInp
{
  public RefGnrcFieldParamInp<AltGnrcFieldParamInp> field { get; set; }
}
public class InputRefGnrcFieldParamInp<Tref>
  : IRefGnrcFieldParamInp<Tref>
{
  public Tref Asref { get; set; }
}
public class InputAltGnrcFieldParamInp
  : IAltGnrcFieldParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
