//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
{
}

public interface ItestRefCnstPrntEnumDual<Ttype>
{
  ItestRefCnstPrntEnumDualObject AsRefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<Ttype>
{
  Ttype Field { get; }
}
