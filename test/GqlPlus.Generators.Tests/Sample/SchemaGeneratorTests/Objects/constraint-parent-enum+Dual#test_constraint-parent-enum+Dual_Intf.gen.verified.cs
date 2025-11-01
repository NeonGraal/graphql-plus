//HintName: test_constraint-parent-enum+Dual_Intf.gen.cs
// Generated from constraint-parent-enum+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public interface ItestCnstPrntEnumDual
{
  public testRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsRefCnstPrntEnumDual { get; set; }
  public testCnstPrntEnumDual CnstPrntEnumDual { get; set; }
}

public interface ItestCnstPrntEnumDualField
{
}

public interface ItestRefCnstPrntEnumDual<Ttype>
{
  public testRefCnstPrntEnumDual RefCnstPrntEnumDual { get; set; }
}

public interface ItestRefCnstPrntEnumDualField<Ttype>
{
  public Ttype field { get; set; }
}
