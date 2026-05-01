//HintName: test_output-param-type-descr_Model.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

public class testOutpParamTypeDescr
  : GqlpModelBase
  , ItestOutpParamTypeDescr
{
  public ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; set; }
}

public class testOutpParamTypeDescrObject
  : GqlpModelBase
  , ItestOutpParamTypeDescrObject
{
  public ItestFldOutpParamTypeDescr Field { get; set; }
  public ItestFldOutpParamTypeDescr? Call_Field(ItestInOutpParamTypeDescr parameter)
    => null;

  public testOutpParamTypeDescrObject
    ( ItestFldOutpParamTypeDescr pfield
    )
  {
    Field = pfield;
  }
}

public class testFldOutpParamTypeDescr
  : GqlpModelBase
  , ItestFldOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; set; }
}

public class testFldOutpParamTypeDescrObject
  : GqlpModelBase
  , ItestFldOutpParamTypeDescrObject
{

  public testFldOutpParamTypeDescrObject
    ()
  {
  }
}

public class testInOutpParamTypeDescr
  : GqlpModelBase
  , ItestInOutpParamTypeDescr
{
  public string? AsString { get; set; }
  public ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; set; }
}

public class testInOutpParamTypeDescrObject
  : GqlpModelBase
  , ItestInOutpParamTypeDescrObject
{
  public decimal Param { get; set; }

  public testInOutpParamTypeDescrObject
    ( decimal pparam
    )
  {
    Param = pparam;
  }
}
