//HintName: test_generic-value+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public class testGnrcValueDual
  : GqlpEncoderBase
  , ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; set; }
  public ItestGnrcValueDualObject? As_GnrcValueDual { get; set; }
}

public class testGnrcValueDualObject
  : GqlpEncoderBase
  , ItestGnrcValueDualObject
{

  public testGnrcValueDualObject
    ()
  {
  }
}

public class testRefGnrcValueDual<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueDual<TType>
{
  public ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; set; }
}

public class testRefGnrcValueDualObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcValueDual
{
  gnrcValueDual,
}
