//HintName: test_input-field-descr-Number_Model.gen.cs
// Generated from {CurrentDirectory}input-field-descr-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_descr_Number;

public class testInpFieldDescrNmbr
  : GqlpModelBase
  , ItestInpFieldDescrNmbr
{
  public ItestInpFieldDescrNmbrObject? As_InpFieldDescrNmbr { get; set; }
}

public class testInpFieldDescrNmbrObject
  : GqlpModelBase
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
