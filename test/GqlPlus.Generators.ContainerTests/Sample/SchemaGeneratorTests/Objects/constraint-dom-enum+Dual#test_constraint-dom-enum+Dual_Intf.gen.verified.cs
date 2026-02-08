//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<ItestEnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; set; }
}

public interface ItestCnstDomEnumDualObject
{
}

public interface ItestRefCnstDomEnumDual<Ttype>
{
}

public interface ItestRefCnstDomEnumDualObject<Ttype>
{
  public Ttype Field { get; set; }
}

public interface ItestJustCnstDomEnumDual
  : IDomainEnum
{
}
