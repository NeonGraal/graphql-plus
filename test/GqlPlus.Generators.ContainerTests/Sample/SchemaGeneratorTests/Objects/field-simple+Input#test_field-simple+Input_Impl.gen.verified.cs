//HintName: test_field-simple+Input_Impl.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

public class testFieldSmplInp
  : GqlpModelImplementationBase
  , ItestFieldSmplInp
{
  public ItestFieldSmplInpObject? As_FieldSmplInp { get; set; }
}

public class testFieldSmplInpObject
  : GqlpModelImplementationBase
  , ItestFieldSmplInpObject
{
  public decimal Field { get; set; }

  public testFieldSmplInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
