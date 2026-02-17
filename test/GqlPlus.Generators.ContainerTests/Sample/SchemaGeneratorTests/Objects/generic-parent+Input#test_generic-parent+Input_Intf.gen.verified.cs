//HintName: test_generic-parent+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public interface ItestGnrcPrntInp<TType>
  : IGqlpModelImplementationBase
{
  TType AsParent { get; }
  ItestGnrcPrntInpObject<TType> AsGnrcPrntInp { get; }
}

public interface ItestGnrcPrntInpObject<TType>
{
}
