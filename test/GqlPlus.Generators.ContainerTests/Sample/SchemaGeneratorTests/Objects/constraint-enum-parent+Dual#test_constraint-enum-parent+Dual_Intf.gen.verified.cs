//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; set; }
}

public interface ItestCnstEnumPrntDualObject
{
}

public interface ItestRefCnstEnumPrntDual<Ttype>
{
  public ItestRefCnstEnumPrntDualObject AsRefCnstEnumPrntDual { get; set; }
}

public interface ItestRefCnstEnumPrntDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
