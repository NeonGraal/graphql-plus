//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; set; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<Ttype>
{
  public ItestRefCnstDomEnumInpObject AsRefCnstDomEnumInp { get; set; }
}

public interface ItestRefCnstDomEnumInpObject<Ttype>
{
  public Ttype Field { get; set; }
}

public interface ItestJustCnstDomEnumInp
  : IDomainEnum
{
}
