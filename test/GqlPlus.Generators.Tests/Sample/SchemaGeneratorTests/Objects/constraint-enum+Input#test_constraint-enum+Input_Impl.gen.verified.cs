//HintName: test_constraint-enum+Input_Impl.gen.cs
// Generated from constraint-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : ItestCnstEnumInp
{
  public testRefCnstEnumInp<testEnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
  public testCnstEnumInp CnstEnumInp { get; set; }
}

public class testRefCnstEnumInp<Ttype>
  : ItestRefCnstEnumInp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstEnumInp RefCnstEnumInp { get; set; }
}
