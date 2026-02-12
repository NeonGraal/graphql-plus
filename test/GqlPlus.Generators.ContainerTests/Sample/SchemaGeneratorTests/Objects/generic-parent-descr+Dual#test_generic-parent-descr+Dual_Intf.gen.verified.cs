//HintName: test_generic-parent-descr+Dual_Intf.gen.cs
// Generated from generic-parent-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Dual;

public interface ItestGnrcPrntDescrDual<TType>
{
  TType AsParent { get; }
  ItestGnrcPrntDescrDualObject<TType> AsGnrcPrntDescrDual { get; }
}

public interface ItestGnrcPrntDescrDualObject<TType>
{
}
