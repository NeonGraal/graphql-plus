//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject AsCnstPrntEnumInp { get; set; }
}

public interface ItestCnstPrntEnumInpObject
{
}

public interface ItestRefCnstPrntEnumInp<Ttype>
{
  public ItestRefCnstPrntEnumInpObject AsRefCnstPrntEnumInp { get; set; }
}

public interface ItestRefCnstPrntEnumInpObject<Ttype>
{
  public Ttype Field { get; set; }
}
