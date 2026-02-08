//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<ItestEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; set; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<Ttype>
{
}

public interface ItestRefCnstDomEnumInpObject<Ttype>
{
  public Ttype Field { get; set; }
}

public interface ItestJustCnstDomEnumInp
  : IDomainEnum
{
}
