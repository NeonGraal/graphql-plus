//HintName: test_constraint-enum-parent+Input_Impl.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : ItestCnstEnumPrntInp
{
  public testRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; set; }
  public testCnstEnumPrntInp CnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInp<Ttype>
  : ItestRefCnstEnumPrntInp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstEnumPrntInp RefCnstEnumPrntInp { get; set; }
}
