//HintName: test_constraint-parent-enum+Dual_Impl.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDual<Ttype>
  : ItestRefCnstPrntEnumDual<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstPrntEnumDualObject AsRefCnstPrntEnumDual { get; set; }
}
