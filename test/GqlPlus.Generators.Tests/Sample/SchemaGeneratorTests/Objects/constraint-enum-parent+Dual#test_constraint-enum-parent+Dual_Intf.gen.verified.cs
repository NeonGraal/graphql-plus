//HintName: test_constraint-enum-parent+Dual_Intf.gen.cs
// Generated from constraint-enum-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public interface ItestCnstEnumPrntDual
{
  public testRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsRefCnstEnumPrntDual { get; set; }
  public testCnstEnumPrntDual CnstEnumPrntDual { get; set; }
}

public interface ItestCnstEnumPrntDualField
{
}

public interface ItestRefCnstEnumPrntDual<Ttype>
{
  public testRefCnstEnumPrntDual RefCnstEnumPrntDual { get; set; }
}

public interface ItestRefCnstEnumPrntDualField<Ttype>
{
  public Ttype field { get; set; }
}
