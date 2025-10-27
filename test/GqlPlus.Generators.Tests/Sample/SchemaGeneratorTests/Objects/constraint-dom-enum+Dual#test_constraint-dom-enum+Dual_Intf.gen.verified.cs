//HintName: test_constraint-dom-enum+Dual_Intf.gen.cs
// Generated from constraint-dom-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public interface ItestCnstDomEnumDual
{
  RefCnstDomEnumDual<EnumCnstDomEnumDual> AsRefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDual<Ttype>
{
  Ttype field { get; }
}

public interface ItestJustCnstDomEnumDual
{
}
