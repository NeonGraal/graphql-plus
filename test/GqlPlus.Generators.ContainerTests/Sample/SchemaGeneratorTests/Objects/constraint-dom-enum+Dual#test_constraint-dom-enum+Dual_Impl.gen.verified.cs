//HintName: test_constraint-dom-enum+Dual_Impl.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsEnumCnstDomEnumDualcnstDomEnumDual { get; set; }
  public ItestCnstDomEnumDualObject AsCnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDual<TType>
  : ItestRefCnstDomEnumDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumDualObject<TType> AsRefCnstDomEnumDual { get; set; }
}

public class testJustCnstDomEnumDual
  : DomainEnum
  , ItestJustCnstDomEnumDual
{
}
