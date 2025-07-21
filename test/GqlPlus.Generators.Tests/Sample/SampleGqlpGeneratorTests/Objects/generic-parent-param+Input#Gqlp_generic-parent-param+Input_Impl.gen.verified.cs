//HintName: Gqlp_generic-parent-param+Input_Impl.gen.cs
// Generated from generic-parent-param+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_Input;
public class InputGnrcPrntParamInp
  : InputRefGnrcPrntParamInp
  , IGnrcPrntParamInp
{
}
public class InputRefGnrcPrntParamInp<Tref>
  : IRefGnrcPrntParamInp<Tref>
{
  public Tref Asref { get; set; }
}
public class InputAltGnrcPrntParamInp
  : IAltGnrcPrntParamInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
