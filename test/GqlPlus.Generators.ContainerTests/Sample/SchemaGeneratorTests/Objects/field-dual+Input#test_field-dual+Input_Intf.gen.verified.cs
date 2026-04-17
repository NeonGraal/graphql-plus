//HintName: test_field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

public interface ItestFieldDualInp
  : IGqlpInterfaceBase
{
  ItestFieldDualInpObject? As_FieldDualInp { get; }
}

public interface ItestFieldDualInpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualInp Field { get; }
}

public interface ItestFldFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualInpObject? As_FldFieldDualInp { get; }
}

public interface ItestFldFieldDualInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
