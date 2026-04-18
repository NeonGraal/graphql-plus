//HintName: test_input-field-String_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

public interface ItestInpFieldStr
  : IGqlpInterfaceBase
{
  ItestInpFieldStrObject? As_InpFieldStr { get; }
}

public interface ItestInpFieldStrObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
