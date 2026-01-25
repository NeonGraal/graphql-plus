//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
{
  public testRefCnstEnumDual<testEnumCnstEnumDual> AsRefCnstEnumDual { get; set; }
  public testCnstEnumDual CnstEnumDual { get; set; }
}

public interface ItestCnstEnumDualObject
{
}

public interface ItestRefCnstEnumDual<Ttype>
{
  public testRefCnstEnumDual RefCnstEnumDual { get; set; }
}

public interface ItestRefCnstEnumDualObject<Ttype>
{
  public Ttype field { get; set; }
}
