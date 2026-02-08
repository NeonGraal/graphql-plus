//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<ItestEnumCnstEnumInp> AsRefCnstEnumInp { get; set; }
}

public interface ItestCnstEnumInpObject
{
}

public interface ItestRefCnstEnumInp<Ttype>
{
}

public interface ItestRefCnstEnumInpObject<Ttype>
{
  public Ttype Field { get; set; }
}
