//HintName: test_constraint-dom-enum+Input_Impl.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsEnumCnstDomEnumInpcnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInp<TType>
  : ItestRefCnstDomEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumInpObject<TType> AsRefCnstDomEnumInp { get; set; }
}

public class testJustCnstDomEnumInp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumInp
{
}
