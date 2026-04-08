//HintName: test_all_Enc.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : GqlpDomainString
  , ItestGuid
{
}

public enum testOne
{
  Two,
  Three,
}

public class testMany
  : GqlpEncoderBase
  , ItestMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public class testField
  : GqlpEncoderBase
  , ItestField
{
  public ItestFieldObject? As_Field { get; set; }
}

public class testFieldObject
  : GqlpEncoderBase
  , ItestFieldObject
{
  public ICollection<string> Strings { get; set; }

  public testFieldObject
    ( ICollection<string> strings
    )
  {
    Strings = strings;
  }
}

public class testParam
  : GqlpEncoderBase
  , ItestParam
{
  public string? AsString { get; set; }
  public ItestParamObject? As_Param { get; set; }
}

public class testParamObject
  : GqlpEncoderBase
  , ItestParamObject
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }

  public testParamObject
    ( ItestMany beforeId
    )
  {
    BeforeId = beforeId;
  }
}

public class testAll
  : GqlpEncoderBase
  , ItestAll
{
  public string? AsString { get; set; }
  public ItestAllObject? As_All { get; set; }
}

public class testAllObject
  : GqlpEncoderBase
  , ItestAllObject
{
  public ItestField? Items(ItestParam? parameter)
    => null;

  public testAllObject
    ()
  {
  }
}
