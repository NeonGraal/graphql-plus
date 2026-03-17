//HintName: test_output-param-mod-Domain_Model.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public class testOutpParamModDmn
  : GqlpModelImplementationBase
  , ItestOutpParamModDmn
{
  public ItestOutpParamModDmnObject? As_OutpParamModDmn { get; set; }
}

public class testOutpParamModDmnObject
  : GqlpModelImplementationBase
  , ItestOutpParamModDmnObject
{
  public ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter)
    => null;
}

public class testInOutpParamModDmn
  : GqlpModelImplementationBase
  , ItestInOutpParamModDmn
{
  public string? AsString { get; set; }
  public ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; set; }
}

public class testInOutpParamModDmnObject
  : GqlpModelImplementationBase
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
