//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
{
  ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; }
  ItestCnstPrntEnumInpObject AsCnstPrntEnumInp { get; }
}

public interface ItestCnstPrntEnumInpObject
{
}

public interface ItestRefCnstPrntEnumInp<TType>
{
  ItestRefCnstPrntEnumInpObject AsRefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInpObject<TType>
{
  TType Field { get; }
}
