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
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstDomEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public interface ItestJustCnstDomEnumInp
  : IGqlpDomainEnum
{
  new testEnumCnstDomEnumInp? Value { get; }
}
