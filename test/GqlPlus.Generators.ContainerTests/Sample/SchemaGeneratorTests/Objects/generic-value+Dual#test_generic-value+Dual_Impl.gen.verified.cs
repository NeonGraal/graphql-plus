//HintName: test_generic-value+Dual_Impl.gen.cs
// Generated from generic-value+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
  public ItestGnrcValueDualObject AsGnrcValueDual { get; set; }
}

public class testRefGnrcValueDual<TType>
  : ItestRefGnrcValueDual<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcValueDualObject AsRefGnrcValueDual { get; set; }
}
