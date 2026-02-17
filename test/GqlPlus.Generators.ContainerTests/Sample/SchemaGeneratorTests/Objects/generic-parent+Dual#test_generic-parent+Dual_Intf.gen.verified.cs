//HintName: test_generic-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

public interface ItestGnrcPrntDual<TType>
  : IGqlpModelImplementationBase
{
  TType AsParent { get; }
  ItestGnrcPrntDualObject<TType> AsGnrcPrntDual { get; }
}

public interface ItestGnrcPrntDualObject<TType>
{
}
