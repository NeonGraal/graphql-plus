//HintName: test_constraint-enum+Dual_Intf.gen.cs
// Generated from constraint-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public interface ItestCnstEnumDual
{
  RefCnstEnumDual<EnumCnstEnumDual> AsRefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDual<Ttype>
{
  Ttype field { get; }
}
