//HintName: test_constraint-dom-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public interface ItestCnstDomEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumInp
{
  cnstDomEnumInp,
  other,
}

public interface ItestJustCnstDomEnumInp
  : IGqlpDomainEnum
{
}
