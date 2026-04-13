//HintName: test_output-param-mod-Domain_Model.gen.cs
// Generated from {CurrentDirectory}output-param-mod-Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_mod_Domain;

public class testOutpParamModDmn
  : GqlpModelBase
  , ItestOutpParamModDmn
{
  public ItestOutpParamModDmnObject? As_OutpParamModDmn { get; set; }
}

public class testOutpParamModDmnObject
  : GqlpModelBase
  , ItestOutpParamModDmnObject
{
  public ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter)
    => null;
  public ItestDomOutpParamModDmn? Field()
    => null;

  public testOutpParamModDmnObject
    ()
  {
  }
}

public class testInOutpParamModDmn
  : GqlpModelBase
  , ItestInOutpParamModDmn
{
  public string? AsString { get; set; }
  public ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; set; }
}

public class testInOutpParamModDmnObject
  : GqlpModelBase
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
