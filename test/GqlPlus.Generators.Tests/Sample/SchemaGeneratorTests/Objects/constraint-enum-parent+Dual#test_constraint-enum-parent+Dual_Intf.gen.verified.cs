//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
{
  RefCnstEnumPrntDual<EnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDual<Ttype>
{
  Ttype field { get; }
}
