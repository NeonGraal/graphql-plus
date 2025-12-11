//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
{
  public testRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
  public testCnstPrntEnumInp CnstPrntEnumInp { get; set; }
}

public interface ItestCnstPrntEnumInpField
{
}

public interface ItestRefCnstPrntEnumInp<Ttype>
{
  public testRefCnstPrntEnumInp RefCnstPrntEnumInp { get; set; }
}

public interface ItestRefCnstPrntEnumInpField<Ttype>
{
  public Ttype field { get; set; }
}
