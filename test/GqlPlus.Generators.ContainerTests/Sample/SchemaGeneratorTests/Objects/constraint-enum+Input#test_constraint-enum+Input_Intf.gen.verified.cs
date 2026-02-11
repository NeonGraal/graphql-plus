//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp> AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject AsCnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
{
}

public interface ItestRefCnstEnumInp<TType>
{
  ItestRefCnstEnumInpObject AsRefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
{
  TType Field { get; }
}
