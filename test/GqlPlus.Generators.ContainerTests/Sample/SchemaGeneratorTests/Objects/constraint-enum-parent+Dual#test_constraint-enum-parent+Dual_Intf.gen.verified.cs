//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<ItestEnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
}

public interface ItestCnstEnumPrntDualObject
{
}

public interface ItestRefCnstEnumPrntDual<Ttype>
{
}

public interface ItestRefCnstEnumPrntDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
