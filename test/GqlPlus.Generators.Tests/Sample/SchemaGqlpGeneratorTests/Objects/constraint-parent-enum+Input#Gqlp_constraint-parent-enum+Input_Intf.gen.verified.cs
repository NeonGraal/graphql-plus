//HintName: Gqlp_constraint-parent-enum+Input_Intf.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Input;

public interface ICnstPrntEnumInp
{
  RefCnstPrntEnumInp<ParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; }
}

public interface IRefCnstPrntEnumInp<Ttype>
{
  Ttype field { get; }
}
