//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject? As_CnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumInp
{
  cnstEnumInp,
}
