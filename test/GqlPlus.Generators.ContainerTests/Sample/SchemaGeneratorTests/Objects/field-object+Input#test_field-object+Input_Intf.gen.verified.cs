//HintName: test_field-object+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

public interface ItestFieldObjInp
  : IGqlpModelImplementationBase
{
  ItestFieldObjInpObject? As_FieldObjInp { get; }
}

public interface ItestFieldObjInpObject
  : IGqlpModelImplementationBase
{
  ItestFldFieldObjInp Field { get; }
}

public interface ItestFldFieldObjInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldObjInpObject? As_FldFieldObjInp { get; }
}

public interface ItestFldFieldObjInpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
