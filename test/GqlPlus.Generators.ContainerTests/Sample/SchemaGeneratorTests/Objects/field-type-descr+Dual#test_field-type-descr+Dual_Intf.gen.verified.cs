//HintName: test_field-type-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Dual;

public interface ItestFieldTypeDescrDual
  : IGqlpModelImplementationBase
{
  ItestFieldTypeDescrDualObject? As_FieldTypeDescrDual { get; }
}

public interface ItestFieldTypeDescrDualObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
