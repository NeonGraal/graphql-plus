//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsRefCnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<Ttype>
{
  ItestRefCnstDomEnumInpObject AsRefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<Ttype>
{
  Ttype Field { get; }
}

public interface ItestJustCnstDomEnumInp
  : IDomainEnum
{
}
