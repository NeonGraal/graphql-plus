//HintName: Gqlp_constraint-parent-enum+Input_Impl.gen.cs
// Generated from constraint-parent-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_parent_enum_Input;

public class InputCnstPrntEnumInp
  : ICnstPrntEnumInp
{
  public RefCnstPrntEnumInp<ParentCnstPrntEnumInp> AsRefCnstPrntEnumInp { get; set; }
}

public class InputRefCnstPrntEnumInp<Ttype>
  : IRefCnstPrntEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
