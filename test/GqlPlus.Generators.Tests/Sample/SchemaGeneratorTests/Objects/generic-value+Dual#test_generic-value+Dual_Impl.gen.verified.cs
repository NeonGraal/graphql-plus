//HintName: test_generic-value+Dual_Impl.gen.cs
// Generated from generic-value+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class DualtestGnrcValueDual
  : ItestGnrcValueDual
{
  public RefGnrcValueDual<EnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
}

public class DualtestRefGnrcValueDual<Ttype>
  : ItestRefGnrcValueDual<Ttype>
{
  public Ttype field { get; set; }
}
