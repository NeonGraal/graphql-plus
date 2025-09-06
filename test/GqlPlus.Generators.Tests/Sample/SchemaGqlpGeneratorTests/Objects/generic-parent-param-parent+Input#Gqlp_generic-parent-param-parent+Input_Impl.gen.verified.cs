//HintName: Gqlp_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_param_parent_Input;

public class InputGnrcPrntParamPrntInp
  : InputRefGnrcPrntParamPrntInp
  , IGnrcPrntParamPrntInp
{
}

public class InputRefGnrcPrntParamPrntInp<Tref>
  : Inputref
  , IRefGnrcPrntParamPrntInp<Tref>
{
}

public class InputAltGnrcPrntParamPrntInp
  : IAltGnrcPrntParamPrntInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
