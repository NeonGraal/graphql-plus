//HintName: test_generic-enum+Dual_Impl.gen.cs
// Generated from generic-enum+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class DualtestGnrcEnumDual
  : ItestGnrcEnumDual
{
  public RefGnrcEnumDual<EnumGnrcEnumDual> AsRefGnrcEnumDual { get; set; }
}

public class DualtestRefGnrcEnumDual<Ttype>
  : ItestRefGnrcEnumDual<Ttype>
{
  public Ttype field { get; set; }
}
