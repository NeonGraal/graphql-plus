//HintName: test_field-object+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public interface ItestFieldObjOutp
  : IGqlpInterfaceBase
{
  ItestFieldObjOutpObject? As_FieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
