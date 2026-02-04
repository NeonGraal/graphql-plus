//HintName: test_constraint-dom-enum+Dual_Impl.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : ItestCnstDomEnumDual
{
  public testRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; set; }
  public testCnstDomEnumDual CnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDual<Ttype>
  : ItestRefCnstDomEnumDual<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstDomEnumDual RefCnstDomEnumDual { get; set; }
}

public class testJustCnstDomEnumDual
  : DomainEnum
  , ItestJustCnstDomEnumDual
{
}
