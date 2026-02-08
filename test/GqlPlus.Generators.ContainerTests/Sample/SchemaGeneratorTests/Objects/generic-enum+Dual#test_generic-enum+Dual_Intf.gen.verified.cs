//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from generic-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<ItestEnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
}

public interface ItestGnrcEnumDualObject
{
}

public interface ItestRefGnrcEnumDual<Ttype>
{
}

public interface ItestRefGnrcEnumDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
