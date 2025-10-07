//HintName: Gqlp_constraint-enum+Input_Impl.gen.cs
// Generated from constraint-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_enum_Input;

public class InputCnstEnumInp
  : ICnstEnumInp
{
  public RefCnstEnumInp<EnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
}

public class InputRefCnstEnumInp<Ttype>
  : IRefCnstEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
