//HintName: test_field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Output;

public interface ItestFieldDualOutp
  : IGqlpInterfaceBase
{
  ItestFieldDualOutpObject? As_FieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
