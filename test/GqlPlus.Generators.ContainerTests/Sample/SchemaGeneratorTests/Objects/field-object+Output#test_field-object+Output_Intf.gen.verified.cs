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
  ItestFieldObjOutpObject AsFieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldObjOutpObject AsFldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
{
  decimal Field { get; }
}
