//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject AsCnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
{
}

public interface ItestRefCnstEnumPrntInp<Ttype>
{
  ItestRefCnstEnumPrntInpObject AsRefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<Ttype>
{
  Ttype Field { get; }
}
