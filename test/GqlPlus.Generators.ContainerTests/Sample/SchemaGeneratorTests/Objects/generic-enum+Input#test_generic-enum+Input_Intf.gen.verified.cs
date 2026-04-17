//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; }
  ItestGnrcEnumInpObject? As_GnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumInp
{
  gnrcEnumInp,
}
