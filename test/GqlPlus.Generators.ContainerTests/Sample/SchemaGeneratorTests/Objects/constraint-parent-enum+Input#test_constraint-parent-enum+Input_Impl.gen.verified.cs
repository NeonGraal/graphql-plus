//HintName: test_constraint-parent-enum+Input_Impl.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class testCnstPrntEnumInp
  : ItestCnstPrntEnumInp
{
  public testRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
  public testCnstPrntEnumInp CnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInp<Ttype>
  : ItestRefCnstPrntEnumInp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstPrntEnumInp RefCnstPrntEnumInp { get; set; }
}
