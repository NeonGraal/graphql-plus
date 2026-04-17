//HintName: test_output-field-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

public interface ItestOutpFieldParam
  : IGqlpInterfaceBase
{
  ItestOutpFieldParamObject? As_OutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter);
  ItestFldOutpFieldParam? Field();
}

public interface ItestOutpFieldParam1
  : IGqlpInterfaceBase
{
  ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
  : IGqlpInterfaceBase
{
}

public interface ItestOutpFieldParam2
  : IGqlpInterfaceBase
{
  ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
  : IGqlpInterfaceBase
{
}

public interface ItestFldOutpFieldParam
  : IGqlpInterfaceBase
{
  ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
  : IGqlpInterfaceBase
{
}
