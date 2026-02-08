//HintName: test_generic-value+Dual_Impl.gen.cs
// Generated from generic-value+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<ItestEnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
}

public class testRefGnrcValueDual<Ttype>
  : ItestRefGnrcValueDual<Ttype>
{
  public Ttype Field { get; set; }
}
