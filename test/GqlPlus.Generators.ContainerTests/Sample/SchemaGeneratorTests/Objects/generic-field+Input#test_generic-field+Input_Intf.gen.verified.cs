//HintName: test_generic-field+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}
