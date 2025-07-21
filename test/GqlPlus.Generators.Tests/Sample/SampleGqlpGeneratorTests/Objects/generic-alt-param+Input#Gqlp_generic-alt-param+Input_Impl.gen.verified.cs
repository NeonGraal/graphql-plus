//HintName: Gqlp_generic-alt-param+Input_Impl.gen.cs
// Generated from generic-alt-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_param_Input;
public class InputGnrcAltParamInp
  : IGnrcAltParamInp
{
  public RefGnrcAltParamInp<AltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
}
public class InputRefGnrcAltParamInp<Tref>
  : IRefGnrcAltParamInp<Tref>
{
  public Tref Asref { get; set; }
}
public class InputAltGnrcAltParamInp
  : IAltGnrcAltParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
