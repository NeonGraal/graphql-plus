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
  ItestOutpFieldParamObject AsOutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
{
  ItestFldOutpFieldParam Field (ItestOutpFieldParam1 parameter);
}

public interface ItestOutpFieldParam1
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam1Object AsOutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
{
}

public interface ItestOutpFieldParam2
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam2Object AsOutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
{
}

public interface ItestFldOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParamObject AsFldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
{
}
