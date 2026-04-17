//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; }
  ItestGnrcValueOutpObject? As_GnrcValueOutp { get; }
}

public interface ItestGnrcValueOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueOutp
{
  gnrcValueOutp,
}
