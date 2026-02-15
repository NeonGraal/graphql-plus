//HintName: test_generic-field+Dual_Intf.gen.cs
// Generated from generic-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public interface ItestGnrcFieldDual<TType>
{
  ItestGnrcFieldDualObject<TType> AsGnrcFieldDual { get; }
}

public interface ItestGnrcFieldDualObject<TType>
{
  TType Field { get; }
}
