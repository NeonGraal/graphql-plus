//HintName: test_output-field-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

public interface ItestOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParamObject? As_OutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter);
}

public interface ItestOutpFieldParam1
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
  : IGqlpModelImplementationBase
{
}

public interface ItestOutpFieldParam2
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
  : IGqlpModelImplementationBase
{
}

public interface ItestFldOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
  : IGqlpModelImplementationBase
{
}
