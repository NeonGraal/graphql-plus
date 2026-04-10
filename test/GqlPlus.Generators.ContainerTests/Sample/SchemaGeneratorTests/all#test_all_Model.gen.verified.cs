//HintName: test_all_Model.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

public class testGuid
  : GqlpDomainString
  , ItestGuid
{
}

public class testMany
  : GqlpModelBase
  , ItestMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public class testField
  : GqlpModelBase
  , ItestField
{
  public ItestFieldObject? As_Field { get; set; }
}

public class testFieldObject
  : GqlpModelBase
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
  : GqlpModelBase
  , ItestParam
{
  public string? AsString { get; set; }
  public ItestParamObject? As_Param { get; set; }
}

public class testParamObject
  : GqlpModelBase
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
  : GqlpModelBase
  , ItestAll
{
  public string? AsString { get; set; }
  public ItestAllObject? As_All { get; set; }
}

public class testAllObject
  : GqlpModelBase
  , ItestAllObject
{
  public ItestField? Items(ItestParam? parameter)
    => null;

  public testAllObject
    ()
  {
  }
}
