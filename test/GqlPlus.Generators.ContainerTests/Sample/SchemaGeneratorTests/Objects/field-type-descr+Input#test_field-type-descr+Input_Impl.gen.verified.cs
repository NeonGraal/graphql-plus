//HintName: test_field-type-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

public class testFieldTypeDescrInp
  : GqlpModelImplementationBase
  , ItestFieldTypeDescrInp
{
  public ItestFieldTypeDescrInpObject? As_FieldTypeDescrInp { get; set; }
}

public class testFieldTypeDescrInpObject
  : GqlpModelImplementationBase
  , ItestFieldTypeDescrInpObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrInpObject(decimal field)
  {
    Field = field;
  }
}
