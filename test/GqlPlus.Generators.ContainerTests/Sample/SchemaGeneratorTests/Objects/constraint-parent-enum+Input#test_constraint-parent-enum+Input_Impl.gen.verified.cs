//HintName: test_constraint-parent-enum+Input_Impl.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class testCnstPrntEnumInp
  : ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject AsCnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInp<TType>
  : ItestRefCnstPrntEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstPrntEnumInpObject AsRefCnstPrntEnumInp { get; set; }
}
