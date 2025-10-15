//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from constraint-enum+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
{
  RefCnstEnumInp<EnumCnstEnumInp> AsRefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInp<Ttype>
{
  Ttype field { get; }
}
