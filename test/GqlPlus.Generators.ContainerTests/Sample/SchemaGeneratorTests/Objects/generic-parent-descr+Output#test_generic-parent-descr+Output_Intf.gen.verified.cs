//HintName: test_generic-parent-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Output;

public interface ItestGnrcPrntDescrOutp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrOutpObject<TType>? As_GnrcPrntDescrOutp { get; }
}

public interface ItestGnrcPrntDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
}
