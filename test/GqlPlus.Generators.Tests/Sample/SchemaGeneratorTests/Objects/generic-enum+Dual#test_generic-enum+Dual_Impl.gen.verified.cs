//HintName: test_generic-enum+Dual_Impl.gen.cs
// Generated from generic-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : ItestGnrcEnumDual
{
  public testRefGnrcEnumDual<testEnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
  public testGnrcEnumDual GnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDual<Ttype>
  : ItestRefGnrcEnumDual<Ttype>
{
  public Ttype field { get; set; }
  public testRefGnrcEnumDual RefGnrcEnumDual { get; set; }
}
