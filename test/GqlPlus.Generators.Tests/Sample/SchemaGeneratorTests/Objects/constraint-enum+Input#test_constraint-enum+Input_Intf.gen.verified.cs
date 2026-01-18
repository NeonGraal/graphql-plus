//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
{
  public testRefCnstEnumInp<testEnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
  public testCnstEnumInp CnstEnumInp { get; set; }
}

public interface ItestCnstEnumInpField
{
}

public interface ItestRefCnstEnumInp<Ttype>
{
  public testRefCnstEnumInp RefCnstEnumInp { get; set; }
}

public interface ItestRefCnstEnumInpField<Ttype>
{
  public Ttype field { get; set; }
}
