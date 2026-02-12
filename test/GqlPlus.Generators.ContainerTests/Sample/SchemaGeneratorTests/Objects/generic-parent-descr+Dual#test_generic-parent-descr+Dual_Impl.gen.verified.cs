//HintName: test_generic-parent-descr+Dual_Impl.gen.cs
// Generated from generic-parent-descr+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Dual;

public class testGnrcPrntDescrDual<TType>
  : testtype
  , ItestGnrcPrntDescrDual<TType>
{
  public ItestGnrcPrntDescrDualObject<TType> AsGnrcPrntDescrDual { get; set; }
}
