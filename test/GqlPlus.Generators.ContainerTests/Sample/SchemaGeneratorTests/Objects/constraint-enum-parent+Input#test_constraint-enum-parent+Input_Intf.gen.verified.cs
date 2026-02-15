//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject AsCnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
{
}

public interface ItestRefCnstEnumPrntInp<TType>
{
  ItestRefCnstEnumPrntInpObject<TType> AsRefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
{
  TType Field { get; }
}
