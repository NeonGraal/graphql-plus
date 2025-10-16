//HintName: test_constraint-enum+Input_Impl.gen.cs
// Generated from constraint-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : ItestCnstEnumInp
{
  public RefCnstEnumInp<EnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
}

public class testRefCnstEnumInp<Ttype>
  : ItestRefCnstEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
