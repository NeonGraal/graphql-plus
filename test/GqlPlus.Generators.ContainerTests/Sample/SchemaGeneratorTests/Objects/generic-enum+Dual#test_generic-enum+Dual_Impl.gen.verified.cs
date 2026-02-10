//HintName: test_generic-enum+Dual_Impl.gen.cs
// Generated from generic-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<testEnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
  public ItestGnrcEnumDualObject AsGnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDual<Ttype>
  : ItestRefGnrcEnumDual<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefGnrcEnumDualObject AsRefGnrcEnumDual { get; set; }
}
