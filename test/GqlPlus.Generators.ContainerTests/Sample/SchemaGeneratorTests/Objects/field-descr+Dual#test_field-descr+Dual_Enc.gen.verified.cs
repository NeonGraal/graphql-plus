//HintName: test_field-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Dual;

public class testFieldDescrDual
  : GqlpEncoderBase
  , ItestFieldDescrDual
{
  public ItestFieldDescrDualObject? As_FieldDescrDual { get; set; }
}

public class testFieldDescrDualObject
  : GqlpEncoderBase
  , ItestFieldDescrDualObject
{
  public string Field { get; set; }

  public testFieldDescrDualObject
    ( string field
    )
  {
    Field = field;
  }
}
