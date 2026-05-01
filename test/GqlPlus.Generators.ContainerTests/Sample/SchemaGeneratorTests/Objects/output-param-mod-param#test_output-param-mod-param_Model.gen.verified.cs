//HintName: test_output-param-mod-param_Model.gen.cs
// Generated from {CurrentDirectory}output-param-mod-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_param;

public class testOutpParamModParam<TMod>
  : GqlpModelBase
  , ItestOutpParamModParam<TMod>
{
  public ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; set; }
}

public class testOutpParamModParamObject<TMod>
  : GqlpModelBase
  , ItestOutpParamModParamObject<TMod>
{
  public ItestDomOutpParamModParam Field { get; set; }
  public ItestDomOutpParamModParam? Call_Field(IDictionary<TMod, ItestInOutpParamModParam> parameter)
    => null;

  public testOutpParamModParamObject
    ( ItestDomOutpParamModParam pfield
    )
  {
    Field = pfield;
  }
}

public class testInOutpParamModParam
  : GqlpModelBase
  , ItestInOutpParamModParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamModParamObject? As_InOutpParamModParam { get; set; }
}

public class testInOutpParamModParamObject
  : GqlpModelBase
  , ItestInOutpParamModParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamModParamObject
    ( decimal pparam
    )
  {
    Param = pparam;
  }
}

public class testDomOutpParamModParam
  : GqlpDomainNumber
  , ItestDomOutpParamModParam
{
}
