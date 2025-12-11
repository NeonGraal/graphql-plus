//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from generic-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
{
  public testRefGnrcEnumDual<testEnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
  public testGnrcEnumDual GnrcEnumDual { get; set; }
}

public interface ItestGnrcEnumDualField
{
}

public interface ItestRefGnrcEnumDual<Ttype>
{
  public testRefGnrcEnumDual RefGnrcEnumDual { get; set; }
}

public interface ItestRefGnrcEnumDualField<Ttype>
{
  public Ttype field { get; set; }
}
