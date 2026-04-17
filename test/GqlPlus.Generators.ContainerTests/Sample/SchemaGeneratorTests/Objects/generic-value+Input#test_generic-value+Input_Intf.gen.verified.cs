//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; }
  ItestGnrcValueInpObject? As_GnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueInp
{
  gnrcValueInp,
}
