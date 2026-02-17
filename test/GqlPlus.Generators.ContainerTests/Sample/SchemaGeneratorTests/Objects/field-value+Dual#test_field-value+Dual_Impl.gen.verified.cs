//HintName: test_field-value+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}field-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Dual;

public class testFieldValueDual
  : GqlpModelImplementationBase
  , ItestFieldValueDual
{
  public ItestFieldValueDualObject? As_FieldValueDual { get; set; }
}

public class testFieldValueDualObject
  : GqlpModelImplementationBase
  , ItestFieldValueDualObject
{
  public testEnumFieldValueDual Field { get; set; }

  public testFieldValueDualObject(testEnumFieldValueDual field)
  {
    Field = field;
  }
}
