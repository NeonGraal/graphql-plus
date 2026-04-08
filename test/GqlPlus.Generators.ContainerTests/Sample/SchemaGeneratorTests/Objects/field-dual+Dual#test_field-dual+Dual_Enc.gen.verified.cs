//HintName: test_field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

public class testFieldDualDual
  : GqlpEncoderBase
  , ItestFieldDualDual
{
  public ItestFieldDualDualObject? As_FieldDualDual { get; set; }
}

public class testFieldDualDualObject
  : GqlpEncoderBase
  , ItestFieldDualDualObject
{
  public ItestFldFieldDualDual Field { get; set; }

  public testFieldDualDualObject
    ( ItestFldFieldDualDual field
    )
  {
    Field = field;
  }
}

public class testFldFieldDualDual
  : GqlpEncoderBase
  , ItestFldFieldDualDual
{
  public string? AsString { get; set; }
  public ItestFldFieldDualDualObject? As_FldFieldDualDual { get; set; }
}

public class testFldFieldDualDualObject
  : GqlpEncoderBase
  , ItestFldFieldDualDualObject
{
  public decimal Field { get; set; }

  public testFldFieldDualDualObject
    ( decimal field
    )
  {
    Field = field;
  }
}
