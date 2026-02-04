//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  public testRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
  public testCnstDomEnumInp CnstDomEnumInp { get; set; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<Ttype>
{
  public testRefCnstDomEnumInp RefCnstDomEnumInp { get; set; }
}

public interface ItestRefCnstDomEnumInpObject<Ttype>
{
  public Ttype field { get; set; }
}

public interface ItestJustCnstDomEnumInp
  : IDomainEnum
{
}
