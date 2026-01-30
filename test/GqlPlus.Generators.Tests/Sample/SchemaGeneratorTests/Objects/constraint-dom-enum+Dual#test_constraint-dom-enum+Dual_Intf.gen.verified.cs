//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
{
  public testRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; set; }
  public testCnstDomEnumDual CnstDomEnumDual { get; set; }
}

public interface ItestCnstDomEnumDualObject
{
}

public interface ItestRefCnstDomEnumDual<Ttype>
{
  public testRefCnstDomEnumDual RefCnstDomEnumDual { get; set; }
}

public interface ItestRefCnstDomEnumDualObject<Ttype>
{
  public Ttype field { get; set; }
}

public interface ItestJustCnstDomEnumDual
  : IDomainEnum
{
}
