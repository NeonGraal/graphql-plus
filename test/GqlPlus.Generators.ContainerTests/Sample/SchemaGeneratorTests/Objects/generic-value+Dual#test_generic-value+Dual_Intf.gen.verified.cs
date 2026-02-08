//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<ItestEnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
}

public interface ItestGnrcValueDualObject
{
}

public interface ItestRefGnrcValueDual<Ttype>
{
}

public interface ItestRefGnrcValueDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
