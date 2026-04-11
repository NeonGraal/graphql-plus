//HintName: test_generic-field-arg+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public interface ItestGnrcFieldArgOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgOutpObject<TType>? As_GnrcFieldArgOutp { get; }
}

public interface ItestGnrcFieldArgOutpObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgOutp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgOutpObject<TRef>? As_RefGnrcFieldArgOutp { get; }
}

public interface ItestRefGnrcFieldArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}
