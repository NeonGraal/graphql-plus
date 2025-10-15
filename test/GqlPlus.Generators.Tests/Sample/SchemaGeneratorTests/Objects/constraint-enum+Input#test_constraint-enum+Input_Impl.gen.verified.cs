//HintName: test_constraint-enum+Input_Impl.gen.cs
// Generated from constraint-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class InputtestCnstEnumInp
  : ItestCnstEnumInp
{
  public RefCnstEnumInp<EnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
}

public class InputtestRefCnstEnumInp<Ttype>
  : ItestRefCnstEnumInp<Ttype>
{
  public Ttype field { get; set; }
}
