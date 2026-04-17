//HintName: test_generic-alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Input;

public interface ItestGnrcAltInp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestGnrcAltInpObject<TType>? As_GnrcAltInp { get; }
}

public interface ItestGnrcAltInpObject<TType>
  : IGqlpInterfaceBase
{
}
