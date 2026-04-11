//HintName: test_field-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

public interface ItestFieldDescrOutp
  : IGqlpInterfaceBase
{
  ItestFieldDescrOutpObject? As_FieldDescrOutp { get; }
}

public interface ItestFieldDescrOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
