//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
  public ItestGnrcValueDualObject AsGnrcValueDual { get; set; }
}

public interface ItestGnrcValueDualObject
{
}

public interface ItestRefGnrcValueDual<Ttype>
{
  public ItestRefGnrcValueDualObject AsRefGnrcValueDual { get; set; }
}

public interface ItestRefGnrcValueDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
