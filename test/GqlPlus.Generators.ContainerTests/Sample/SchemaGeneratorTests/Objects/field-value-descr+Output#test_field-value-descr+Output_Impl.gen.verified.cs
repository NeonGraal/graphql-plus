//HintName: test_field-value-descr+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Output;

public class testFieldValueDescrOutp
  : GqlpModelImplementationBase
  , ItestFieldValueDescrOutp
{
  public ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; set; }
}

public class testFieldValueDescrOutpObject
  : GqlpModelImplementationBase
  , ItestFieldValueDescrOutpObject
{
  public testEnumFieldValueDescrOutp Field { get; set; }

  public testFieldValueDescrOutpObject(testEnumFieldValueDescrOutp field)
  {
    Field = field;
  }
}
