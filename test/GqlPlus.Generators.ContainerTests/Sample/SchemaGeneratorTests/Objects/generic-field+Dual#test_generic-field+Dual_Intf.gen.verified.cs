//HintName: test_generic-field+Dual_Intf.gen.cs
// Generated from generic-field+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public interface ItestGnrcFieldDual<Ttype>
{
  public ItestGnrcFieldDualObject AsGnrcFieldDual { get; set; }
}

public interface ItestGnrcFieldDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
