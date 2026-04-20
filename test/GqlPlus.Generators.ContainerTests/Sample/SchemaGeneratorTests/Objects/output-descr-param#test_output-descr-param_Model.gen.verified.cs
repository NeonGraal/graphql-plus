//HintName: test_output-descr-param_Model.gen.cs
// Generated from {CurrentDirectory}output-descr-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_descr_param;

public class testOutpDescrParam
  : GqlpModelBase
  , ItestOutpDescrParam
{
  public ItestOutpDescrParamObject? As_OutpDescrParam { get; set; }
}

public class testOutpDescrParamObject
  : GqlpModelBase
  , ItestOutpDescrParamObject
{
  public ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter)
    => null;
  public ItestFldOutpDescrParam? Field()
    => null;

  public testOutpDescrParamObject
    ()
  {
  }
}

public class testFldOutpDescrParam
  : GqlpModelBase
  , ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; set; }
}

public class testFldOutpDescrParamObject
  : GqlpModelBase
  , ItestFldOutpDescrParamObject
{

  public testFldOutpDescrParamObject
    ()
  {
  }
}

public class testInOutpDescrParam
  : GqlpModelBase
  , ItestInOutpDescrParam
{
  public string? AsString { get; set; }
  public ItestInOutpDescrParamObject? As_InOutpDescrParam { get; set; }
}

public class testInOutpDescrParamObject
  : GqlpModelBase
  , ItestInOutpDescrParamObject
{
  public decimal Param { get; set; }

  public testInOutpDescrParamObject
    ( decimal pparam
    )
  {
    Param = pparam;
  }
}
