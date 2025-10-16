//HintName: test_constraint-enum-parent+Dual_Impl.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : ItestCnstEnumPrntDual
{
  public RefCnstEnumPrntDual<EnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDual<Ttype>
  : ItestRefCnstEnumPrntDual<Ttype>
{
  public Ttype field { get; set; }
}
