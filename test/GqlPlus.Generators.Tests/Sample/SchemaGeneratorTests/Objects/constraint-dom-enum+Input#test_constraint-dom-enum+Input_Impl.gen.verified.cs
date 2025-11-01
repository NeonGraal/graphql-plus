//HintName: test_constraint-dom-enum+Input_Impl.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : ItestCnstDomEnumInp
{
  public testRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
  public testCnstDomEnumInp CnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInp<Ttype>
  : ItestRefCnstDomEnumInp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstDomEnumInp RefCnstDomEnumInp { get; set; }
}

public class testJustCnstDomEnumInp
  : ItestJustCnstDomEnumInp
{
}
