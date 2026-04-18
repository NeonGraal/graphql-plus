//HintName: test_generic-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public interface ItestGnrcDescrOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; }
}

public interface ItestGnrcDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}
