//HintName: test_constraint-parent-enum+Input_Impl.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class InputtestCnstPrntEnumInp
  : ItestCnstPrntEnumInp
{
  public RefCnstPrntEnumInp<ParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
}

public class InputtestRefCnstPrntEnumInp<Ttype>
  : ItestRefCnstPrntEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
