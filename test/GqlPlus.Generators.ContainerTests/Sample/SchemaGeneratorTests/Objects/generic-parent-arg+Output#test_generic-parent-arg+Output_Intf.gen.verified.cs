//HintName: test_generic-parent-arg+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public interface ItestGnrcPrntArgOutp<TType>
  : ItestRefGnrcPrntArgOutp<TType>
{
  ItestGnrcPrntArgOutpObject<TType>? As_GnrcPrntArgOutp { get; }
}

public interface ItestGnrcPrntArgOutpObject<TType>
  : ItestRefGnrcPrntArgOutpObject<TType>
{
}

public interface ItestRefGnrcPrntArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgOutpObject<TRef>? As_RefGnrcPrntArgOutp { get; }
}

public interface ItestRefGnrcPrntArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}
