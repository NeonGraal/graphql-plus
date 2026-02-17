//HintName: test_generic-parent-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Dual;

public interface ItestGnrcPrntDescrDual<TType>
  : IGqlpModelImplementationBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrDualObject<TType>? As_GnrcPrntDescrDual { get; }
}

public interface ItestGnrcPrntDescrDualObject<TType>
  : IGqlpModelImplementationBase
{
}
