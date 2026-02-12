//HintName: test_generic-descr+Dual_Intf.gen.cs
// Generated from generic-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public interface ItestGnrcDescrDual<TType>
{
  ItestGnrcDescrDualObject<TType> AsGnrcDescrDual { get; }
}

public interface ItestGnrcDescrDualObject<TType>
{
  TType Field { get; }
}
