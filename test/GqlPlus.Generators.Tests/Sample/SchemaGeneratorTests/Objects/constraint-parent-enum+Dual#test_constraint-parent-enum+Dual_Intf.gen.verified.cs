//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
{
  RefCnstPrntEnumDual<ParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDual<Ttype>
{
  Ttype field { get; }
}
