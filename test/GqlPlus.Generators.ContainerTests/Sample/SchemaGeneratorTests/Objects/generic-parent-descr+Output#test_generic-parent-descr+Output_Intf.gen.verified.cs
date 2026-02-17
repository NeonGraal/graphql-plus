//HintName: test_generic-parent-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Output;

public interface ItestGnrcPrntDescrOutp<TType>
  : IGqlpModelImplementationBase
{
  TType AsParent { get; }
  ItestGnrcPrntDescrOutpObject<TType> AsGnrcPrntDescrOutp { get; }
}

public interface ItestGnrcPrntDescrOutpObject<TType>
{
}
