//HintName: test_constraint-parent-enum+Input_Intf.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public interface ItestCnstPrntEnumInp
{
  RefCnstPrntEnumInp<ParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInp<Ttype>
{
  Ttype field { get; }
}
