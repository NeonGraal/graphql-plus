//HintName: test_input-field-descr-Number_Impl.gen.cs
// Generated from {CurrentDirectory}input-field-descr-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_descr_Number;

public class testInpFieldDescrNmbr
  : GqlpModelImplementationBase
  , ItestInpFieldDescrNmbr
{
  public ItestInpFieldDescrNmbrObject? As_InpFieldDescrNmbr { get; set; }
}

public class testInpFieldDescrNmbrObject
  : GqlpModelImplementationBase
  , ItestInpFieldDescrNmbrObject
{
  public decimal Field { get; set; }

  public testInpFieldDescrNmbrObject
    ( decimal field
    )
  {
    Field = field;
  }
}
