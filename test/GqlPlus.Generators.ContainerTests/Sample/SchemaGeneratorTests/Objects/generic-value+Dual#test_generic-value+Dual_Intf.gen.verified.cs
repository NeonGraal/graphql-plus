//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
{
  ItestRefGnrcValueDual<testEnumGnrcValueDual> AsRefGnrcValueDual { get; }
  ItestGnrcValueDualObject AsGnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
{
}

public interface ItestRefGnrcValueDual<TType>
{
  ItestRefGnrcValueDualObject AsRefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
{
  TType Field { get; }
}
