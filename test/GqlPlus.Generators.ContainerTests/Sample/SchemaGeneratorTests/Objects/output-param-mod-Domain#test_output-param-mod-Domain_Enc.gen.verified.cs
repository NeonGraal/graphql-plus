//HintName: test_output-param-mod-Domain_Enc.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public class testOutpParamModDmn
  : GqlpEncoderBase
  , ItestOutpParamModDmn
{
  public ItestOutpParamModDmnObject? As_OutpParamModDmn { get; set; }
}

public class testOutpParamModDmnObject
  : GqlpEncoderBase
  , ItestOutpParamModDmnObject
{
  public ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter)
    => null;

  public testOutpParamModDmnObject
    ()
  {
  }
}

public class testInOutpParamModDmn
  : GqlpEncoderBase
  , ItestInOutpParamModDmn
{
  public string? AsString { get; set; }
  public ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; set; }
}

public class testInOutpParamModDmnObject
  : GqlpEncoderBase
  , ItestInOutpParamModDmnObject
{
  public decimal Param { get; set; }

  public testInOutpParamModDmnObject
    ( decimal param
    )
  {
    Param = param;
  }
}

public class testDomOutpParamModDmn
  : GqlpDomainNumber
  , ItestDomOutpParamModDmn
{
}
