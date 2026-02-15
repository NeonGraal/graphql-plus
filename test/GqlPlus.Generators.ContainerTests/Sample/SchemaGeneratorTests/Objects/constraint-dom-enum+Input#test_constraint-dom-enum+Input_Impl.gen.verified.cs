//HintName: test_constraint-dom-enum+Input_Impl.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : ItestCnstDomEnumInp
{
}

public class testRefCnstDomEnumInp<TType>
  : ItestRefCnstDomEnumInp<TType>
{
  public TType Field { get; set; }
}

public class testJustCnstDomEnumInp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumInp
{
}
