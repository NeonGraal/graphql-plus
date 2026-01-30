//HintName: test_constraint-enum-parent+Input_Intf.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public interface ItestCnstEnumPrntInp
{
  public testRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; set; }
  public testCnstEnumPrntInp CnstEnumPrntInp { get; set; }
}

public interface ItestCnstEnumPrntInpObject
{
}

public interface ItestRefCnstEnumPrntInp<Ttype>
{
  public testRefCnstEnumPrntInp RefCnstEnumPrntInp { get; set; }
}

public interface ItestRefCnstEnumPrntInpObject<Ttype>
{
  public Ttype field { get; set; }
}
