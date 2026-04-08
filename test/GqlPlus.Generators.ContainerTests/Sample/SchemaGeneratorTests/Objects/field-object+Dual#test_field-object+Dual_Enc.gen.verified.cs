//HintName: test_field-object+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

public class testFieldObjDual
  : GqlpEncoderBase
  , ItestFieldObjDual
{
  public ItestFieldObjDualObject? As_FieldObjDual { get; set; }
}

public class testFieldObjDualObject
  : GqlpEncoderBase
  , ItestFieldObjDualObject
{
  public ItestFldFieldObjDual Field { get; set; }

  public testFieldObjDualObject
    ( ItestFldFieldObjDual field
    )
  {
    Field = field;
  }
}

public class testFldFieldObjDual
  : GqlpEncoderBase
  , ItestFldFieldObjDual
{
  public string? AsString { get; set; }
  public ItestFldFieldObjDualObject? As_FldFieldObjDual { get; set; }
}

public class testFldFieldObjDualObject
  : GqlpEncoderBase
  , ItestFldFieldObjDualObject
{
  public decimal Field { get; set; }

  public testFldFieldObjDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
