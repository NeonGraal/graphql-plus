//HintName: test_constraint-dom-enum+Input_Impl.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<ItestEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInp<Ttype>
  : ItestRefCnstDomEnumInp<Ttype>
{
  public Ttype Field { get; set; }
  public ItestRefCnstDomEnumInpObject AsRefCnstDomEnumInp { get; set; }
}

public class testJustCnstDomEnumInp
  : DomainEnum
  , ItestJustCnstDomEnumInp
{
}
