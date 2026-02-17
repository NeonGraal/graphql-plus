//HintName: test_all_Impl.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
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
  : GqlpModelImplementationBase
  , ItestMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public class testField
  : GqlpModelImplementationBase
  , ItestField
{
  public ItestFieldObject? As_Field { get; set; }
}

public class testFieldObject
  : GqlpModelImplementationBase
  , ItestFieldObject
{
  public ICollection<string> Strings { get; set; }

  public testFieldObject(ICollection<string> strings)
  {
    Strings = strings;
  }
}

public class testParam
  : GqlpModelImplementationBase
  , ItestParam
{
  public string? AsString { get; set; }
  public ItestParamObject? As_Param { get; set; }
}

public class testParamObject
  : GqlpModelImplementationBase
  , ItestParamObject
{
  public ItestMany? AfterId { get; set; }
  public ItestMany BeforeId { get; set; }

  public testParamObject(ItestMany beforeId)
  {
    BeforeId = beforeId;
  }
}

public class testAll
  : GqlpModelImplementationBase
  , ItestAll
{
  public string? AsString { get; set; }
  public ItestAllObject? As_All { get; set; }
}

public class testAllObject
  : GqlpModelImplementationBase
  , ItestAllObject
{
  public ItestField? Items(ItestParam? parameter)
    => null;

  public testAllObject()
  {
  }
}
