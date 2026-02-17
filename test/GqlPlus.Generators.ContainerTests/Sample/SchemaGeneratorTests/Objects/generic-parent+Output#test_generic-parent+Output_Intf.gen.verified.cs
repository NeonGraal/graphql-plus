//HintName: test_generic-parent+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public interface ItestGnrcPrntOutp<TType>
  : IGqlpModelImplementationBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; }
}

public interface ItestGnrcPrntOutpObject<TType>
  : IGqlpModelImplementationBase
{
}
