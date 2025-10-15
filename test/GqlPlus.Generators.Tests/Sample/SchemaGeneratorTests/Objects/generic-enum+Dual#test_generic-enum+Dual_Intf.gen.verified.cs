//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from generic-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
{
  RefGnrcEnumDual<EnumGnrcEnumDual> AsRefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDual<Ttype>
{
  Ttype field { get; }
}
