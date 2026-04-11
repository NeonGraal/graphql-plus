//HintName: test_generic-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public interface ItestGnrcPrntInp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; }
}

public interface ItestGnrcPrntInpObject<TType>
  : IGqlpInterfaceBase
{
}
