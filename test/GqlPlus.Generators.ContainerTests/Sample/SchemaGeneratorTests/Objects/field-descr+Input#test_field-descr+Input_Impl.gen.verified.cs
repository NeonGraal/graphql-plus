//HintName: test_field-descr+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

public class testFieldDescrInp
  : GqlpModelImplementationBase
  , ItestFieldDescrInp
{
  public ItestFieldDescrInpObject? As_FieldDescrInp { get; set; }
}

public class testFieldDescrInpObject
  : GqlpModelImplementationBase
  , ItestFieldDescrInpObject
{
  public string Field { get; set; }

  public testFieldDescrInpObject
    ( string field
    )
  {
    Field = field;
  }
}
