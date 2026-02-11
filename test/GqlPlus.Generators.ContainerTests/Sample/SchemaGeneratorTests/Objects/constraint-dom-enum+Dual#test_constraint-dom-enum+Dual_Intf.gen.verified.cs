//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
{
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject AsCnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
{
}

public interface ItestRefCnstDomEnumDual<TType>
{
  ItestRefCnstDomEnumDualObject AsRefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumDual
  : IDomainEnum
{
}
