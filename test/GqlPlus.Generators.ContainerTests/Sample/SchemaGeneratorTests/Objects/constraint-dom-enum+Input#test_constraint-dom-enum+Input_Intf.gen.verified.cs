//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from constraint-dom-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<TType>
{
  ItestRefCnstDomEnumInpObject AsRefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumInp
  : IDomainEnum
{
}
