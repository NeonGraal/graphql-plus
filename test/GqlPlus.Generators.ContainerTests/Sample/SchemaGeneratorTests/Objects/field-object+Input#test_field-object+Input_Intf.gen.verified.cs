//HintName: test_field-object+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public interface ItestFieldObjInp
  : IGqlpInterfaceBase
{
  ItestFieldObjInpObject? As_FieldObjInp { get; }
}

public interface ItestFieldObjInpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjInp Field { get; }
}

public interface ItestFldFieldObjInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjInpObject? As_FldFieldObjInp { get; }
}

public interface ItestFldFieldObjInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
