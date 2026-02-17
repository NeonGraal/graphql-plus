//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
{
}

public interface ItestRefCnstDomEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumInpObject<TType> AsRefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumInp
  : IGqlpDomainEnum
{
}
