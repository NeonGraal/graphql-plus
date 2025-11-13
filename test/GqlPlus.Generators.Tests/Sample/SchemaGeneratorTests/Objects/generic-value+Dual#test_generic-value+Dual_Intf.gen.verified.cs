//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from generic-value+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
{
  public testRefGnrcValueDual<testEnumGnrcValueDual> AsRefGnrcValueDual { get; set; }
  public testGnrcValueDual GnrcValueDual { get; set; }
}

public interface ItestGnrcValueDualField
{
}

public interface ItestRefGnrcValueDual<Ttype>
{
  public testRefGnrcValueDual RefGnrcValueDual { get; set; }
}

public interface ItestRefGnrcValueDualField<Ttype>
{
  public Ttype field { get; set; }
}
