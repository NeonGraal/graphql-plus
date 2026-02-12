//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
{
}

public interface ItestRefCnstPrntEnumDual<TType>
{
  ItestRefCnstPrntEnumDualObject<TType> AsRefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<TType>
{
  TType Field { get; }
}
