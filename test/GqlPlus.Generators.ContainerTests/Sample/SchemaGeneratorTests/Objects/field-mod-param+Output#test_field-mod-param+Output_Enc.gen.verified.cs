//HintName: test_field-mod-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public class testFieldModParamOutp<TMod>
  : GqlpEncoderBase
  , ItestFieldModParamOutp<TMod>
{
  public ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; set; }
}

public class testFieldModParamOutpObject<TMod>
  : GqlpEncoderBase
  , ItestFieldModParamOutpObject<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }

  public testFieldModParamOutpObject
    ( IDictionary<TMod, ItestFldFieldModParamOutp> field
    )
  {
    Field = field;
  }
}

public class testFldFieldModParamOutp
  : GqlpEncoderBase
  , ItestFldFieldModParamOutp
{
  public string? AsString { get; set; }
  public ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutpObject
  : GqlpEncoderBase
  , ItestFldFieldModParamOutpObject
{
  public decimal Field { get; set; }

  public testFldFieldModParamOutpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
