//HintName: test_constraint-enum-parent+Input_Impl.gen.cs
// Generated from constraint-enum-parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : ItestCnstEnumPrntInp
{
  public RefCnstEnumPrntInp<EnumCnstEnumPrntInp> AsRefCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInp<Ttype>
  : ItestRefCnstEnumPrntInp<Ttype>
{
  public Ttype field { get; set; }
}
