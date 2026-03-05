//HintName: test_field-object+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

public interface ItestFieldObjOutp
  : IGqlpModelImplementationBase
{
  ItestFieldObjOutpObject? As_FieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
