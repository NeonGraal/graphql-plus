//HintName: test_generic-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public interface ItestGnrcPrntOutp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; }
}

public interface ItestGnrcPrntOutpObject<TType>
  : IGqlpInterfaceBase
{
}
