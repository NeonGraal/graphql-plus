//HintName: test_field-type-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Output;

public interface ItestFieldTypeDescrOutp
  : IGqlpModelImplementationBase
{
  ItestFieldTypeDescrOutpObject? As_FieldTypeDescrOutp { get; }
}

public interface ItestFieldTypeDescrOutpObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
