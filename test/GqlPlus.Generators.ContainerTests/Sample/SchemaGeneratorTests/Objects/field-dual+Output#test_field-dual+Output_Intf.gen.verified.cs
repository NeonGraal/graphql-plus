//HintName: test_field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
  : IGqlpModelImplementationBase
{
  ItestFieldDualOutpObject AsFieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestFldFieldDualOutpObject AsFldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
{
  decimal Field { get; }
}
