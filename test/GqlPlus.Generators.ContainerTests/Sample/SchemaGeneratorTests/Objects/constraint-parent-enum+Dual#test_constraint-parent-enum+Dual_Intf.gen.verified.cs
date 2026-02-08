//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<ItestParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; set; }
}

public interface ItestCnstPrntEnumDualObject
{
}

public interface ItestRefCnstPrntEnumDual<Ttype>
{
  public ItestRefCnstPrntEnumDualObject AsRefCnstPrntEnumDual { get; set; }
}

public interface ItestRefCnstPrntEnumDualObject<Ttype>
{
  public Ttype Field { get; set; }
}
