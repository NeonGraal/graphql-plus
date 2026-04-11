//HintName: test_output-field-param_Model.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

public class testOutpFieldParam
  : GqlpModelBase
  , ItestOutpFieldParam
{
  public ItestOutpFieldParamObject? As_OutpFieldParam { get; set; }
}

public class testOutpFieldParamObject
  : GqlpModelBase
  , ItestOutpFieldParamObject
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;

  public testOutpFieldParamObject
    ()
  {
  }
}

public class testOutpFieldParam1
  : GqlpModelBase
  , ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; set; }
}

public class testOutpFieldParam1Object
  : GqlpModelBase
  , ItestOutpFieldParam1Object
{

  public testOutpFieldParam1Object
    ()
  {
  }
}

public class testOutpFieldParam2
  : GqlpModelBase
  , ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; set; }
}

public class testOutpFieldParam2Object
  : GqlpModelBase
  , ItestOutpFieldParam2Object
{

  public testOutpFieldParam2Object
    ()
  {
  }
}

public class testFldOutpFieldParam
  : GqlpModelBase
  , ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; set; }
}

public class testFldOutpFieldParamObject
  : GqlpModelBase
  , ItestFldOutpFieldParamObject
{

  public testFldOutpFieldParamObject
    ()
  {
  }
}
