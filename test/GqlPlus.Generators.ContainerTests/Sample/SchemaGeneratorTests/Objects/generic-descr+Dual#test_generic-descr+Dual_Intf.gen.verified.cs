//HintName: test_generic-descr+Dual_Intf.gen.cs
// Generated from generic-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public interface ItestGnrcDescrDual<Ttype>
{
  public ItestGnrcDescrDualObject AsGnrcDescrDual { get; set; }
}

public interface ItestGnrcDescrDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
