//HintName: test_output-param-mod-param_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<TMod>
  : GqlpEncoderBase
  , ItestOutpParamModParam<TMod>
{
  public ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; set; }
}

public class testOutpParamModParamObject<TMod>
  : GqlpEncoderBase
  , ItestOutpParamModParamObject<TMod>
{
  public ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter)
    => null;

  public testOutpParamModParamObject
    ()
  {
  }
}

public class testInOutpParamModParam
  : GqlpEncoderBase
  , ItestInOutpParamModParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamModParamObject? As_InOutpParamModParam { get; set; }
}

public class testInOutpParamModParamObject
  : GqlpEncoderBase
  , ItestInOutpParamModParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamModParamObject
    ( decimal param
    )
  {
    Param = param;
  }
}

public class testDomOutpParamModParam
  : GqlpDomainNumber
  , ItestDomOutpParamModParam
{
}
