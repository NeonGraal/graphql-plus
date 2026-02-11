//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp> AsRefCnstEnumInp { get; }
  ItestCnstEnumInpObject AsCnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
{
}

public interface ItestRefCnstEnumInp<Ttype>
{
  ItestRefCnstEnumInpObject AsRefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<Ttype>
{
  Ttype Field { get; }
}
