//HintName: test_output-param_Model.gen.cs
// Generated from {CurrentDirectory}output-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param;

public class testOutpParam
  : GqlpModelBase
  , ItestOutpParam
{
  public ItestOutpParamObject? As_OutpParam { get; set; }
}

public class testOutpParamObject
  : GqlpModelBase
  , ItestOutpParamObject
{
  public ItestFldOutpParam Field { get; set; }
  public ItestFldOutpParam? Call_Field(ItestInOutpParam parameter)
    => null;

  public testOutpParamObject
    ( ItestFldOutpParam pfield
    )
  {
    Field = pfield;
  }
}

public class testFldOutpParam
  : GqlpModelBase
  , ItestFldOutpParam
{
  public ItestFldOutpParamObject? As_FldOutpParam { get; set; }
}

public class testFldOutpParamObject
  : GqlpModelBase
  , ItestFldOutpParamObject
{

  public testFldOutpParamObject
    ()
  {
  }
}

public class testInOutpParam
  : GqlpModelBase
  , ItestInOutpParam
{
  public string? AsString { get; set; }
  public ItestInOutpParamObject? As_InOutpParam { get; set; }
}

public class testInOutpParamObject
  : GqlpModelBase
  , ItestInOutpParamObject
{
  public decimal Param { get; set; }

  public testInOutpParamObject
    ( decimal pparam
    )
  {
    Param = pparam;
  }
}
