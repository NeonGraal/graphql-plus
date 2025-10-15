//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
{
  RefCnstEnumPrntInp<EnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInp<Ttype>
{
  Ttype field { get; }
}
