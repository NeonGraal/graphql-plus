//HintName: test_field-value-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Dual;

public interface ItestFieldValueDescrDual
  : IGqlpModelImplementationBase
{
  ItestFieldValueDescrDualObject? As_FieldValueDescrDual { get; }
}

public interface ItestFieldValueDescrDualObject
  : IGqlpModelImplementationBase
{
  testEnumFieldValueDescrDual Field { get; }
}

public enum testEnumFieldValueDescrDual
{
  fieldValueDescrDual,
}
