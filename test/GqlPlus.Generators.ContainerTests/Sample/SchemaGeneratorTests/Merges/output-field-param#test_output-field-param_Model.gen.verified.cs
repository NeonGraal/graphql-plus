//HintName: test_output-field-param_Model.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

public class testOutpFieldParam
  : GqlpModelImplementationBase
  , ItestOutpFieldParam
{
  public ItestOutpFieldParamObject? As_OutpFieldParam { get; set; }
}

public class testOutpFieldParamObject
  : GqlpModelImplementationBase
  , ItestOutpFieldParamObject
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;
}

public class testOutpFieldParam1
  : GqlpModelImplementationBase
  , ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; set; }
}

public class testOutpFieldParam1Object
  : GqlpModelImplementationBase
  , ItestOutpFieldParam1Object
{
}

public class testOutpFieldParam2
  : GqlpModelImplementationBase
  , ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; set; }
}

public class testOutpFieldParam2Object
  : GqlpModelImplementationBase
  , ItestOutpFieldParam2Object
{
}

public class testFldOutpFieldParam
  : GqlpModelImplementationBase
  , ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; set; }
}

public class testFldOutpFieldParamObject
  : GqlpModelImplementationBase
  , ItestFldOutpFieldParamObject
{
}
